using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class CherckBarcaSE : MonoBehaviour
{
    // posiciones de los offmeshlinks 
    public Transform[] positionsSEM;
    public Transform[] positionsSESN;

    // bool que determina si está la barca o no en esta estancia
    public bool barcaSEM;
    public bool barcaSESN;

    // FANTASMA
    // gameobjects que contienen los OffMeshLinks del Fantasma
    public GameObject GO_OMLFantasmaSEM;
    public GameObject GO_OMLFantasmaSESN;
    // componentes OffMeshLinks del Fantasma
    OffMeshLink[] OMLFantasmaSEM;
    OffMeshLink[] OMLFantasmaSESN;

    // CANTANTE
    // gameobjects que contienen los OffMeshLinks del Fantasma
    public GameObject GO_OMLCantanteSEM;
    public GameObject GO_OMLCantanteSESN;
    // componentes OffMeshLinks del Fantasma
    OffMeshLink[] OMLCantanteSEM;
    OffMeshLink[] OMLCantanteSESN;

    private void Awake()
    {
        OMLFantasmaSEM = GO_OMLFantasmaSEM.GetComponents<OffMeshLink>();
        OMLFantasmaSESN = GO_OMLFantasmaSESN.GetComponents<OffMeshLink>();
        isBidirectionalOMLFantasma(true);

        OMLCantanteSEM = GO_OMLCantanteSEM.GetComponents<OffMeshLink>();
        OMLCantanteSESN = GO_OMLCantanteSESN.GetComponents<OffMeshLink>();
        isBidirectionalOMLCantante(true);
    }


    private void OnTriggerExit(Collider other)
    {
        // comprueba si alguna barca ha salido
        if (other.CompareTag("BarcaSEM")) barcaSEM = false;
        if (other.CompareTag("BarcaSESN")) barcaSESN = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        // comprueba si alguna barca ha entrado
        if (other.CompareTag("BarcaSEM")) barcaSEM = true;
        if (other.CompareTag("BarcaSESN")) barcaSESN = true;

        if (other.CompareTag("Fantasma"))
        {   // si colisiona con el fantasma deja de ser bidireccional porque el fantasma ve si hay barca o no
            isBidirectionalOMLFantasma(false);
            // actualiza las posiciones de los offMeshLinks en funcion de si hay barca o no
            updateOMLPositionsFantasma(barcaSEM, barcaSESN);
        }
        else if (other.CompareTag("Cantante"))
        {   // si colisiona con la cantante deja de ser bidireccional porque la cantante ve si hay barca o no
            isBidirectionalOMLCantante(false);
            // actualiza las posiciones de los offMeshLinks en funcion de si hay barca o no
            updateOMLPositionsCantante(barcaSEM, barcaSESN);
        }
    }

    void updateOMLPositionsFantasma(bool barcaSEM, bool barcaSESN)
    {   // en función de si está la barca o no actualiza las posiciones en un orden o en otro
        if (barcaSEM)
        {
            int indexSEM = 0;
            foreach (OffMeshLink item in OMLFantasmaSEM)
            {
                item.startTransform = positionsSEM[indexSEM++];
                item.endTransform = positionsSEM[indexSEM];
                item.UpdatePositions();
            }
        }
        else
        {
            int indexSEM = positionsSEM.Length - 1;
            foreach (OffMeshLink item in OMLFantasmaSEM)
            {
                item.startTransform = positionsSEM[indexSEM--];
                item.endTransform = positionsSEM[indexSEM];
                item.UpdatePositions();
            }
        }

        // en función de si está la barca o no actualiza las posiciones en un orden o en otro
        if (barcaSESN)
        {
            int indexSESN = 0;
            foreach (OffMeshLink item in OMLFantasmaSESN)
            {
                item.startTransform = positionsSESN[indexSESN++];
                item.endTransform = positionsSEM[indexSESN];
                item.UpdatePositions();
            }
        }
        else
        {
            int indexSESN = positionsSESN.Length - 1;
            foreach (OffMeshLink item in OMLFantasmaSESN)
            {
                item.startTransform = positionsSESN[indexSESN--];
                item.endTransform = positionsSESN[indexSESN];
                item.UpdatePositions();
            }
        }
    }

    void updateOMLPositionsCantante(bool barcaSEM, bool barcaSESN)
    {   // en función de si está la barca o no actualiza las posiciones en un orden o en otro
        if (barcaSEM)
        {
            int indexSEM = 0;
            foreach (OffMeshLink item in OMLCantanteSEM)
            {
                item.startTransform = positionsSEM[indexSEM++];
                item.endTransform = positionsSEM[indexSEM];
                item.UpdatePositions();
            }
        }
        else
        {
            int indexSEM = positionsSEM.Length - 1;
            foreach (OffMeshLink item in OMLCantanteSEM)
            {
                item.startTransform = positionsSEM[indexSEM--];
                item.endTransform = positionsSEM[indexSEM];
                item.UpdatePositions();
            }
        }

        // en función de si está la barca o no actualiza las posiciones en un orden o en otro
        if (barcaSESN)
        {
            int indexSESN = 0;
            foreach (OffMeshLink item in OMLCantanteSESN)
            {
                item.startTransform = positionsSESN[indexSESN++];
                item.endTransform = positionsSESN[indexSESN];
                item.UpdatePositions();
            }
        }
        else
        {
            int indexSESN = positionsSESN.Length - 1;
            foreach (OffMeshLink item in OMLCantanteSESN)
            {
                item.startTransform = positionsSESN[indexSESN--];
                item.endTransform = positionsSESN[indexSESN];
                item.UpdatePositions();
            }
        }
    }

    // activa o desactiva la bidireccionalidad de los OffMeshLinks
    void isBidirectionalOMLFantasma(bool bi)
    {
        foreach (OffMeshLink item in OMLFantasmaSEM)
        {
            item.biDirectional = bi;
            item.UpdatePositions();
        }

        foreach (OffMeshLink item in OMLFantasmaSESN)
        {
            item.biDirectional = bi;
            item.UpdatePositions();
        }
    }

    // activa o desactiva la bidireccionalidad de los OffMeshLinks
    void isBidirectionalOMLCantante(bool bi)
    {
        foreach (OffMeshLink item in OMLCantanteSEM)
        {
            item.biDirectional = bi;
            item.UpdatePositions();
        }

        foreach (OffMeshLink item in OMLCantanteSESN)
        {
            item.biDirectional = bi;
            item.UpdatePositions();
        }
    }
}
