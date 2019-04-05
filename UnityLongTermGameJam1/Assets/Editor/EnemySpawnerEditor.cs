using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(EnemySpawner))]
[CanEditMultipleObjects]
public class EnemySpawnerEditor : Editor
{

    SerializedProperty enemyToSpawn,
                       spawnerType,
                       waitUntilDeath,
                       spawnOffCamera,
                       spawnTime,
                       maxSpawnCount,
                       spawnTimes,
                       spawnDelay;

    void OnEnable()
    {
        enemyToSpawn = serializedObject.FindProperty("enemyToSpawn");
        spawnerType = serializedObject.FindProperty("spawnerType");
        waitUntilDeath = serializedObject.FindProperty("waitUntilDeath");
        spawnOffCamera = serializedObject.FindProperty("spawnOffCamera");
        spawnTime = serializedObject.FindProperty("spawnTime");
        maxSpawnCount = serializedObject.FindProperty("maxSpawnCount");
        spawnTimes = serializedObject.FindProperty("spawnTimes");
        spawnDelay = serializedObject.FindProperty("spawnDelay");
    }
    
    public override void OnInspectorGUI()
    {

        EditorGUILayout.PropertyField(enemyToSpawn);
        EditorGUILayout.PropertyField(spawnerType);

        EditorGUILayout.Space();


        EnemySpawner.SpawnerType st = (EnemySpawner.SpawnerType)spawnerType.enumValueIndex;

        switch (st)
        {
            case (EnemySpawner.SpawnerType.SingleLife):
                EditorGUILayout.SelectableLabel("Spawns an enemy once");
                EditorGUILayout.Space();

                EditorGUILayout.PropertyField(spawnOffCamera);
                EditorGUILayout.PropertyField(spawnDelay);
                break;

            case (EnemySpawner.SpawnerType.Respawnable):
                EditorGUILayout.SelectableLabel("Spawns enemies at a consistant rate");
                EditorGUILayout.Space();
                EditorGUILayout.PropertyField(spawnOffCamera);
                EditorGUILayout.PropertyField(waitUntilDeath);
                EditorGUILayout.PropertyField(spawnTime);
                EditorGUILayout.PropertyField(maxSpawnCount);
                break;

            
            case (EnemySpawner.SpawnerType.TimedSpawn):
                EditorGUILayout.SelectableLabel("Spawns enemies at a given time (in seconds)");
                EditorGUILayout.Space();
                EditorGUILayout.PropertyField(spawnTimes, true);
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }
}
