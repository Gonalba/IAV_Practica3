using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCM.IAV.Movimiento
{
    public class Lever : MonoBehaviour
    {
        public Lamp lampara;
        public float leverSpeed;

        private bool leverState;
        private Quaternion truePosition; // Posición cuando leverState es true
        private Quaternion falsePosition; // Posición cuando leverState es false

        // Start is called before the first frame update
        void Start()
        {
            leverState = lampara.isUp();
            transform.parent.transform.Rotate(0.0f, 0.0f, -45.0f, Space.World);

            truePosition = Quaternion.Euler(0.0f, 0.0f, -45.0f);
            falsePosition = Quaternion.Euler(0.0f, 0.0f, 45.0f);
        }

        // Update is called once per frame
        void Update()
        {
            if (leverState)
            {
                if (transform.parent.transform.rotation.eulerAngles.z > -45.0f)
                {
                    transform.parent.transform.rotation = Quaternion.Slerp(transform.rotation, truePosition, Time.deltaTime * leverSpeed);
                }
            }
            else
            {
                if (transform.parent.transform.rotation.eulerAngles.z < 45.0f)
                {
                    transform.parent.transform.rotation = Quaternion.Slerp(transform.rotation, falsePosition, Time.deltaTime * leverSpeed);
                }
            }
        }

        void OnTriggerStay(Collider other)
        {
            if (other.tag == "Vizconde" && Input.GetKeyDown("e"))
            {
                leverState = !leverState;
                lampara.toggleLampState();
            }
        }

    }
}