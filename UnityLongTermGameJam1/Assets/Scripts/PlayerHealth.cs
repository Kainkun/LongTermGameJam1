using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//see carter for more info
public class PlayerHealth : MonoBehaviour
{
    public int health;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void takeDamage(int amount,float invulnAmount)
    {
      
        StartCoroutine(becomeInvincible(invulnAmount));
        health -= amount;
        if (health <= 0)
            die();
    }
    private void die()
    {
        Destroy(gameObject);
    }
    private IEnumerator becomeInvincible(float duration)
    {
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
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
    private void OnDestroy()
    {
        FindObjectOfType<levelManager>().resetLevel();
    }
}
