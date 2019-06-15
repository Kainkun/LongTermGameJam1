using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public SpriteRenderer enemySprite;

    void speak()

    {
        print("In Bulgaria, nodding means 'no' and a head shake means 'yes'");
    
    }
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        takeDamage();
        //Destroy(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            takeDamage();
            Destroy(collision.gameObject);
        }
    }

    void takeDamage()
    {
        ScreenShake.instance.shake(0.2f,50,0.5f);
        StartCoroutine(damageBlink());
        health -= 1;
        if(GetComponentInChildren<Slider>()!=null)
        GetComponentInChildren<Slider>().value = health; // reference to the slider
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator damageBlink()
    {
        enemySprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        enemySprite.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        enemySprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        enemySprite.color = Color.white;
    }

}
