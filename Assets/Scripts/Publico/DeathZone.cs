using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Espectador")
        {
            other.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Espectador")
        {
            other.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
