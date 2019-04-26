using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleKainParallax : MonoBehaviour
{
    public float imageWidth;
    public float speed;

    GameObject bg1;
    GameObject bg2;

    // Start is called before the first frame update
    void Start()
    {
        bg1 = transform.GetChild(0).gameObject;
        bg2 = Instantiate(bg1,transform);
        bg2.transform.position += new Vector3(imageWidth/100, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x > -imageWidth / 100)
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
