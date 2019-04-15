using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrittanyDash : MonoBehaviour
{
    private float dashTime;
    public float startDashTime;
    private int direction;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector3 vel = rb.velocity;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
