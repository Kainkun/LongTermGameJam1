using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingBoss : MonoBehaviour
{

    public SpriteRenderer[] fists;
    public SpriteRenderer head;
    public SpriteRenderer body;
    public SpriteRenderer armor;

    public float timeBetweenPunches = 1;
    public float fistTrackTime = 1;
    public float fistSpeed = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Stage1(){


    }

    IEnumerator punch(){
        yield return null;
    }
}
