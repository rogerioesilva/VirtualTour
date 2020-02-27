using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sensor : MonoBehaviour
{
    public List<Percept> ListOfPercepts;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        ListOfPercepts = new List<Percept>();
    }

    public abstract void Run();
}
