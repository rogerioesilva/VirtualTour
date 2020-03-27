using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PerceptsManager))]
public class InferenceManager : MonoBehaviour
{
    [SerializeField] Inference[] ListOfInferences;
    List<Action> ListOfPlausibleActions;
    PerceptsManager _perceptsMgr = null;

    public bool Debug = true;
    public Text uiActions;

    // Start is called before the first frame update
    void Start()
    {
        ListOfInferences = gameObject.GetComponents<Inference>();
        ListOfPlausibleActions = new List<Action>();
        _perceptsMgr = GetComponent<PerceptsManager>();
    }

    public void Evaluate()
    {
        ListOfPlausibleActions.Clear();
        foreach (Inference inference in ListOfInferences)
        {
            inference.Evaluate(_perceptsMgr);
            if(inference.hasActions())
                ListOfPlausibleActions.AddRange(inference.getActions());
        }
    }

    public void OnGUI()
    {
        if(Debug && uiActions)
        {
            string strActions = ListOfPlausibleActions.Count.ToString() + " = ";
            foreach (Action action in ListOfPlausibleActions)
            {
                strActions += action.getName() + " ";
            }
            uiActions.text = strActions;
        }
    }

    public List<Action> getPlausibleActions()
    {
        return ListOfPlausibleActions;
    }
}
