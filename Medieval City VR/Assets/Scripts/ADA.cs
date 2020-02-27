using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADA : MonoBehaviour
{
    public Sensor[] ListOfSensors;
    public Inference[] ListOfInferences;
    public Behavior[] ListOfBehaviors;
    
    List<Percept> ListOfPercepts;
    List<Action> ListOfPlausibleActions;

    // Start is called before the first frame update
    void Start()
    {
        ListOfSensors = gameObject.GetComponents<Sensor>();
        ListOfInferences = gameObject.GetComponents<Inference>();
        ListOfBehaviors = gameObject.GetComponents<Behavior>();
        ListOfPercepts = new List<Percept>();
        ListOfPlausibleActions = new List<Action>();
    }

    // Update is called once per frame
    void Update()
    {
        // 1 - PERCEPTION
        ListOfPercepts.Clear();
        foreach(Sensor sensor in ListOfSensors)
        {
            sensor.Run();
            ListOfPercepts.AddRange(sensor.ListOfPercepts);
        }

        // 2 - INFERENCE
        ListOfPlausibleActions.Clear();
        foreach(Inference inference in ListOfInferences)
        {
            ListOfPlausibleActions.AddRange(inference.Evaluate(ListOfPercepts));
        }

        // 3 - SELECTION
        Action selectedAction = gameObject.GetComponents<Selection>()[0].ChooseOption(ListOfPlausibleActions); // if there are many selection modules use the first one

        // 4 - BEHAVIOR
        foreach(Behavior behavior in ListOfBehaviors)
        {
            if (behavior.Execute(selectedAction))
                break;
        }
    }
}
