using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POI : MonoBehaviour
{
    public string name;
    public string owner;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ADA"))
            if(other.gameObject.GetComponent<Memory>().name == name)
            {
                if(other.gameObject.GetComponent<SensorPOI>())
                {
                    other.gameObject.GetComponent<SensorPOI>().EnterPOI(name);
                }
            }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ADA"))
            if (other.gameObject.GetComponent<Memory>().name == name)
            {
                if (other.gameObject.GetComponent<SensorPOI>())
                {
                    other.gameObject.GetComponent<SensorPOI>().ExitPOI(name);
                }
            }
    }
}
