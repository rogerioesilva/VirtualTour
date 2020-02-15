using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LocomotionState
{
    IDLE, WALKING, RUNNING
};

public class ADA : MonoBehaviour
{
    AnimationController _AnimController;
    LocomotionState locState = LocomotionState.IDLE;
    Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        _AnimController = GetComponent<AnimationController>();
        targetPosition = new Vector3(Random.Range());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
