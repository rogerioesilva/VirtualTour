using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Behavior : MonoBehaviour
{
    protected Animator _AnimController;
    protected bool isExecuting;

    bool isThinking = false;

    protected virtual void Start()
    {
        _AnimController = GetComponentInChildren<Animator>();
        isExecuting = false;
    }

    protected void ShowThinkingBalloon(string actionName)
    {
        Transform childNode = null;

        for(int c = 0; c < transform.childCount; c++)
        {
            childNode = transform.GetChild(c);
            if (childNode.CompareTag("Thinking Balloon"))
            {
                for(int i = 0; i < childNode.childCount; i++)
                {
                    childNode.GetChild(i).gameObject.SetActive(childNode.GetChild(i).name == actionName);
                }
                childNode.gameObject.SetActive(true);
                isThinking = true;
            }
        }
    }

    protected void HideThinkingBalloon()
    {
        Transform childNode = null;

        for (int c = 0; c < transform.childCount; c++)
        {
            childNode = transform.GetChild(c);
            if (childNode.CompareTag("Thinking Balloon"))
            {
                childNode.gameObject.SetActive(false);
                isThinking = false;
            }
        }
    }

    public virtual bool Execute(Action action)
    {
        if (isThinking)
        {
            Transform childNode = null;

            for (int c = 0; c < transform.childCount; c++)
            {
                childNode = transform.GetChild(c);
                if (childNode.CompareTag("Thinking Balloon"))
                {
                    childNode.LookAt(GameObject.Find("Camera").transform.position, Vector3.up);
                    break;
                }
            }
        }
        return true;
    }

    public bool BehaviorIsExecuting()
    {
        return isExecuting;
    }
}
