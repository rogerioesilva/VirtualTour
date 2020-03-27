using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviorLocomotion : Behavior
{
    protected UnityEngine.AI.NavMeshAgent _navAgent;
    public Vector2 SpeedRange = new Vector2(0.5f, 4.0f);

    protected Renderer _renderer;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        _renderer = gameObject.GetComponentInChildren<Renderer>();
        if (!_renderer)
            Debug.Log("Renderer not found");
    }

    override public bool Execute(Action action)
    {
        base.Execute(action);
        return true;
    }
}
