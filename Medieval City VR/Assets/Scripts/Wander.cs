using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BehaviorManager))]
public class Wander : BehaviorLocomotion
{
    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        if(isExecuting)
        {
            if (_navAgent.remainingDistance < 0.2f)
            {
                isExecuting = false;
            }
        }
    }

    // Update is called once per frame
    public override bool Execute(Action action)
    {
        base.Execute(action);

        if (isExecuting)
            return false;

        if (action.label == ActionLabel.WANDER)
        {
            if (_renderer)
                _renderer.material = gameObject.GetComponent<BehaviorManager>().OpaqueMat;
            _navAgent.destination = new Vector3(Random.Range(-20.0f, 20.0f), 0.0f, Random.Range(-20.0f, 20.0f));
            _navAgent.speed = Random.Range(0, 11) % 2 == 0 ? SpeedRange.x : SpeedRange.y;
            _AnimController.SetFloat("Speed", _navAgent.speed);
            isExecuting = true;
            return true;
        }

        return false;
    }
}
