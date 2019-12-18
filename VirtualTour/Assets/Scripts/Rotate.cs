using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float RotationalSpeed = 5f;
    public Transform referencePoint;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(referencePoint.position, Vector3.up, RotationalSpeed * Time.deltaTime);
    }
}
