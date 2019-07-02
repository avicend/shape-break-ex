using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Sensitivity : MonoBehaviour
{
    public float sensVar;
    public Slider sensitivitySlider;
    public void SaveSensitivity()
    {

        sensVar = sensitivitySlider.value;
        SaveSystem.SaveSens(this);
        
    }

    public void LoadSensitivity()
    {
        SensData data = SaveSystem.LoadSens();

        

        sensVar = data.sensitivity;
        
    }

    
}
