using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int health;
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
    void takeDamage()
    {
        health -= 1;
        if(GetComponentInChildren<Slider>()!=null)
        GetComponentInChildren<Slider>().value = health; // reference to the slider
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
