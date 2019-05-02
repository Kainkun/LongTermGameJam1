﻿using System.Collections;
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
    public float bounds;

    GameObject backgroundOne;
    GameObject backgroundTwo;

    private void Start()
    {
        
    }
     void FixedUpdate()
    {
        bounds = imageWidth / 100;
        transform.position += new Vector3(-speed * Time.deltaTime, 0);
        if(transform.position.x < -bounds )
        {
            transform.position = new Vector3(1, 0, 0);
        }
    }
     

}