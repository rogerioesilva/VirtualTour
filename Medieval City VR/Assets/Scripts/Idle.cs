using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BehaviorManager))]
public class Idle : BehaviorLocomotion
{
    public float IdleTime;
    public Vector2 IdleTimeRange = new Vector2(1.0f, 10.0f);

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if(isExecuting)
        {
            IdleTime -= Time.deltaTime;
            if (IdleTime <= 0.0f)
            {
                isExecuting = false;
            }
        }
    }

    override public bool Execute(Action action)
    {
        base.Execute(action);

        if (isExecuting)
            return false;

        if(action.label == ActionLabel.IDLE)
        {
            if (_renderer)
                _renderer.material = gameObject.GetComponent<BehaviorManager>().OpaqueMat;
            IdleTime = Random.Range(IdleTimeRange.x, IdleTimeRange.y);
            _navAgent.speed = 0.0f;
            _AnimController.SetFloat("Speed", _navAgent.speed);
            isExecuting = true;
            return true;
        }

        return false;
    }
}