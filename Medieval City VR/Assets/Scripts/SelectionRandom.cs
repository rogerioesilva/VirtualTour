using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BehaviorManager))]
public class SelectionRandom : Selection
{
    protected override void Start()
    {
        base.Start();
    }

    public override Action ChooseOption()
    {
        if(GetComponent<BehaviorManager>().isExecutingPlan())
        {
            return null;
        }
        
        int choice = Random.Range(0, _inference.getPlausibleActions().Count);
        //Debug.Log("Selecting among " + _inference.getPlausibleActions().Count.ToString() + " possibilities. Chosing: "+choice.ToString());
        return _inference.getPlausibleActions()[choice];
    }
}
