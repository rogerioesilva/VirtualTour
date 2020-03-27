using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sensor : MonoBehaviour
{
    protected List<Percept> ListOfPercepts;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        ListOfPercepts = new List<Percept>();
    }

    public virtual void Run()
    {
        ListOfPercepts.Clear();
    }

    public List<Percept> getPercepts()
    {
        return ListOfPercepts;
    }

    public bool hasPercepts()
    {
        return ListOfPercepts.Count > 0;
    }
}
