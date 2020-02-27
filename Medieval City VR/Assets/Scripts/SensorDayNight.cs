using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorDayNight : Sensor
{
    EnvManager _envManager;

    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        _envManager = GameObject.Find("Environment Manager").GetComponent<EnvManager>();
    }

    public override void Run()
    {
        ListOfPercepts.Add(new Percept(PerceptType.VISUAL, "sunlight", _envManager.isDay));
    }
}
