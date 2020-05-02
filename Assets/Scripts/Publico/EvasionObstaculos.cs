/*    
   Copyright (C) 2020 Grupo 1
   Martín Amechazurra Falagán
   Gonzalo Alba Durán
   Nuria Bango Iglesias
   Marcos Llinares Montes

   Comportamiento que trata de no chocar con obstáculos que se encuentren
   en su raycast frontal en un rango determinado
*/


namespace UCM.IAV.Movimiento
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class EvasionObstaculos : ComportamientoAgente
    {
        public float lookAhead;
        public float avoidDistance;
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

            UnityEngine.Vector3 ray = agente.velocidad;
            ray.Normalize();
            ray *= lookAhead;


            UnityEngine.RaycastHit hit;

            //COLLISION
            if (UnityEngine.Physics.Raycast(transform.position, ray, out hit))
            {
                result.lineal = hit.collider.gameObject.transform.position + hit.normal * avoidDistance;
            }
            //result.lineal.y = 0;
            return result;
        }
    }
}