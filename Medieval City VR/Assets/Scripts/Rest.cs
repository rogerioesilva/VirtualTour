using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rest : BehaviorLocomotion
{
    public GameObject[] FlightsOfStairs;
    public GameObject InsideHouse = null;

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
            if (_navAgent.remainingDistance < 0.2f)
            {
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

        if (InsideHouse && action.label == ActionLabel.REST)
        {
            _navAgent.destination = InsideHouse.transform.position;
            _navAgent.speed = SpeedRange.x;
            _AnimController.SetFloat("Speed", _navAgent.speed);
            isExecuting = true;
            ShowThinkingBalloon(action.getName());
            return true;
        }

        return false;
    }
}
