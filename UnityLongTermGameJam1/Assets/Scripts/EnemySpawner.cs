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

    private GameObject currentSpawn;

    private bool readyToSpawn = false;

    [Space]
    [Header("Enemy Spawner Properties")]

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
    private int spawnCount = -1;
    private int currCount = 0;


    [SerializeField]
    [Tooltip("Specific times in which an enemy will spawn (in seconds)")]
    private float[] spawnTimes;


    private Renderer render;
    // Start is called before the first frame update
    void Start(){
        render = this.GetComponent<Renderer>();
        if (render == null) {
            render = this.gameObject.AddComponent<SpriteRenderer>();
        }
        StartCoroutine(timer(spawnTime));
    }

    // Update is called once per frame
    void Update()
    {
        switch (spawnerType) {
            case (SpawnerType.SingleLife):
                GameObject.Instantiate(enemyToSpawn, this.transform.position, Quaternion.identity, this.transform);
                break;

            case (SpawnerType.Respawnable):
                if (waitUntilDeath) {
                    if (currentSpawn != null) { //We have an enemy currently spawned
                        return;
                    }
                }

                //If we are here then we know there is no enemy currently
                //Or waitUntilDeath is not enabled

                if (spawnOffCamera == false) { //Check if flag is enabled
                    if (!render.isVisible) { //Check if the spawner is "visible"
                        return;
                    }
                }

                //Timer?
                if (readyToSpawn) {
                    StartCoroutine(spawn(enemyToSpawn, 1));
                    StartCoroutine(timer(spawnTime));
                }



                break;

            case (SpawnerType.TimedSpawn):

                foreach (float spawnTime in spawnTimes) {
                    if (spawnTime == Time.timeSinceLevelLoad) {
                        GameObject.Instantiate(enemyToSpawn, this.transform.position, Quaternion.identity, this.transform);
                    }
                }
                break;
        }

    }

    IEnumerator timer(float time)
    {
        yield return new WaitForSeconds(time);
        readyToSpawn = true;
        yield return null;
    }

    IEnumerator spawn(GameObject go, float time)
    {
        yield return new WaitForSeconds(time);
        GameObject.Instantiate(enemyToSpawn, this.transform.position, Quaternion.identity, this.transform);
        readyToSpawn = false;
    }
}
