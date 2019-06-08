using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemy : MonoBehaviour
{
    GameObject Player;
    int Stage;

    [Tooltip("How fast to move onto screen")]
    public float moveInSpeed;
    [Tooltip("What X position to stop at")]
    public float stopAt;

    float time;
    [Tooltip("How long to wait to attack")]
    public float waitTime;

    bool attacking;
    Vector3 attackDirection;
    [Tooltip("How fast to dash at player")]
    public float attackSpeed;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        
        //move right to left until a given X position
        if (Stage == 0)
        {
            transform.position += new Vector3(-1, 0, 0) * moveInSpeed * Time.deltaTime;

            if (transform.position.x < stopAt)
                Stage++;
        }

        //wait a given time, during this time, enemy will start to look at player
        //by the end of the time, the enemy will be looking directly at the player
        if(Stage == 1)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, getLookAt(), time / waitTime); //will be looking at player by the end of the time

            time += Time.deltaTime;

            if (time >= waitTime)
                Stage++;
        }

        //find the player and dash at that direction. does NOT change direction while dashing
        if(Stage == 2)
        {
            if (!attacking) //get attack direction once
            {
                attacking = true;
                attackDirection = getAttackDirection();
            }
            else
            {
                transform.position += attackDirection * attackSpeed * Time.deltaTime;
            }
        }

        //kill when out of bounds
        if(Mathf.Abs(transform.position.x) > 15 || Mathf.Abs(transform.position.y) > 15)
        {
            Destroy(gameObject);
        }
    }

    //return normalized vector2 position of player
    Vector2 getAttackDirection()
    {
        Vector3 temp = Player.transform.position - transform.position;
        temp.z = 0;
        temp.Normalize();
        return temp;
    }

    //return quaterion of direction of player
    Quaternion getLookAt()
    {
        Vector3 diff = Player.transform.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(0, 0, rot_z + 180);
    }
    
}
