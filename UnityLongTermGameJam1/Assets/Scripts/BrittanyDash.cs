﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrittanyDash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // print("Pressing key");
            transform.position += new Vector3(-5, 0, 0); //X , Y , Z
        }
        
    }

}
