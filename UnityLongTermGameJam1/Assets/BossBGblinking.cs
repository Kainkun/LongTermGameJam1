using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBGblinking : MonoBehaviour
{
    public GameObject darkBG;
    public GameObject bg;
    public bool swapped;

    public float currentTime;
    public float timeToSwap;

    public Color fadeDarkC;
    public bool fading;

    // Start is called before the first frame update
    void Start()
    {
        fadeDarkC = darkBG.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > timeToSwap)
        {
            timeToSwap = Random.Range(8f, 10f);
            StartCoroutine(BlinkSwap());
            currentTime = 0;
        }


        if (fading && darkBG.GetComponent<SpriteRenderer>().color.a < 0.75f)
        {
            fadeDarkC.a += Time.deltaTime *3;
            darkBG.GetComponent<SpriteRenderer>().color = fadeDarkC;
        }
        if(!fading && darkBG.GetComponent<SpriteRenderer>().color.a > 0)
        { 
            fadeDarkC.a -= Time.deltaTime *3;
            darkBG.GetComponent<SpriteRenderer>().color = fadeDarkC;
        }
        
    }

    void swap()
    {

        if (!swapped)
        {
            swapped = true;
            bg.SetActive(false);
        }
        else
        {
            swapped = false;
            bg.SetActive(true);
        }
    }
    

    IEnumerator BlinkSwap()
    {
        fading = true;
        yield return new WaitForSeconds(0.2f);

        for (int i = 0; i < 9; i++)
        {
            swap();
            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(0.2f);
        fading = false;
    }
}
