using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingBoss : MonoBehaviour
{

    public SpriteRenderer[] fists;
    public SpriteRenderer head;
    public SpriteRenderer body;
    public SpriteRenderer armor;

    GameObject player;

    public bool[] canFire;

    public float fistTrackTime = 1;
    public float fistSpeed = 1;
    public float offScreenTime = 2;
    public float timeBetweenPunches = 3;

    int currFist = 0;
    // Start is called before the first frame update
    void Start()
    {
        postitions = new Vector3[fists.Length];
        canFire = new bool[fists.Length];
        player = GameObject.FindGameObjectWithTag("Player");

        for(int i = 0; i < fists.Length; i++){
            canFire[i] = true;
            postitions[i] = fists[i].transform.position;
        }

        StartCoroutine(Stage1());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3[] postitions;

    IEnumerator Stage1(){
        //Wait 5 seconds
        while(true){
            yield return new WaitForSecondsRealtime(timeBetweenPunches);
            StartCoroutine(fistFollow(currFist, fistTrackTime));
            yield return null;
            currFist = (currFist + 1) % fists.Length;
        }

    }

    IEnumerator fistFollow(int i, float time){
        
        if(!canFire[i]){
            yield break;
        }

        canFire[i] = false;

        while(time > 0){
            fists[i].transform.position = Vector3.Lerp(fists[i].transform.position, new Vector3(fists[i].transform.position.x, player.transform.position.y, 0), 9f * Time.deltaTime);
            time -= Time.deltaTime;
            yield return null;
        }
        StartCoroutine(punch(i));
        yield return null;
    }

    IEnumerator punch(int i){
        bool done = false;
        while(fists[i].isVisible && !done){
            fists[i].transform.Translate(Vector3.left * fistSpeed, Space.World);
            yield return null;
        }
        done = true;

        yield return new WaitForSeconds(offScreenTime);

        fists[i].transform.position = this.transform.position + Vector3.right * 30;
        
        //Retract Step

        while(Vector3.Distance(fists[i].transform.position, postitions[i]) > .5f){
            fists[i].transform.position = Vector3.Lerp(fists[i].transform.position, postitions[i], 15f * Time.deltaTime);
            yield return null;
        }

        canFire[i] = true;

        yield break;
    }
}
