using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PerceptsManager))]
[RequireComponent(typeof(InferenceManager))]
[RequireComponent(typeof(Selection))]
[RequireComponent(typeof(BehaviorManager))]
public class ADA : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // 1 - PERCEPTION
        GetComponent<PerceptsManager>().UpdatePercepts();

        // 2 - INFERENCE
        GetComponent<InferenceManager>().Evaluate();

        // 3 - SELECTION
        Action selectedAction = gameObject.GetComponents<Selection>()[0].ChooseOption(); // if there are many selection modules use only the first one

        // 4 - BEHAVIOR
        gameObject.GetComponent<BehaviorManager>().Execute(selectedAction);
    }
}
