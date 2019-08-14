using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthGiver : MonoBehaviour
{
    public float height = 4;
    public GameObject healthPickup;
    public float time;
    public float interval;
    public float[] intervals;

    void Start()
    {
        if(PlayerPrefs.GetInt("Deaths") < intervals.Length)
            interval = intervals[PlayerPrefs.GetInt("Deaths")];
        else
            interval = intervals[intervals.Length - 1];

        randYpos();
    }


    void Update()
    {
        time += Time.deltaTime;
        if(time > interval)
        {
            if (PlayerPrefs.GetInt("Deaths") < intervals.Length)
                interval = intervals[PlayerPrefs.GetInt("Deaths")];
            else
                interval = intervals[intervals.Length - 1];

            randYpos();
            Destroy( Instantiate(healthPickup, transform.position, transform.rotation), 30);
            time = 0;
        }
    }

    void randYpos()
    {
        transform.position = new Vector3(transform.position.x, Random.Range(-height,height), 0);
    }
}
