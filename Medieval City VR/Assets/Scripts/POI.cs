using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Memory))]
public abstract class POI : MonoBehaviour
{
    public string POIname;
    public string owner;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ADA"))
            if(other.gameObject.GetComponent<Memory>().ADAname == owner)
            {
                if(other.gameObject.GetComponent<SensorPOI>())
                {
                    //Debug.Log(owner + " is at " + POIname);
                    other.gameObject.GetComponent<SensorPOI>().EnterPOI(POIname);
                }
            }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ADA"))
            if (other.gameObject.GetComponent<Memory>().ADAname == owner)
            {
                if (other.gameObject.GetComponent<SensorPOI>())
                {
                    //Debug.Log(owner + " left " + POIname);
                    other.gameObject.GetComponent<SensorPOI>().ExitPOI(POIname);
                }
            }
    }
}
