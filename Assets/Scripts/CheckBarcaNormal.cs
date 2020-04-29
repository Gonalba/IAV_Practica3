using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class CheckBarcaNormal : MonoBehaviour
{
    // posiciones de los offmeshlinks 
    public Transform[] positionsSOC;
    // bool que determina si está la barca o no en esta estancia
    public bool barcaSOC;
    // Tag de la barca 
    public string barcaTag;

    // FANTASMA
    // gameobjects que contienen los OffMeshLinks del Fantasma
    public GameObject GO_OMLFantasmaSOC;
    // componentes OffMeshLinks del Fantasma
    OffMeshLink[] OMLFantasmaSOC;

    // CANTANTE
    // gameobjects que contienen los OffMeshLinks del Fantasma
    public GameObject GO_OMLCantanteSOC;
    // componentes OffMeshLinks del Fantasma
    OffMeshLink[] OMLCantanteSOC;

    private void Awake()
    {
        OMLFantasmaSOC = GO_OMLFantasmaSOC.GetComponents<OffMeshLink>();
        isBidirectionalOMLFantasma(true);

        OMLCantanteSOC = GO_OMLCantanteSOC.GetComponents<OffMeshLink>();
        isBidirectionalOMLCantante(true);
    }


    private void OnTriggerExit(Collider other)
    {
        // comprueba si alguna barca ha salido
        if (other.CompareTag(barcaTag)) barcaSOC = false;
    }

    private void OnTriggerStay(Collider other)
    {
        // comprueba si alguna barca ha entrado
        if (other.CompareTag(barcaTag)) barcaSOC = true;

        if (other.CompareTag("Fantasma"))
        {   // si colisiona con el fantasma deja de ser bidireccional porque el fantasma ve si hay barca o no
            isBidirectionalOMLFantasma(false);
            // actualiza las posiciones de los offMeshLinks en funcion de si hay barca o no
            updateOMLPositionsFantasma(barcaSOC);
        }
        else if (other.CompareTag("Cantante"))
        {   // si colisiona con la cantante deja de ser bidireccional porque la cantante ve si hay barca o no
            isBidirectionalOMLCantante(false);
            // actualiza las posiciones de los offMeshLinks en funcion de si hay barca o no
            updateOMLPositionsCantante(barcaSOC);
        }
    }

    void updateOMLPositionsFantasma(bool barcaSOC)
    {        
        // en función de si está la barca o no actualiza las posiciones en un orden o en otro
        if (barcaSOC)
        {
            int indexSESN = 0;
            foreach (OffMeshLink item in OMLFantasmaSOC)
            {
                item.startTransform = positionsSOC[indexSESN++];
                item.endTransform = positionsSOC[indexSESN];
                item.UpdatePositions();
            }
        }
        else
        {
            int indexSESN = positionsSOC.Length - 1;
            foreach (OffMeshLink item in OMLFantasmaSOC)
            {
                item.startTransform = positionsSOC[indexSESN--];
                item.endTransform = positionsSOC[indexSESN];
                item.UpdatePositions();
            }
        }
    }

    void updateOMLPositionsCantante(bool barcaSOC)
    {   
        // en función de si está la barca o no actualiza las posiciones en un orden o en otro
        if (barcaSOC)
        {
            int indexSESN = 0;
            foreach (OffMeshLink item in OMLCantanteSOC)
            {
                item.startTransform = positionsSOC[indexSESN++];
                item.endTransform = positionsSOC[indexSESN];
                item.UpdatePositions();
            }
        }
        else
        {
            int indexSESN = positionsSOC.Length - 1;
            foreach (OffMeshLink item in OMLCantanteSOC)
            {
                item.startTransform = positionsSOC[indexSESN--];
                item.endTransform = positionsSOC[indexSESN];
                item.UpdatePositions();
            }
        }
    }

    // activa o desactiva la bidireccionalidad de los OffMeshLinks
    void isBidirectionalOMLFantasma(bool bi)
    {
        foreach (OffMeshLink item in OMLFantasmaSOC)
        {
            item.biDirectional = bi;
            item.UpdatePositions();
        }
    }

    // activa o desactiva la bidireccionalidad de los OffMeshLinks
    void isBidirectionalOMLCantante(bool bi)
    {
        foreach (OffMeshLink item in OMLCantanteSOC)
        {
            item.biDirectional = bi;
            item.UpdatePositions();
        }
    }
}
