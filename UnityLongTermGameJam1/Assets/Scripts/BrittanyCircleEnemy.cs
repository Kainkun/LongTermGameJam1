using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrittanyCircleEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D movement; // empty variable 
    public float movementForce = 10;
    
    void Start()
    {
        movement = GetComponent<Rigidbody2D>(); //goes to the game object and gets the rigid body component and puts into movement container
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.AddForce(new Vector3 (movementForce*Time.deltaTime,0,0));
        
    }
}
