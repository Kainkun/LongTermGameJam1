using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBullet : MonoBehaviour{

    public Vector3 direction;
    public float speed;

    public float lifeTime = 20; //Seconds

    void Start(){
        transform.parent = GameObject.FindGameObjectWithTag("BulletsContainer").transform;
        StartCoroutine(killMeAt(lifeTime));
    }

    void Update(){
        this.transform.Translate(direction * speed * Time.deltaTime);
        
    }

    IEnumerator killMeAt(float time) {
        yield return new WaitForSeconds(time);
        DestroyImmediate(this.gameObject);

    }
}
