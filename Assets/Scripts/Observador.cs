/*    
   Copyright (C) 2020 Grupo 1
   Martín Amechazurra Falagán
   Gonzalo Alba Durán
   Nuria Bango Iglesias
   Marcos Llinares Montes

   Componente parte de la estructura de mensajes
   El Observador es capaz de recibir mensajes del emisor
*/

namespace UCM.IAV.Movimiento
{
    using UnityEngine;

    public class Observador : MonoBehaviour
    {
        // Hay dos tipos de observadores en la práctica: el perro y las ratas

        public void RecibirMensaje(MENSAJE_ID id)
        {
            if (id == MENSAJE_ID.LAMP_DOWN)
            {
                if (gameObject.CompareTag("Espectador"))
                {
                    GetComponent<Espectador>().lampDown();
                }
            }
            else if (id == MENSAJE_ID.LAMP_UP)
            {
                if (gameObject.CompareTag("Espectador"))
                {
                    GetComponent<Espectador>().lampUp();
                }
            }
        }
    }
}