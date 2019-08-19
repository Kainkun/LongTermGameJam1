using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryBody : MonoBehaviour
{
    AudioSource VictorySource;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().PlayDelayed(17.455f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
