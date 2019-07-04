using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//see carter for more info
public class PlayerHealth : MonoBehaviour
{
    public int health;
    public GameObject corpse;
    public SpriteRenderer playerSprite;
    public static PlayerHealth instance;

    public AudioClip playerDamage;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
    private void takeDamage(int amount,float invulnAmount)
    {
        if (Score.ScoreScript != null)
            Score.ScoreScript.SubScore(15);

        GetComponent<BrittanyHealthHearts>().TakeDamage(-3);
        ScreenShake.instance.shake(0.2f, 50, 0.5f);
        StartCoroutine(damageBlink());
        StartCoroutine(becomeInvincible(invulnAmount));
        health -= amount;
        if (health <= 0)
            die();
    }
    private void die()
    {

        Instantiate(corpse, transform.position, transform.rotation);
        FindObjectOfType<levelManager>().beginResetLevel();
        //Destroy(gameObject);

        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<PlayerHealth>().enabled = false;
        GetComponent<WeaponShooter>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
    }
    private IEnumerator becomeInvincible(float duration)
    {
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        if(health > 0)
        GetComponent<BoxCollider2D>().enabled = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        damagePlayer enemy = collision.gameObject.GetComponent<damagePlayer>();
        if (enemy != null)
        {
            takeDamage(enemy.damage, enemy.invulnerabilityDuration);
            if (enemy.damage < 0)
            {
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        damagePlayer enemy = collision.gameObject.GetComponent<damagePlayer>();
        if (enemy != null)
        {
            GetComponent<AudioSource>().PlayOneShot(playerDamage);
            takeDamage(enemy.damage, enemy.invulnerabilityDuration);
            if (enemy.damage < 0)
            {
                Destroy(collision.gameObject);
            }
        }
    }

    IEnumerator damageBlink()
    {
        playerSprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        playerSprite.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        playerSprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        playerSprite.color = Color.white;
    }
}
