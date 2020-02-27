using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Selection : MonoBehaviour
{
    public abstract Action ChooseOption(List<Action> ListOfPlausibleActions);
}
