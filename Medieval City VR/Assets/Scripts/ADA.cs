using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADA : MonoBehaviour
{
    Animator _AnimController;
    UnityEngine.AI.NavMeshAgent _navAgent;
    Vector3 targetPosition;
    float RestingTime;
    bool isResting = false;

    [SerializeField]
    Vector2 RestingRange = new Vector2(1.0f, 10.0f);
    [SerializeField]
    Vector2 SpeedRange = new Vector2(0.5f, 4.0f);

    void ChooseDestination()
    {
        targetPosition = new Vector3(Random.Range(-20.0f, 20.0f), 0.0f, Random.Range(-20.0f, 20.0f));
        _navAgent.destination = targetPosition;
    }

    void ChooseAction()
    {
        switch(Random.Range(1,4))
        {
            case 1:
                RestingTime = Random.Range(RestingRange.x, RestingRange.y);
                _navAgent.speed = 0.0f;
                isResting = true;
                break;
            case 2:
                ChooseDestination();
                _navAgent.speed = SpeedRange.x;
                isResting = false;
                break;
            case 3:
                ChooseDestination();
                _navAgent.speed = SpeedRange.y;
                isResting = false;
                break;
        }
        _AnimController.SetFloat("Speed", _navAgent.speed);
    }

    // Start is called before the first frame update
    void Start()
    {
        _AnimController = GetComponentInChildren<Animator>();
        _navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        ChooseAction();
    }

    // Update is called once per frame
    void Update()
    {
        if(isResting)
        {
            if (RestingTime > 0.0f)
            {
                RestingTime -= Time.deltaTime;
            }
            else
            {
                ChooseAction();
            }
        }
        else if(_navAgent.remainingDistance < 0.2f)
        {
            ChooseAction();
        }
    }
}
