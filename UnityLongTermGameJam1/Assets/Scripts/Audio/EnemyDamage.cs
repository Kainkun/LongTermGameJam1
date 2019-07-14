using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public AudioClip enemyDamage;

    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "PlayerBullet")
        {
            GetComponent<AudioSource>().PlayOneShot(enemyDamage);
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
