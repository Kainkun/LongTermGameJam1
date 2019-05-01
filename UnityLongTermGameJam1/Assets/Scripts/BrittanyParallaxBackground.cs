using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrittanyParallaxBackground : MonoBehaviour
{
    /*
     * @author Brittany Hughes
     * @Date April 26, 2019
     * Parralax background scrolling
     * */
    public float imageWidth;
    public float speed;

    GameObject backgroundOne;
    GameObject backgroundTwo;

    private void Start()
    {
        
    }
     void FixedUpdate()
    {
         transform.position += new Vector3(-speed * Time.deltaTime, 0);
        if(transform.position.x < 10)
        {
            transform.position = new Vector3(10, 0, 0);
        }
    }
     

}
