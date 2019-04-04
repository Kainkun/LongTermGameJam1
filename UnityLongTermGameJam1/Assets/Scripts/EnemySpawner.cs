using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemySpawner : MonoBehaviour
{
    public enum SpawnerType
    {
        SingleLife, Respawnable, TimedSpawn
    }

    [SerializeField]
    private GameObject enemyToSpawn;

    [Space]
    [Header("Enemy Spawner Toggles")]

    [SerializeField]
    private SpawnerType spawnerType;

    [SerializeField]
    [Tooltip("Only spawn an enemy if the last one is destroyed")]
    private bool waitUntilDeath = false;

    [SerializeField]
    [Tooltip("Spawn the enemy only if the spawner is on camera")]
    private bool spawnOffCamera;

    [Space]
    [Header("Enemy Spawner Properties")]

    [SerializeField]
    [Tooltip("Time between enemy respawns")]
    private float spawnTime = 1;

    [SerializeField]
    [Tooltip("-1 to spawn an unlimited number of enemies (it never stops)")]
    public float spawnCount = -1;

    [SerializeField]
    [Tooltip("Specific times in which an enemy will spawn")]
    private float[] spawnTimes;


    private Renderer render;
    // Start is called before the first frame update
    void Start(){
        render = this.GetComponent<Renderer>();
        if (render == null) {
            render = this.gameObject.AddComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
            
    }
}
