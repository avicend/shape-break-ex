using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinShuriken : MonoBehaviour
{
    public float z_speed=7f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,z_speed,0 );
    }
}
