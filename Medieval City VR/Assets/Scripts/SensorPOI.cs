using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorPOI : Sensor
{
    public string name;
    bool OnPOI = false;

    protected override void Start()
    {
        base.Start();
        this.OnPOI = false;
    }

    public void EnterPOI(string name)
    {
        OnPOI = this.name == name;
    }

    public void ExitPOI(string name)
    {
        if(this.name == name)
            OnPOI = false;
    }

    public override void Run()
    {
        ListOfPercepts.Add(new Percept(PerceptType.VISUAL, "POI", this.OnPOI));
    }
}
