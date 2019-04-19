using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(WeaponShooter))]
[CanEditMultipleObjects]
public class WeaponShooterEditor : Editor
{
    SerializedProperty currWeapon;

    void OnEnable(){
        currWeapon = serializedObject.FindProperty("currWeapon");
    }

    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();
    }
}
