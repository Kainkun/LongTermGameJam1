using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float speed = 1;
    public float sinHeight = 1;
    public float sinSpeed = 1;
    Vector3 move;

    void Start()
    {
        
    }


    void Update()
    {
        move = Vector3.zero;
        move.x -= speed * Time.deltaTime;
        move.y = Mathf.Sin(Time.time * sinSpeed) * sinHeight;
        transform.position += move;
    }
}
