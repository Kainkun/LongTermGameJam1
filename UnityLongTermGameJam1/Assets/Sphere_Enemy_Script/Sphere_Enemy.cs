using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere_Enemy : MonoBehaviour
{
    public Rigidbody2D rigidb;
    public float movementForce = 10;
     

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        rigidb.AddForce(movementForce * Time.deltaTime , 0, 0);
    }
}
 