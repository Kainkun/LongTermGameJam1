using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sineBob : MonoBehaviour
{
    float startY;
    public float height;
    public float speed;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y = startY + Mathf.Sin(Time.time * speed + offset) * height;
        transform.position = pos;
    }
}
