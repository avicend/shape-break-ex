using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetection : MonoBehaviour
{
    private float width;
    private float height;
    private float depth;

    private bool debugged=false;

    public GameObject player;
    private float player_width;
    private float player_height;
    private float player_depth;

    private float collideDistance_x;
    private float collideDistance_y;
    private float collideDistance_z;

    private bool collided = false;

   

    // Start is called before the first frame update
    void Start()
    {
        width = GetComponent<MeshRenderer>().bounds.size.x;
        height = GetComponent<MeshRenderer>().bounds.size.y;
        depth = GetComponent<MeshRenderer>().bounds.size.z;

        player_width = player.GetComponent<MeshRenderer>().bounds.size.x;
        player_height = player.GetComponent<MeshRenderer>().bounds.size.y;
        player_depth = player.GetComponent<MeshRenderer>().bounds.size.z;

        collideDistance_x = ((player_width / 2) + (width / 2));
        collideDistance_y = ((player_height / 2) + (height / 2));
        collideDistance_z = ((player_depth / 2) + (depth / 2));

        
        

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = player.transform.position - transform.position;
        float distanceDelta = offset.sqrMagnitude;

        collisionDirection();

        if (gameObject.tag == "breakableCube")
        {
           


            if (distanceDelta <= collideDistance_x || distanceDelta <= collideDistance_y || distanceDelta <= collideDistance_z)
            {
                if (!debugged)
                {
                    Debug.Log("Collision detected!");
                    debugged = true;

                  
                }


                transform.position = transform.position + collisionDirection()*Time.deltaTime;
                transform.position = transform.position + new Vector3(0,100*Time.smoothDeltaTime,0);
                transform.Rotate(-player.transform.rotation.eulerAngles.x * Time.deltaTime, 
                                 -player.transform.rotation.eulerAngles.y * Time.deltaTime,
                                 -player.transform.rotation.eulerAngles.z * Time.deltaTime);
                collided = true;
                //Destroy(gameObject);
                StartCoroutine(WaitAndDestroy(2));


            }

            else
            {
                if (collided)
                {
                    transform.Rotate(-10 ,
                                     -player.transform.rotation.eulerAngles.y * Time.deltaTime,
                                     -10 );
                    transform.position = transform.position + new Vector3(collisionDirection().x/2, -10 * Time.deltaTime, collisionDirection().z/2);

                    
                    


                }
            }
        }
        else if (gameObject.tag == "unbreakableCube")
        {
            Debug.Log("game over");
        }

        
    }

    Vector3 collisionDirection()
    {
        Vector3 position_player = player.transform.position;
        Vector3 direction = (transform.position - player.transform.position ).normalized;
        Debug.DrawLine(position_player, position_player + direction * 10, Color.red, Mathf.Infinity);
        return direction;
    }

    private IEnumerator WaitAndDestroy(float second)
    {
        yield return new WaitForSeconds(second);
        Destroy(gameObject);
        
        
    }
}
