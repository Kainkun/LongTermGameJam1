using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyToSpawn;

    [SerializeField]
    private bool useTimedSpawner = false;
    [SerializeField]
    private float timeBetweenSpawns = 1;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
