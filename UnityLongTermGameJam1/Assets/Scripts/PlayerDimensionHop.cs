using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDimensionHop : MonoBehaviour
{
    GameObject player;
    GameObject spriteObj;
    GameObject gunSpriteObj;
    GameObject gunObj;

    public bool hopIn;
    public bool hopOut;

    public bool traveling;
    public bool returnRot;

    bool decreaseScore;
    

    void Start()
    {
        

        player = GameObject.FindGameObjectWithTag("Player");
        spriteObj = player.transform.GetChild(0).gameObject;
        gunObj = player.transform.GetChild(1).gameObject;
        gunSpriteObj = player.transform.GetChild(1).GetChild(0).gameObject;
        HopIn();
    }

    void Update()
    {
        if (decreaseScore && Score.ScoreScript.getPrevScore() < Score.ScoreScript.getScore())
        {
            Score.ScoreScript.SubScore(3);
        }

        if (player != null)
        {
            if (hopIn)
            {
                hopIn = false;
                HopIn();
            }

            if (hopOut)
            {
                hopOut = false;
                HopOut();
            }

            if (returnRot)
            {
                player.transform.eulerAngles += player.transform.eulerAngles / -10;
            }

            if (traveling)
            {

                player.transform.eulerAngles += new Vector3(0, (0.5f - Mathf.PerlinNoise(0, Time.time * 4)) * 20, (0.5f - Mathf.PerlinNoise(Time.time * 4, 0)) * 20);
            }
        }
    }

    public void HopIn()
    {
        StartCoroutine(HopInAnimation());
    }

    public void HopOut()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<BoxCollider2D>().enabled = false;
        player.GetComponent<PlayerHealth>().enabled = false;
        player.GetComponent<WeaponShooter>().enabled = false;

        StartCoroutine(HopOutAnimation());
    }

    IEnumerator HopInAnimation()
    {
        decreaseScore = true;
        yield return new WaitForSeconds(1);

        spriteObj.SetActive(true);
        gunObj.SetActive(true);
        gunSpriteObj.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 1);

        traveling = true;
        StartCoroutine(BlinkingWhileTravel());
        yield return new WaitForSeconds(1f);
        traveling = false;

        returnRot = true;
        yield return new WaitForSeconds(0.5f);
        traveling = false;


        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        player.GetComponent<PlayerHealth>().enabled = true;
        player.GetComponent<WeaponShooter>().enabled = true;

        decreaseScore = false;
        Score.ScoreScript.setScore(Score.ScoreScript.getPrevScore());
    }

    IEnumerator HopOutAnimation()
    {
        traveling = true;

        StartCoroutine(BlinkingWhileTravel());

        yield return new WaitForSeconds(2);

        spriteObj.SetActive(false);
        gunObj.SetActive(false);
        gunSpriteObj.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 1);
        traveling = false;


        FindObjectOfType<BrittanyLevelChanger>().FadeToNextLevel();
    }

    IEnumerator BlinkingWhileTravel()
    {
        while(traveling)
        {
            spriteObj.GetComponent<SpriteRenderer>().color = Color.blue;
            gunSpriteObj.GetComponent<SpriteRenderer>().color = Color.blue;
            yield return new WaitForSeconds(0.1f);
            spriteObj.GetComponent<SpriteRenderer>().color = Color.white;
            gunSpriteObj.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
