using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    public float spinSpeed;

    void Start()
    {
        
    }
    
    void Update()
    {
        transform.localEulerAngles += new Vector3(0, 0, spinSpeed * Time.deltaTime);
    }
}
