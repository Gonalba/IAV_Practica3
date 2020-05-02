using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCM.IAV.Movimiento
{
    public class Espectador : MonoBehaviour
    {
        public GameObject patio;
        public GameObject deathZone;

        private int lampsDown;
        private bool onPatio;

        // Start is called before the first frame update
        void Start()
        {
            lampsDown = 0;
            onPatio = true;
        }

        // Update is called once per frame
        void Update()
        {
            if(onPatio && lampsDown > 0)
            {
                GetComponent<Seguir>().changeObjective(deathZone);
                GetComponent<EvasionObstaculos>().enabled = true;
            } else if(!onPatio && lampsDown < 1)
            {
                GetComponent<Seguir>().changeObjective(patio);
                GetComponent<EvasionObstaculos>().enabled = false;
            }
        }

        public void lampDown (){ lampsDown++; onPatio = true; }

        public void lampUp() { lampsDown--; onPatio = false; }

        public GameObject getPatio() { return patio; }
        public GameObject getDeathZone() { return deathZone; }
    }
}
