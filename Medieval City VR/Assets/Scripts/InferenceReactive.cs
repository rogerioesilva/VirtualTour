using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InferenceReactive : Inference
{
    protected override void Start()
    {
        base.Start();
    }

    public override List<Action> Evaluate(List<Percept> Percepts)
    {
        this.Actions.Clear();

        foreach (Percept percept in Percepts)
        {
            switch(percept.type)
            {
                case PerceptType.VISUAL:
                    if(percept.name == "sunlight")
                    {
                        if(percept.value)
                            this.Actions.Add(new Action(Random.Range(0, 100) < 80 ? ActionLabel.WANDER : ActionLabel.REST, 50));
                        else
                            this.Actions.Add(new Action(ActionLabel.GO_HOME, 65));
                    }
                    break;
            }
        }

        return this.Actions;
    }
}
 