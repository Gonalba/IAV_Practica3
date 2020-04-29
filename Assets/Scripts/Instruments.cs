using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruments : MonoBehaviour
{
    private enum State { FIXED, BROKEN};

    State currentState = State.FIXED;

    // Start is called before the first frame update
    void Start()
    {
        currentState = State.FIXED;
        GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void breakInstruments()
    {
        currentState = State.BROKEN;
        GetComponent<BoxCollider>().enabled = true;
    }

    public void fixInstruments() {
        currentState = State.FIXED;
        GetComponent<BoxCollider>().enabled = false;
    }

    public bool isFixed()
    {
        return currentState == State.FIXED;
        Debug.Log("ARREGLAO");
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Vizconde" && Input.GetKeyDown("e") && currentState == State.FIXED)
        {
            breakInstruments();
            Debug.Log("ROTOS");
        }
    }
}
