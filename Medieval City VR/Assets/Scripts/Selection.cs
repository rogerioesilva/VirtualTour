using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InferenceManager))]
public abstract class Selection : MonoBehaviour
{
    protected InferenceManager _inference;
    public abstract Action ChooseOption();

    protected virtual void Start() 
    {
        _inference = gameObject.GetComponent<InferenceManager>();
    }
}
