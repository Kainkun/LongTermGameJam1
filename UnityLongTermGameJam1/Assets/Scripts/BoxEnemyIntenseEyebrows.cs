using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BoxEnemyIntenseEyebrows : MonoBehaviour
{
    public float MoveSpeed; // declaring variables
    public float SinSpeed;
    public float SinWidth;

    Vector3 startPosition;
    Vector3 goToPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position; // putting the position transform into startPosition vector
        goToPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        goToPosition.x -= MoveSpeed * Time.deltaTime; // Makes sprite move from right to left
        goToPosition.y = startPosition.y + Mathf.Sin(Time.time * SinSpeed) * SinWidth; 
        // makes sprite wiggle up and down

        transform.position = goToPosition; // u need this
        

    }
}