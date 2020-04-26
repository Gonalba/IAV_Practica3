﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VagonBehaivour : MonoBehaviour
{
    public Transform posicionInicial1;
    public Transform posicionInicial2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Vizconde"))
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
            transform.parent = null;
            transform.position = other.gameObject.GetComponentsInChildren<Transform>()[1].position;
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
