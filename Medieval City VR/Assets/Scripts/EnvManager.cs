  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvManager : MonoBehaviour
{
    public GameObject[] listOfLightSources;
    float TimeOfDay;

    public float DayDuration = 60.0f;
    public bool isDay = true;

    // Start is called before the first frame update
    void Start()
    {
        TimeOfDay = 0.0f;
    }

    public void ToggleDayNight()
    {
        isDay = !isDay;
        this.SetDaylight();
    }

    // Update is called once per frame
    void Update()
    {
        TimeOfDay += Time.deltaTime;
        if (TimeOfDay >= DayDuration)
        {
            TimeOfDay = 0.0f;
            ToggleDayNight();
        }
    }

    void SetDaylight()
    {
        foreach(GameObject go in listOfLightSources)
        {
            go.SetActive(isDay);
        }
    }
}
