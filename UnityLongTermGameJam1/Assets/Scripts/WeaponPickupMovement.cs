using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickupMovement : MonoBehaviour
{
    public Vector2 move;
    Vector3 v3;
    // Start is called before the first frame update
    void Start()
    {
        v3 = move;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += v3 * Time.deltaTime;
        if (transform.position.x < -15)
            Destroy(gameObject);
    }
}
