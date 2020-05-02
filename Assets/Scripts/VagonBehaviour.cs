using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VagonBehaviour : MonoBehaviour
{
    public Transform posicionInicial1;
    public Transform posicionInicial2;
    private Transform parentInicial;

    private void Awake()
    {
        parentInicial = transform.parent;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("Vizconde") || other.gameObject.CompareTag("Fantasma")
            || other.gameObject.CompareTag("Cantante")) && other.transform.parent == null)
        {
            transform.parent = other.transform;
            transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (other.gameObject.CompareTag("Pared"))
        {
            other.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
        else if (other.gameObject.CompareTag("Limite"))
        {
            transform.parent = parentInicial;
            transform.position = other.gameObject.GetComponentsInChildren<Transform>()[1].position;

            OffMeshLink[] arrayOML = parentInicial.GetComponentsInParent<OffMeshLink>();
            foreach (OffMeshLink item in arrayOML)
            {
                Transform aux = item.startTransform;
                item.startTransform = item.endTransform;
                item.endTransform = aux;
                item.UpdatePositions();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pared"))
        {
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
