/*    
   Copyright (C) 2020 Grupo 1
   Martín Amechazurra Falagán
   Gonzalo Alba Durán
   Nuria Bango Iglesias
   Marcos Llinares Montes


   Componente parte de la estructura de mensajes
   El Emisor es capaz de enviar mensajes a los observadores
*/

namespace UCM.IAV.Movimiento
{

    using UnityEngine;
    public enum MENSAJE_ID { LAMP_DOWN, LAMP_UP };
    public class Emisor : MonoBehaviour
    {
        public Observador[] observadores;

        // Start is called before the first frame update
        public void Start()
        {
            // cogemos todos los observadores de la escena
            observadores = Object.FindObjectsOfType<Observador>();
        }

        public void EnviarMensaje(MENSAJE_ID id)
        {
            for (int i = 0; i < observadores.Length; i++)
            {
                observadores[i].RecibirMensaje(id);
            }
        }

    }
}
