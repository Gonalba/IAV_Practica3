using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private int currentStandPoint = 0;
    public GameObject[] standPoints;

    void Start()
    {
        transform.position = Vector3.Lerp(transform.position, standPoints[0].transform.position, 1 * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, standPoints[0].transform.rotation, 1 * Time.deltaTime);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, standPoints[currentStandPoint].transform.position, 1 * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, standPoints[currentStandPoint].transform.rotation, 1 * Time.deltaTime);
    }

    public void ChangeCameraStandPoint(int pos)
    {
        currentStandPoint = pos;
    }
}
