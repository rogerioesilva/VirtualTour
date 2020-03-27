using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Selection))]
public class BehaviorManager : MonoBehaviour
{
    [SerializeField] Behavior[] listOfBehaviors;
    string currentActionName = "";

    public Material OpaqueMat;
    public Material TranspMat;

    public Text uiPlan;

    // Start is called before the first frame update
    void Start()
    {
        listOfBehaviors = GetComponents<Behavior>();
    }

    void OnGUI()
    {
        if(uiPlan)
        {
            uiPlan.text = currentActionName;
        }
    }

    void FixedUpdate()
    {
        bool noPlan = true;
        foreach (Behavior behavior in listOfBehaviors)
        {
            if(behavior.BehaviorIsExecuting())
            {
                noPlan = false;
                break;
            }
        }
        if (noPlan)
            currentActionName = "";
    }

    public void Execute(Action selectedAction)
    {
        if (selectedAction != null)
        {
            foreach (Behavior behavior in listOfBehaviors)
            {
                if (behavior.Execute(selectedAction))
                {
                    currentActionName = selectedAction.getName();
                    break;
                }
            }
        }
    }

    public bool isExecutingPlan()
    {
        return currentActionName != "";
    }
}
