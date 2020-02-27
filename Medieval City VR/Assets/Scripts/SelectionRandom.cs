using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionRandom : Selection
{
    public override Action ChooseOption(List<Action> ListOfPlausibleActions)
    {
        return ListOfPlausibleActions[Random.Range(0, ListOfPlausibleActions.Count)];
    }
}
