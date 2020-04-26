using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
    Se encarga del bucle de cantar-tener crisis
    Si está en el escenario, canta
    Si pasa X tiempo, se va a las bambalinas
    Al pasar Y tiempo, vuelve al escenario
    Este bucle se romperia por ser capturada, es decir CapturedState
*/

public class IdleState : MonoBehaviour
{
    public Transform[] posicionesAccion;
    NavMeshAgent nma;
    bool inAction = false;
    public float maxTimeAction = 8.0f;
    public float minTimeAction = 3.0f;
    float timeInAction = 0;
    float lastTime = 0;
    int actionID = 0;

    void Start()
    {
        // Se asocian las posiciones del navmesh al array de posiciones
        nma = GetComponent<NavMeshAgent>();
        nma.destination = posicionesAccion[actionID].position;
    }

    void Update()
    {
        // Si la posicion es la posicion target y aun no está haciendo la accion
        if (transform.position == posicionesAccion[actionID].position && !inAction)
        {
            // inicia la accion que dura un tiempo random dado un rango
            inAction = true;
            timeInAction = Random.Range(minTimeAction, maxTimeAction);
            lastTime = Time.time;
        }

        // Si ya está realizando la acción
        if (inAction)
        {
            float elapsedTime = Time.time - lastTime;
            // Se encarga de hacer que dure el tiempo estipulado
            if (elapsedTime > timeInAction)
            {
                inAction = false;
                // La siguiente accion a realizar se elige mediante un random
                actionID = Random.Range(0, posicionesAccion.Length);
                nma.destination = posicionesAccion[actionID].position;
            }
        }
    }
}
