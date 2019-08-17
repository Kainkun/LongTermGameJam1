using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public bool DontExplodeOnDeath;
    public GameObject explosion;
    public int health;
    public SpriteRenderer enemySprite;
    public bool FallOnDeath;
    bool dead;

    public AudioClip enemyDamage;
    public float pitchMin, pitchMax;
  

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

    void playDamageSound()
    {
        GameObject AudioObject = Instantiate(new GameObject(), transform.position, transform.rotation);
        AudioSource takeDamageAS = AudioObject.AddComponent<AudioSource>();
        takeDamageAS.clip = enemyDamage;
        takeDamageAS.pitch = Random.Range(pitchMin, pitchMax);
        takeDamageAS.Play();
        Destroy(AudioObject, 5);
    }

    void takeDamage()
    {
        playDamageSound();
        
        //ScreenShake.instance.shake(0.2f,50,0.5f);
        StartCoroutine(damageBlink());
        health -= 1;
        if(GetComponentInChildren<Slider>()!=null)
        GetComponentInChildren<Slider>().value = health; // reference to the slider
        if(health <= 0)
        {
            if(!DontExplodeOnDeath)
            Destroy(Instantiate(explosion, transform.position, Quaternion.identity), 10);

            if (Score.ScoreScript != null)
            Score.ScoreScript.AddScore(50);

            if (!FallOnDeath)
            Destroy(gameObject);
            else if(!dead)
            {
                Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();

                rb.velocity = new Vector2(0, 3);
                Destroy(gameObject, 5);

                dead = true;
            }
        }
        else if (Score.ScoreScript != null)
            Score.ScoreScript.AddScore(5);
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
