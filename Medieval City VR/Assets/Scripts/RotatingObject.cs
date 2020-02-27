using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    [SerializeField] float RotationalSpeed = 5.0f;
    [SerializeField] Transform target = null;

    // Update is called once per frame
    void Update()
    {
        float axisH = -1 * Input.GetAxis("Horizontal");
        transform.RotateAround(target.position, Vector3.up, axisH * RotationalSpeed * Time.deltaTime);
    }
}
