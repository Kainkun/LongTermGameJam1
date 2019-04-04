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
        serializedObject.Update();

        EditorGUILayout.PropertyField(spawnerType);

        EnemySpawner.SpawnerType st = (EnemySpawner.SpawnerType)spawnerType.enumValueIndex;

        switch (st)
        {
            case (EnemySpawner.SpawnerType.Respawnable):
                break;
            case (EnemySpawner.SpawnerType.SingleLife):
                break;
            case (EnemySpawner.SpawnerType.TimedSpawn):
                break;
        }
    }
}
