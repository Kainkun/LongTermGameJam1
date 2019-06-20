using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Experimental.Input;
//Created by Carter
public class PlayerMovement : MonoBehaviour
{
    //still figuring out that new input system 
    //public InputManager controls;
    public SpriteRenderer mainShipRenderer;
    //no diagnals yet (coming soon)
    public Sprite left;
    public Sprite right;
    public Sprite up;
    public Sprite down;
    public Sprite nothing;
    public float moveSpeed;

    public float wallX;
    public float wallY;
    // Start is called before the first frame update
    void Start()
    {
        if (mainShipRenderer == null)
        {
            mainShipRenderer = GetComponentInChildren<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        dir = dir.normalized;

        if(transform.position.x > wallX && dir.x > 0)
        {
            dir.x = 0;
        }

        else if (transform.position.x < -wallX && dir.x < 0)
        {
            dir.x = 0;
        }

        else if (transform.position.y > wallY && dir.y > 0)
        {
            dir.y = 0;
        }

        else if (transform.position.y < -wallY && dir.y < 0)
        {
            dir.y = 0;
        }

        transform.Translate(dir * moveSpeed);
        if (dir.x < 0)
            mainShipRenderer.sprite = left;
        else if (dir.x > 0)
            mainShipRenderer.sprite = right;
        else
        {
            if (dir.y < 0)
                mainShipRenderer.sprite = down;
            else if (dir.y > 0)
                mainShipRenderer.sprite = up;
            else
                mainShipRenderer.sprite = nothing;             
        }
    }
}


