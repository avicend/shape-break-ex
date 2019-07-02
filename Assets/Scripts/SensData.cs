using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SensData : MonoBehaviour
{
    public float sensitivity;

    public SensData(Sensitivity sens)
    {
        sensitivity = sens.sensVar;
    }
}
