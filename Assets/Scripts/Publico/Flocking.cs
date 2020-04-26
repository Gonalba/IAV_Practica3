/*    
   Copyright (C) 2020 Grupo 1
   Martín Amechazurra Falagán
   Gonzalo Alba Durán
   Nuria Bango Iglesias
   Marcos Llinares Montes

   Script principal para la simulación de bandada
   En él se encuentra el array de todos los agentes que pertenecen al grupo
*/

namespace UCM.IAV.Movimiento
{
    using UnityEngine;
    public class Flocking : MonoBehaviour
    {

        private Flocking[] bandada;

        public void Start()
        {
            bandada = FindObjectsOfType<Flocking>();
        }

        public Flocking[] GetArrayOfObjects()
        {
            return bandada;
        }

        public Agente GetAgente() 
        {
            return gameObject.GetComponent<Agente>();
        }

    }
}
