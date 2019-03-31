using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public SpriteRenderer mainShipRenderer;
    public float moveSpeed;
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
        
    }
}
