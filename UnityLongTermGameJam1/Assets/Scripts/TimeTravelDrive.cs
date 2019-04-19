using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravelDrive : MonoBehaviour
{
    public KeyCode activationKey;
    public bool cyberRealm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(activationKey))
        {
            FindObjectOfType<TimeTravelManager>().swapWorlds();
        }
    }
}
