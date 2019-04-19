using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{   int health = 10
    void speak()

    {
        Debug.Log("In Bulgaria, nodding means 'no' and a head shake means 'yes'");
        health = health - 1;
        return health;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        speak();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}
