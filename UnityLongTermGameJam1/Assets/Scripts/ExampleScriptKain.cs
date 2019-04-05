using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScriptKain : MonoBehaviour
{
    public float MoveSpeed;
    public float SinSpeed;
    public float SinWidth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(MoveSpeed / 100, Mathf.Sin(Time.time * SinSpeed) * SinWidth / 100, 0);
    }

}
