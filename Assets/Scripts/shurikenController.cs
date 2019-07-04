using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class shurikenController : MonoBehaviour
{
    private float change_in_x, change_in_z;
    private Rigidbody rb;
    public float move_speed;


    public Vector2 startPos;
    public Vector2 direction;
    public bool directionChosen;

    private float sensitivity = 7f;

    public Sensitivity loadSens;


    


    // Used for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

         Sensitivity savedSens = new Sensitivity();

         savedSens.LoadSensitivity();

         sensitivity = 12-(4+savedSens.sensVar);

        Debug.Log("Sensitivity:" + sensitivity);

        
    }




    // Update is called once per frame
    private void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
       // pos.y = Mathf.Clamp01(pos.y);


        transform.position = Camera.main.ViewportToWorldPoint(pos);
        

        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

           // Debug.Log("ilk if e giriyor.");


            Vector3 touchPos = Camera.main.ScreenToViewportPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                startPos = touch.position;
                directionChosen = false;

            }

            else if (touch.phase == TouchPhase.Moved)
            {

                // direction = touch.position - startPos;
                direction = Input.touches[0].deltaPosition.normalized;
                move_speed = Input.touches[0].deltaPosition.magnitude / Input.touches[0].deltaTime;
                // rb.velocity = new Vector3(direction.x/25, rb.velocity.y, direction.y/25);
                transform.position = transform.position + new Vector3(direction.x/sensitivity , rb.velocity.y, direction.y/sensitivity);


            }

            else if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector3.zero;
               
            }

           
            
        }
    }

    
}
