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
        if (myScript.currentWorld == 0)
        {
            foreach (GameObject a in myScript.cyberWorldObjects)
            {
                a.SetActive(true);
            }
            foreach (GameObject a in myScript.steamWorldObjects)
            {
                a.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject a in myScript.cyberWorldObjects)
            {
                a.SetActive(false);
            }
            foreach (GameObject a in myScript.steamWorldObjects)
            {
                a.SetActive(true);
            }
        }
        if (GUILayout.Button("Add Selected to Current World"))
        {
            if (myScript.currentWorld == 0)
            {
                foreach(GameObject a in Selection.objects)
                {
                    myScript.cyberWorldObjects.Add(a);
                }
            }
            else
            {
                foreach (GameObject a in Selection.objects)
                {
                    myScript.steamWorldObjects.Add(a);
                }
            }
        }
    }
}