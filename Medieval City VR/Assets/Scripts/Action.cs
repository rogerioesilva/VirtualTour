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
    GRAB_FLOOR
};

public class Action
{
    public ActionLabel label = ActionLabel.NONE;
    public int priority = 50;

    public Action(ActionLabel label, int priority)
    {
        this.label = label;
        this.priority = priority;
    }
}
