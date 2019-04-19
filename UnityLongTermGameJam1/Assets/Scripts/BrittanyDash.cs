using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrittanyDash : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 previous; //Vector3 is X Y Z position 
    public float distance; 
                            
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        velocity = (transform.position - previous) / Time.deltaTime; //get diffrence of current player position and previous position(last frame), which gives a velocity
        velocity.Normalize(); // Normalize the players velocity to get a direction without magnitude
        previous = transform.position; //get the current position which will be used for the next frames previous position

        velocity *= distance; // We are multiplying the normalized circle with distance to determine how far the object teleports and in what direction

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // print("Pressing key");
            transform.position += velocity; //X , Y , Z
        }
        
    }

}
