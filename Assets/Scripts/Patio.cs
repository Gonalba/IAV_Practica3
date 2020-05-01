using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UCM.IAV.Movimiento
{
    public class Patio : MonoBehaviour
    {
        public GameObject lampO;
        public GameObject lampE;

        public void Update()
        {
            if (lampE.GetComponent<Lamp>().lampState && lampO.GetComponent<Lamp>().lampState)
                GetComponent<BoxCollider>().enabled = true;
            else
                GetComponent<BoxCollider>().enabled = false;
        }
    }
}