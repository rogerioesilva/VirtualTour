using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Memory))]
[RequireComponent(typeof(BehaviorManager))]
public class GoHome : BehaviorLocomotion
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (isExecuting)
        {
            if (_navAgent.remainingDistance < 0.05f)
            {
                if(_renderer)
                    _renderer.material = gameObject.GetComponent<BehaviorManager>().TranspMat;
                _navAgent.speed = 0f;
                _AnimController.SetFloat("Speed", _navAgent.speed);
                isExecuting = false;
                HideThinkingBalloon();
            }
        }
    }

    override public bool Execute(Action action)
    {
        base.Execute(action);

        if (isExecuting)
            return false;

        if (action.label == ActionLabel.GO_HOME && gameObject.GetComponent<Memory>())
        {
            _navAgent.destination = gameObject.GetComponent<Memory>().refHomePOI.transform.position;
            _navAgent.speed = SpeedRange.y;
            _AnimController.SetFloat("Speed", _navAgent.speed);
            isExecuting = true;
            ShowThinkingBalloon(action.getName());
            return true;
        }

        return false;
    }
}
