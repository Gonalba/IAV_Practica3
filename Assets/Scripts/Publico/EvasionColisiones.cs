/*    
   Copyright (C) 2020 Grupo 1
   Martín Amechazurra Falagán
   Gonzalo Alba Durán
   Nuria Bango Iglesias
   Marcos Llinares Montes

   Comportamiento que trata de no chocar con otros agentes en direcciones 
   distintas con los que se vaya a producir la colisión
   Calcula el agente que vaya a colisionar “más pronto” con él
*/

namespace UCM.IAV.Movimiento
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class EvasionColisiones : ComportamientoAgente
    {
        public float maxAcceleration;
        public float radius;
        [HideInInspector] public Seguir f;

        public void Start()
        {
            f = GetComponent<Seguir>();
        }

        public override Direccion GetDireccion()
        {
            Direccion result = new Direccion();

            if (f.getOnTarget())
                return result;

            Flocking firstTarget = null;

            float shortestTime = float.MaxValue;
            float firstMinSeparation = 0;
            float firstDistance = 0;
            float relativeSpeed;
            float timeToCollision;
            float distance;

            UnityEngine.Vector3 relativePos = UnityEngine.Vector3.zero;
            UnityEngine.Vector3 relativeVel = UnityEngine.Vector3.zero;
            UnityEngine.Vector3 firstRelativePos = UnityEngine.Vector3.zero;
            UnityEngine.Vector3 firstRelativeVel = UnityEngine.Vector3.zero;

            foreach(Flocking target in FindObjectsOfType<Flocking>())
            {
                
                if (target != this)
                {
                    // TIME TO COLLISION
                    relativePos = (target.transform.position - transform.position);
                    relativeVel = target.GetAgente().velocidad - agente.velocidad;
                    relativeSpeed = relativeVel.magnitude;
                    timeToCollision = UnityEngine.Vector3.Dot(relativePos, relativeVel) / (relativeSpeed * relativeSpeed);

                    //CHECK IF COLLISION
                    distance = relativePos.magnitude;
                    float minSeparation = distance - relativeSpeed * timeToCollision;
                    if (minSeparation < 2 * radius) return result; // If not collision, return previous result from class Separation

                    //CHECK IF SHORTEST
                    if(timeToCollision > 0 && timeToCollision < shortestTime)
                    {
                        shortestTime = timeToCollision;
                        firstTarget = target;
                        firstMinSeparation = minSeparation;
                        firstDistance = distance;
                        firstRelativePos = relativePos;
                        firstRelativeVel = relativeVel;
                    }
                }
            }

            //IF NO TARGET, EXIT
            if (!firstTarget) return result;

            //IF CURRENT OR FUTURE COLLISION, STEERING
            if(firstMinSeparation <= 0 || firstDistance < 2 * radius)
            {
                relativePos = firstTarget.transform.position - transform.position;
            }
            else
            {
                relativePos = firstRelativePos + (firstRelativeVel * shortestTime);
            }

            relativePos.Normalize();

            result.lineal = relativePos * maxAcceleration;
            result.angular = 0;

    
            return result;
        }


    }
}