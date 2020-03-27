using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionLabel
{
    NONE,
    IDLE,
    WANDER,
    GO_HOME,
    GO_TO_SHELTER,
    REST,
    EAT,
    DRINK,
    GRAB_FROM_FLOOR
};

public class Action
{
    public ActionLabel label = ActionLabel.NONE;
    public int priority = 50;
    public bool showThinking = false;

    public Action(ActionLabel label, int priority = 50, bool isThinking = false)
    {
        this.label = label;
        this.priority = priority;
        showThinking = isThinking;
    }

    public string getName()
    {
        string name = "UNDEFINED";
        switch(label)
        {
            case ActionLabel.NONE: name = "NONE"; break;
            case ActionLabel.IDLE: name = "IDLE"; break;
            case ActionLabel.WANDER: name = "WANDER"; break;
            case ActionLabel.GO_HOME: name = "GO_HOME"; break;
            case ActionLabel.GO_TO_SHELTER: name = "GO_TO_SHELTER"; break;
            case ActionLabel.REST: name = "REST"; break;
            case ActionLabel.EAT: name = "EAT"; break;
            case ActionLabel.DRINK: name = "DRINK"; break;
            case ActionLabel.GRAB_FROM_FLOOR: name = "GRAB_FROM_FLOOR"; break;
        }
        return name;
    }
}
