using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Sabe en que estado deberia estar la cantante
    Se encarga de poder "ser cogida" por el fantasma con un bool por ejemplo
    Se encarga de poder "ser animada" por el vizconde
    
    Deberia desactivar el componente necesario, dependiendo de si está el bucle "idle"
    o ha sido capturada
 */

public class SingerManager : MonoBehaviour
{
    // El vizconde ha animado a la cantante true/false
    public bool cheered = false;

    private void Start()
    {
        this.gameObject.GetComponent<IdleState>().enabled = true;
        this.gameObject.GetComponent<CapturedState>().enabled = false;
    }


    // Metodo que se llamará desde el input asociado al vizconde
    public bool IsCheeredUp(bool cheer)
    {
        cheered = cheer;
        return cheered;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si el Vizconde entra en colision y la anima, el idleState se activa
        if (other.gameObject.CompareTag("Vizconde") && cheered)
        {
            this.gameObject.GetComponent<IdleState>().enabled = true;
        }
        // Si el fantasma entra en colision, deja de actuar por si sola y sigue al fantasma
        else if (other.gameObject.CompareTag("Fanstasma"))
        {
            this.gameObject.GetComponent<IdleState>().enabled = false;
            this.gameObject.GetComponent<CapturedState>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Cuando el fantasma la suelta se queda quieta
        if (other.gameObject.CompareTag("Fanstasma"))
        {
            this.gameObject.GetComponent<CapturedState>().enabled = false;
        }
    }
}
