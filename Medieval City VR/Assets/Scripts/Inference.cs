using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inference : MonoBehaviour
{
    protected List<Action> Actions;

    protected virtual void Start()
    {
        Actions = new List<Action>();
    }

    public abstract List<Action> Evaluate(List<Percept> Percepts);
}
