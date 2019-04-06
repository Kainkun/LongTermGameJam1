using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScriptKain : MonoBehaviour
{
    public float MoveSpeed;
    public float SinSpeed;
    public float SinWidth;

    public Vector3 goToPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        goToPosition.x += MoveSpeed * Time.deltaTime;
        goToPosition.y = Mathf.Sin(Time.time * SinSpeed) * SinWidth;

        transform.position = goToPosition;






        //transform.position += new Vector3(MoveSpeed * Time.deltaTime, Mathf.Sin(Time.time * SinSpeed) * SinWidth * Time.deltaTime, 0);
        
        
        
        //transform.position += new Vector3(MoveSpeed / 100, Mathf.Sin(Time.time * SinSpeed) * SinWidth / 100, 0);
    }

}
