using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PerceptSource
{
    VISUAL,
    AUDITORY,
    PHYSIOLOGICAL,
    INNER_STATE
};

public enum PerceptType
{
    BOOL,
    NUMERIC,
    STRING
};

public class Percept 
{
    public PerceptType type = PerceptType.BOOL;
    public PerceptSource source = PerceptSource.VISUAL;
    public string name;
    public bool bvalue;
    public string strvalue;
    public float nvalue;

    public Percept(PerceptSource source, string name, bool value)
    {
        this.type = PerceptType.BOOL;
        this.source = source;
        this.name = name;
        this.bvalue = value;
    }

    public Percept(PerceptSource source, string name, string value)
    {
        this.type = PerceptType.STRING;
        this.source = source;
        this.name = name;
        this.strvalue = value;
    }

    public Percept(PerceptSource source, string name, float value)
    {
        this.source = source;
        this.type = PerceptType.NUMERIC;
        this.name = name;
        this.nvalue = value;
    }

    public string getString()
    {
        string result = "";

        switch(source)
        {
            case PerceptSource.VISUAL: result = "VISUAL("; break;
            case PerceptSource.AUDITORY: result = "AUDITORY("; break;
            case PerceptSource.PHYSIOLOGICAL: result = "PHYSIOLOGICAL("; break;
            case PerceptSource.INNER_STATE: result = "INNER_STATE("; break;
        }
        
        result += name + ", ";
        
        switch(type)
        {
            case PerceptType.BOOL: result += bvalue ? "on" : "off"; break;
            case PerceptType.NUMERIC: result += nvalue.ToString(); break;
            case PerceptType.STRING: result += strvalue; break;
        }

        return result + ")";
    }
}
