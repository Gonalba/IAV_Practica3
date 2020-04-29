/*    
   Copyright (C) 2020 Federico Peinado
   http://www.federicopeinado.com

   Este fichero forma parte del material de la asignatura Inteligencia Artificial para Videojuegos.
   Esta asignatura se imparte en la Facultad de Informática de la Universidad Complutense de Madrid (España).

   Autor: Federico Peinado 
   Contacto: email@federicopeinado.com
*/
namespace UCM.IAV.Movimiento
{

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Clase para modelar el controlador del jugador como agente
    /// </summary>
    public class JugadorAgente : Agente
    {
        /// <summary>
        /// Velocidad máxima
        /// </summary>
        [Tooltip("Velocidad real.")]
        public float velocidadReal;
        /// <summary>
        /// El componente de cuerpo rígido
        /// </summary>
        private Rigidbody _cuerpoRigido;
        /// <summary>
        /// El número de la cámara actual
        /// </summary>
        private int numCamaraActual;


        /// <summary>
        /// Al despertar, establecer el cuerpo rígido
        /// </summary>
        private void Awake()
        {
            velocidad = Vector3.zero;
            numCamaraActual = 0;
            _cuerpoRigido = GetComponent<Rigidbody>();
        }

        /// <summary>
        /// En cada tick, mover el avatar del jugador según las órdenes de este último
        /// </summary>
        public override void Update()
        {
            //Rango de Input.GetAxis("Horizontal"): [-1,1]
            switch (numCamaraActual)
            {
                //Sur y Cenital
                case 0:
                case 4:
                    velocidad.x = Input.GetAxis("Horizontal");
                    velocidad.z = Input.GetAxis("Vertical");
                    break;
                //Oeste
                case 1:
                    velocidad.x = Input.GetAxis("Vertical");
                    velocidad.z = Input.GetAxis("Horizontal") * -1;
                    break;
                //Norte
                case 2:
                    velocidad.x = Input.GetAxis("Horizontal") * -1;
                    velocidad.z = Input.GetAxis("Vertical") * -1;
                    break;
                //Este
                case 3:
                    velocidad.x = Input.GetAxis("Vertical") * -1;
                    velocidad.z = Input.GetAxis("Horizontal");
                    break;
                default:
                    Debug.Log("WTF");
                    break;
            }

            velocidad *= velocidadReal; 
        }

        /// <summary>
        /// En cada tick fijo, si hay cuerpo rígido, cambio la posición de las cosas
        /// </summary>
        public override void FixedUpdate()
        {
            if (_cuerpoRigido != null)
            {
                transform.Translate(velocidad * Time.deltaTime, Space.World);
            } 
        }

        /// <summary>
        /// En cada parte tardía del tick, encarar el agente
        /// </summary>
        public override void LateUpdate()
        {
            if (velocidad.magnitude > velocidadMax)//cuando va recto bien cuando va en diagonal lo supera
            {
                velocidad.Normalize();
                velocidad = velocidad * velocidadMax;
            }

            transform.LookAt(transform.position + velocidad);
        }

        public void ChangeCameraNumber(int pos)
        {
            numCamaraActual = pos;
        }
    }
}
