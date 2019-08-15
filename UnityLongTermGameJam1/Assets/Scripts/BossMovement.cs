using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float enterspeed;
    public float stopAtx;
    public float sinspeed;
    public float sinHeight;
    public float startY;
    Vector3 pos;

    void Start()
    {
        startY = transform.position.y;
    }
    
    void Update()
    {
        pos = transform.position;
        pos.y = startY + Mathf.Sin(Time.time * sinspeed) * sinHeight;
        if (transform.position.x > stopAtx)
            pos.x -= enterspeed * Time.deltaTime;

        transform.position = pos;
    }
}
