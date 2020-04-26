using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCM.IAV.Movimiento
{
    public class Lamp : MonoBehaviour
    {

        public UnityEngine.Vector3 UpPosition;
        public float UpVelocity;
        public UnityEngine.Vector3 DownPosition;
        public float DownVelocity;

        /// <summary>
        /// True if PULLED (UP), false if DROPPED (Down)
        /// </summary>
        private bool lampState;

        private Emisor emisor;

        // Start is called before the first frame update
        void Start()
        {
            lampState = true;
            emisor = gameObject.GetComponent<Emisor>();
        }

        // Update is called once per frame
        void Update()
        {
            if (lampState)
            {
                if (transform.position.y < UpPosition.y)
                {
                    transform.position = Vector3.MoveTowards(transform.position, UpPosition, Time.deltaTime * UpVelocity);
                }
            }
            else
            {
                if (transform.position.y > DownPosition.y)
                {
                    transform.position = Vector3.MoveTowards(transform.position, DownPosition, Time.deltaTime * DownVelocity);
                }
            }

        }

        public bool isUp()
        {
            return lampState;
        }

        public void toggleLampState()
        {
            lampState = !lampState;

            if (lampState) emisor.EnviarMensaje(MENSAJE_ID.LAMP_UP);
            else emisor.EnviarMensaje(MENSAJE_ID.LAMP_DOWN);
        }

    }
}
