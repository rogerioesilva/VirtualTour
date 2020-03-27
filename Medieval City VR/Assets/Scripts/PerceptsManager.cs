using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerceptsManager : MonoBehaviour
{
    public Text uiPercepts;
    public bool Debug = true;
    [SerializeField] Sensor[] ListOfSensors;
    List<Percept> ListOfPercepts;

    // Start is called before the first frame update
    void Start()
    {
        ListOfSensors = gameObject.GetComponents<Sensor>();
        ListOfPercepts = new List<Percept>();
    }

    // Update is called once per frame
    public void UpdatePercepts()
    {
        ListOfPercepts.Clear();
        foreach (Sensor sensor in ListOfSensors)
        {
            sensor.Run();
            if(sensor.hasPercepts())
                ListOfPercepts.AddRange(sensor.getPercepts());
        }
    }

    public void OnGUI()
    {
        if(Debug && uiPercepts)
        {
            string strPercepts = ListOfSensors.Length.ToString() + " = ";
            foreach (Percept percept in ListOfPercepts)
            {
                strPercepts += percept.getString() + " ";
            }
            uiPercepts.text = strPercepts;
        }
    }

    public Percept getPercept(string name)
    {
        foreach(Percept p in ListOfPercepts)
        {
            if (p.name == name)
                return p;
        }
        return null;
    }

    public int getNumOfPercepts()
    {
        return ListOfPercepts.Count;
    }
}
