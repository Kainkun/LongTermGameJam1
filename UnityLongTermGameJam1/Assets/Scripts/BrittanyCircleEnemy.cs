using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrittanyCircleEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D movement;
    public float movementForce = 10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.AddForce(new Vector3(movementForce*Time.deltaTime,0,0));
        
    }
}
