using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [Tooltip("How many seconds it takes for weapons to start spawning")]
    public float SpawnStartTime;
    [Tooltip("A random weapon spawn every X seconds")]
    public float SpawnInterval;
    [Tooltip("Spawn Interval will be randomly offset by this amount")]
    public float IntervalVariance;
    [Tooltip("Weapons randomly spawn between this height")]
    public float SpawnHeightVariance;

    float time;

    public GameObject[] WeaponPickups;
    

    void Start()
    {
        if (SpawnStartTime < 0)
        {
            Debug.LogError("SpawnStartTime Cannot be Negative, defaulting to 0");
            SpawnStartTime = 0;
        }
        if (SpawnInterval < 0)
        {
            Debug.LogError("SpawnInterval Cannot be Negative, defaulting to 1");
            SpawnInterval = 1;
        }
        if (IntervalVariance < 0)
        {
            Debug.LogError("IntervalVariance Cannot be Negative, defaulting to 0");
            IntervalVariance = 0;
        }
        else if (IntervalVariance >= SpawnInterval)
        {
            Debug.LogError("IntervalVariance must be smaller than SpawnInterval, defaulting to 0");
            IntervalVariance = 0;
        }


        time = -SpawnStartTime;
    }



    void Update()
    {
        time += Time.deltaTime;

        if(time > 0)
        {
            time = -SpawnInterval + Random.Range(-IntervalVariance, IntervalVariance);
            SpawnRandomWeapon();
        }
    }

    public void SpawnRandomWeapon()
    {
        if (WeaponPickups.Length > 0)
            SpawnWeapon(Random.Range(0, WeaponPickups.Length));
        else
            Debug.LogError("No Weapons in WeaponPickups");
    }

    public void SpawnWeapon(int WeaponNumber)
    {
        if (WeaponNumber >= 0 && WeaponNumber < WeaponPickups.Length)
            Instantiate(WeaponPickups[WeaponNumber], new Vector3(transform.position.x, transform.position.y + Random.Range(-SpawnHeightVariance, SpawnHeightVariance), 0), Quaternion.identity);
        else
            Debug.LogError("Weapon Number Out of Range");
    }
}
