using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TimeTravelManager))]
public class TimeTravelManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TimeTravelManager myScript = (TimeTravelManager) target;
        if (GUILayout.Button("Add Selected to Current World"))
        {
           
        }
    }
}