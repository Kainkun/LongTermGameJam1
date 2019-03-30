using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KainEnemy : MonoBehaviour
{
    public float speed = 1;
    public float distance = 1;
    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0,startPosition.y + Mathf.Sin(Time.time * speed) * distance, 0);
    }
}
