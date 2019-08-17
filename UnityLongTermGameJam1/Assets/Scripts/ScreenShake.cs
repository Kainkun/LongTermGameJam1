using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    Camera cam;
    public static ScreenShake instance;
    // Start is called before the first frame update
    void Start(){
        cam = this.GetComponent<Camera>();
        instance = this;
        initpos = this.transform.position;
    }


    public void shake(float duration, float intensity, float magnitude){
        StartCoroutine(camShake(duration, intensity, magnitude));
    }

    bool currShaking = false;
    Vector3 initpos;
    IEnumerator camShake(float duration, float intensity, float magnitude){
        if(!currShaking)
            initpos = this.transform.localPosition;

        currShaking = true;

        float randX = Random.Range(0, 100);
        float randY = Random.Range(0, 100);
        
        while(duration > 0){
            float x = Mathf.PerlinNoise(duration * intensity + randX, randY) * magnitude;
            float y = Mathf.PerlinNoise(duration * intensity - randX, randY) * magnitude;
            this.transform.localPosition = initpos + new Vector3(x, y, 0);

            duration -= Time.deltaTime;
            yield return null;
        }

        this.transform.localPosition = initpos;

        currShaking = false;
        yield return null;
    }
}
