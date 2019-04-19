using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScriptKainBlink : MonoBehaviour
{
    public Vector3 velocity; //Storage for player's velocity
    Vector3 previous; //position of player in previous frame

    public Vector3 TeleportVector; //The vector to add to the player position when blinking

    public float TeleportDistance; //The amount to multiply with the player direction

    void Start()
    {
        
    }


    void Update()
    {
        velocity = (transform.position - previous) / Time.deltaTime; //get diffrence of current player position and previous position, which gives a velocity
        velocity.Normalize(); // Normalize the players velocity to get a direction without magnitude
        previous = transform.position; //get the current position which will be used for the next frames previous position

        TeleportVector = velocity * TeleportDistance; //multiply direction with custom magnitude which will be the distance to teleport

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += TeleportVector; //add the teleport vector to the player
        }
    }

}
