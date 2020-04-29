/*    
   Copyright (C) 2020 Grupo 1
   Martín Amechazurra Falagán
   Gonzalo Alba Durán
   Nuria Bango Iglesias
   Marcos Llinares Montes

   Comportamiento que trata de evitar que agentes se peguen
   demasiado a otros que van en su misma dirección.
*/

namespace UCM.IAV.Movimiento
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class Separacion : ComportamientoAgente
    {
        /// <summary>
        /// Obtiene la dirección
        /// </summary>
        /// <returns></returns>

        public float maxAcceleration;
        public float threshold;
        public float decayCoefficient;
        [HideInInspector] public Seguir f;

        public void Start()
        {
            f = GetComponent<Seguir>();
        }

        public override Direccion GetDireccion()
        {
            Direccion result = new Direccion();
            UnityEngine.Vector3 direction;

            //if (f.getOnTarget())
                //return result;

            foreach (Flocking target in FindObjectsOfType<Flocking>())
            {
                if (target != this)
                {
                    direction = -1 * (target.transform.position - transform.position);
                    float distance = direction.magnitude;

                    if (distance < threshold)
                    {
                        // strange of repulsion
                        float strength = UnityEngine.Mathf.Min(decayCoefficient / (distance * distance), maxAcceleration);

                        direction.Normalize();

                        result.lineal += strength * direction;
                    }
                }

            }
            return result;
        }
    }
}
