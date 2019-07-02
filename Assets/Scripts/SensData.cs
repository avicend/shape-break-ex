using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SensData
{
    public float sensitivity;

    public SensData(Sensitivity sens)
    {
        sensitivity = sens.sensVar;
    }
}
