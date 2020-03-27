using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Memory))]
[RequireComponent(typeof(BehaviorManager))]
public class InferenceReactive : Inference
{
    protected override void Start()
    {
        base.Start();
    }

    public override List<Action> Evaluate(PerceptsManager pctMgr)
    {
        Actions.Clear();

        Percept pctSunlight = pctMgr.getPercept("sunlight");
        Percept pctPOI = pctMgr.getPercept("POI");

        if (pctSunlight != null && pctSunlight.bvalue)
        {
            if (!GetComponent<BehaviorManager>().isExecutingPlan())
            {
                Actions.Add(new Action(ActionLabel.WANDER));
                Actions.Add(new Action(ActionLabel.IDLE));
            }
        }
        else
            Actions.Add(new Action(ActionLabel.GO_HOME, 65, true));

        if(pctPOI != null)
        {
            if (gameObject.GetComponent<Memory>())
            {
                if (pctPOI.strvalue == gameObject.GetComponent<Memory>().refHomePOI.GetComponent<POI>().name)
                {
                    Actions.Add(new Action(ActionLabel.REST, 50, true));
                }
            }
        }

        return this.Actions;
    }
}
 