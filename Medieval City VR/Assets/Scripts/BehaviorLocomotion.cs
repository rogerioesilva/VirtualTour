using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorLocomotion : Behavior
{
    UnityEngine.AI.NavMeshAgent _navAgent;
    Vector3 targetPosition;
    float RestingTime;
    bool isResting = false;
    bool atHome = true;

    public Vector2 RestingRange = new Vector2(1.0f, 10.0f);
    public Vector2 SpeedRange = new Vector2(0.5f, 4.0f);
    public string targetName = "";

    Action currentAction = null;

    void ChooseDestination(string targetName)
    {
        if (targetName == "")
            targetPosition = new Vector3(Random.Range(-20.0f, 20.0f), 0.0f, Random.Range(-20.0f, 20.0f));
        else if(targetName == "home")
            targetPosition = GetComponent<Memory>().HomeRef.transform.position;
        _navAgent.destination = targetPosition;
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    override public bool Execute(Action action)
    {
        if (currentAction != null && currentAction.priority >= action.priority)
            return false;

        currentAction = action;

        bool acionRecognized = false;
        switch(currentAction.label)
        {
            case ActionLabel.REST:
                Debug.Log("REST");
                RestingTime = Random.Range(RestingRange.x, RestingRange.y);
                _navAgent.speed = 0.0f;
                _AnimController.SetFloat("Speed", _navAgent.speed);
                acionRecognized = true;
                isResting = true;
                break;

            case ActionLabel.WANDER:
                Debug.Log("WANDER");
                ChooseDestination("");
                _navAgent.speed = Random.Range(0, 11) % 2 == 0 ? SpeedRange.x : SpeedRange.y;
                _AnimController.SetFloat("Speed", _navAgent.speed);
                acionRecognized = true;
                isResting = false;
                break;

            case ActionLabel.GO_HOME:
                Debug.Log("Its dark here!");
                ChooseDestination("home");
                _navAgent.speed = SpeedRange.y;
                _AnimController.SetFloat("Speed", _navAgent.speed);
                acionRecognized = true;
                isResting = false;
                break;
        }
        return acionRecognized;
    }

    void Update()
    {
        if(currentAction != null)
        {
            if(isResting)
            {
                RestingTime -= Time.deltaTime;
                if(RestingTime <= 0.0f)
                {
                    isResting = false;
                    currentAction = null;
                }
            }
            else if (_navAgent.remainingDistance < 0.2f)
            {
                currentAction = null;
                Debug.Log("On WP");
            }
        }
    }
}
