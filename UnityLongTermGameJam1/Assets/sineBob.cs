using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sineBob : MonoBehaviour
{
    float startY;
    public float height;
    public float speed;
    public float offset;


    public bool useX;
    float startX;
    public float width;
    public float Xspeed;
    public float Xoffset;

    // Start is called before the first frame update
    void Start()
    {
        startY = transform.localPosition.y;
        startX = transform.localPosition.x;

        StartCoroutine(playAnimation());
    }

    public IEnumerator playAnimation()
    {
        yield return new WaitForSeconds(24.033f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.localPosition;
        pos.y = startY + Mathf.Sin(Time.time * speed + offset) * height;
        if(useX)
        pos.x = startX + Mathf.Sin(Time.time * Xspeed + Xoffset) * width;
        transform.localPosition = pos;
    }
}
