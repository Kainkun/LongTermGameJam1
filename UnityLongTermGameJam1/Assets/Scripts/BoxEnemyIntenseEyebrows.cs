using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BoxEnemyIntenseEyebrows : MonoBehaviour
{
    public Vector3 targetPosition; // declaring the Vector3 variable
   
    public float speed = 10; // declaring speed (fps) 

	// Start is called before the first frame update
	void Start()
	{
        Debug.Log("My goal is to get the sprite to move in the -x direction!");

        //targetPosition = transform.position; // This didn't work
        transform.position = new Vector3(10, 0); // putting the sprite at (10,0)
    }

	// Update is called once per frame
	void Update()
	{
        if (transform.position.x > 0) // if sprite position is greater than 0 in x-direction
        {
            targetPosition.x = -10; // target position will be -10 in x-direction
        }

         transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime); // Vector3 will move to target position
                                                                                                               // from orginal position based on change in time
                                                                                                               // between the current and last frame

        // transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed); // Without Time.deltaTime, the sprite moves
                                                                                                //in negative x-direction based on the declared "speed"
    }
}