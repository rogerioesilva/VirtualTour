using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorPOI : Sensor
{
    public string POIname;
    bool OnPOI = false;

    protected override void Start()
    {
        base.Start();
        OnPOI = false;
    }

    public void EnterPOI(string name)
    {
        OnPOI = POIname == name;
        if(OnPOI)
            Debug.Log("Enter POI: " + name);
    }

    public void ExitPOI(string name)
    {
        if(POIname == name)
        {
            OnPOI = false;
            Debug.Log("Exit POI: " + name);
        }
    }

    public override void Run()
    {
        base.Run();
        if(OnPOI)
        {
            ListOfPercepts.Add(new Percept(PerceptSource.VISUAL, "POI", POIname));
            //Debug.Log("On WP");
        }
        else
        {
            ListOfPercepts.Add(new Percept(PerceptSource.VISUAL, "POI", "outside"));
        }
    }
}
