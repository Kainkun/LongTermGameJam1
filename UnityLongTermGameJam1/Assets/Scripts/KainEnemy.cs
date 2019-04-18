using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KainEnemy : MonoBehaviour
{
    public enum MoveStyle {moveTransform, moveRigidBody};
    [SerializeField]
    private MoveStyle myMoveStyle;
    public float speed = 1;
    public float distance = 1;
    Vector3 startPosition;
    [SerializeField]
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (myMoveStyle)
        {
            case (MoveStyle.moveTransform):
                transform.position = new Vector3(startPosition.x, startPosition.y + Mathf.Sin(Time.time * speed) * distance, 0);
                break;

            case (MoveStyle.moveRigidBody):
                if (GetComponent<Rigidbody2D>() != null)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sin(Time.time * speed), -1 * speed);
                }
                else
                {
                    Debug.LogError("no rigidBody2D!");
                }
                break;

            default:
                print("rip");
                break;
        }
        
    }
    private void takeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
            die();
    }
    private void die()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerBullet bullet= collision.gameObject.GetComponent<playerBullet>();
        if (bullet != null) {
            takeDamage(bullet.damage);
            Destroy(collision.gameObject);
        }

    }
}
