using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Behavior : MonoBehaviour
{
    protected Animator _AnimController;

    protected virtual void Start()
    {
        _AnimController = GetComponentInChildren<Animator>();
    }

    public abstract bool Execute(Action action);
}
