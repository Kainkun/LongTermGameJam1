using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{

    public enum SpawnerType{
        SingleLife, Respawnable, TimedSpawn
    }

    [SerializeField]
    private GameObject enemyToSpawn;

    private GameObject currentSpawn;

    private bool readyToSpawn = true;

    [Space]
    [Header("Enemy Spawner Properties")]

    [SerializeField]
    private SpawnerType spawnerType;

    [SerializeField]
    [Tooltip("Only spawn an enemy if the last one is destroyed")]
    private bool waitUntilDeath = false;

    [SerializeField]
    [Tooltip("let the enemy spawn if the camera can't see the spawner")]
    private bool spawnOffCamera;

    [SerializeField]
    [Tooltip("Delay for the spawner (in seconds)")]
    private float spawnDelay = 1;

    [Space]

    [SerializeField]
    [Tooltip("Time between enemy respawns")]
    private float spawnTime = 1;

    [SerializeField]
    [Tooltip("-1 to spawn an unlimited number of enemies (it never stops)")]
    private int maxSpawnCount = -1;
    private int currCount = 0;


    [SerializeField]
    [Header("Time in seconds to spawn")]
    [Tooltip("Specific times in which an enemy will spawn (in seconds)")]
    private float[] spawnTimes;


    private Renderer render;
    // Start is called before the first frame update
    void Start(){
        render = this.GetComponent<Renderer>(); //This is actually used to check if we can be seen by the camera
        if (render == null) {
            render = this.gameObject.AddComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update(){

        if (enemyToSpawn == null) //We don't want to do anything if we don't know what to spawn
            return;

        switch (spawnerType) {
            case (SpawnerType.SingleLife):
                if (spawnOffCamera == false){ //Check if flag is enabled
                    if (!render.isVisible){ //Check if the spawner is "visible"
                        return;
                    }
                }

                if (currCount < 1){ //We do this check so we only spawn a single enemy here
                    StartCoroutine(spawn(enemyToSpawn, spawnDelay));
                }
                break;

            case (SpawnerType.Respawnable):

                if (maxSpawnCount >= 0){ //First we check the flag for spawnCount
                    if (currCount >= maxSpawnCount){ //This just makes sure that we don't exceed the max spawned
                        return;
                    }
                }

                if (spawnOffCamera == false)
                { //Check if flag is enabled
                    if (!render.isVisible)
                    { //Check if the spawner is "visible"
                        return;
                    }
                }


                if (waitUntilDeath) {
                    if (currentSpawn != null){ //check if we have an enemy currently spawned
                        readyToSpawn = false; 
                        return;
                    }
                    else { //There is no enemy right now
                        StartCoroutine(spawn(enemyToSpawn, spawnTime));
                    }
                } else if (readyToSpawn){ //Only spawn an enemy if we are ready
                    StartCoroutine(spawn(enemyToSpawn));
                }

                break;

            case (SpawnerType.TimedSpawn):
                if(!alreadyRan)
                    StartCoroutine(timedSpawn(enemyToSpawn, spawnTimes));
                break;
        }
    }

    bool alreadyRan = false;
    IEnumerator timedSpawn(GameObject go, float[] times) {
        alreadyRan = true;
        for (int i = 0; i < spawnTimes.Length; i++){
            yield return new WaitForSeconds(spawnTimes[i] - Time.timeSinceLevelLoad);
            Debug.Log("Spawning Enemy at " + Time.timeSinceLevelLoad);
            currentSpawn = GameObject.Instantiate(enemyToSpawn, this.transform.position, Quaternion.identity, null);
            currCount++;
        }
        yield return null;
    }

    IEnumerator spawn(GameObject go, float delay){
        currentSpawn = GameObject.Instantiate(go, this.transform.position, Quaternion.identity, null);
        currCount++;
        currentSpawn.SetActive(false);
        yield return new WaitForSeconds(delay);
        currentSpawn.SetActive(true);
        readyToSpawn = false;
        yield return new WaitForSeconds(spawnTime);
        readyToSpawn = true;
        yield return null;
    }

    IEnumerator spawn(GameObject go){
        currentSpawn = GameObject.Instantiate(go, this.transform.position, Quaternion.identity, null);
        currCount++;
        readyToSpawn = false;
        yield return new WaitForSeconds(spawnTime);
        readyToSpawn = true;
        yield return null;
    }
}
