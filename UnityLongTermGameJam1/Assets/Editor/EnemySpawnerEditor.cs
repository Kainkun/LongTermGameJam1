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
                       spawnCount,
                       spawnTimes;

    void OnEnable()
    {
        enemyToSpawn = serializedObject.FindProperty("enemyToSpawn");
        spawnerType = serializedObject.FindProperty("spawnerType");
        waitUntilDeath = serializedObject.FindProperty("waitUntilDeath");
        spawnOffCamera = serializedObject.FindProperty("spawnOffCamera");
        spawnTime = serializedObject.FindProperty("spawnTime");
        spawnCount = serializedObject.FindProperty("spawnCount");
        spawnTimes = serializedObject.FindProperty("spawnTimes");
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
                EditorGUILayout.PropertyField(spawnOffCamera);
                break;

            case (EnemySpawner.SpawnerType.Respawnable):
                EditorGUILayout.PropertyField(spawnOffCamera);
                EditorGUILayout.PropertyField(waitUntilDeath);
                EditorGUILayout.PropertyField(spawnCount);
                break;

            
            case (EnemySpawner.SpawnerType.TimedSpawn):
                EditorGUILayout.PropertyField(spawnTimes, true);
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }
}
