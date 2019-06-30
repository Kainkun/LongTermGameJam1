using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrittanyHealthHearts : MonoBehaviour
{
    private int maxHeartAmount = 3;
    public int startHearts = 3;
    public int currentHealth;
    private int maxHealth;
    private int healthPerHeart = 3;

    public Image[] healthImages;
    public Sprite[] healthSprites;

    void Start()
    {
        currentHealth = startHearts * healthPerHeart;
        maxHealth = maxHeartAmount * healthPerHeart;
        checkHealthAmount();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            TakeDamage(1);
    }

    void checkHealthAmount()
    {
        for(int i = 0; i < maxHeartAmount; i++)
        {
            if(startHearts <= i)
            {
                healthImages[i].enabled = false;
            }
            else
            {
                healthImages[i].enabled = true;
            }
        }
        UpdateHearts();
    }
    void UpdateHearts()
    {
        bool empty = false;
        int i = 0;
        foreach(Image image in healthImages)
        {
            if (empty)
            {
                image.sprite = healthSprites[0];
            }
            else
            {
                i++;
                if(currentHealth >= i * healthPerHeart)
                {
                    image.sprite = healthSprites[healthSprites.Length - 1];
                }
                else
                {
                    int currentHeartHealth = (int)(healthPerHeart - (healthPerHeart * i - currentHealth));
                    int healthPerImage = healthPerHeart / (healthSprites.Length - 1);
                    int imageIndex = currentHeartHealth / healthPerImage;
                    image.sprite = healthSprites[imageIndex];
                    empty = true; 
                }
            }
        }
    }
    public void TakeDamage(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, startHearts * healthPerHeart);
        UpdateHearts();
    }
    public void AddHeartContainer()
    {
        startHearts++;
        startHearts = Mathf.Clamp(startHearts, 0, maxHeartAmount);
        //currentHealth = startHearts * healthPerHeart;
        //maxHealth = maxHeartAmount * healthPerHeart;
        checkHealthAmount();
    }
}
