using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PerceptType
{
    VISUAL,
    AUDITORY,
    PHYSIOLOGICAL
};

public class Percept 
{
    public PerceptType type = PerceptType.VISUAL;
    public string name;
    public bool value;

    public Percept(PerceptType type, string name, bool value)
    {
        this.type = type;
        this.name = name;
        this.value = value;
    }
}
