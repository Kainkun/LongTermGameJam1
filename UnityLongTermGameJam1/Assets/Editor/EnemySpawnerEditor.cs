using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(EnemySpawner))]
[CanEditMultipleObjects]
public class EnemySpawnerEditor : Editor
{
    SerializedProperty enemySpawner;

    void OnEnable()
    {
        enemySpawner = serializedObject.FindProperty("EnemySpawner");
    }
​
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(enemySpawner);
        serializedObject.ApplyModifiedProperties();
    }
}
