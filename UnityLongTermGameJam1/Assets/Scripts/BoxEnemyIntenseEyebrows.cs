using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BoxEnemyIntenseEyebrows : MonoBehaviour
{
    public Vector3 targetPosition; // declaring the Vector3 variable
    //public float speed = 1;
    //public float distance = 1;

	// Start is called before the first frame update
	void Start()
	{
        Debug.Log("My goal is to get the sprite to move in the -x direction!");

        targetPosition = transform.position;
        transform.position = new Vector3(0, 0); // putting the sprite at (0,0)
    }

	// Update is called once per frame
	void Update()
	{
       // transform.position = new Vector3(startPosition.x*Time.deltaTime*speed*distance, 0);
	}
}