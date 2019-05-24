using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EasyEnemyController))]
public class EasyEnemyControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EasyEnemyController enemyController = (EasyEnemyController)target;
        if(GUILayout.Button("Update Path"))
        {
            enemyController.UpdatePath();
        }

        if(GUILayout.Button("Bake Path"))
        {
            enemyController.BakePath(false);
        }

        if(GUILayout.Button("Bake Path (Destroy Children)"))
        {
            enemyController.BakePath(true);
        }    
    }
}

[RequireComponent(typeof(EnemyHealth))]
[ExecuteInEditMode]
public class EasyEnemyController : MonoBehaviour
{
    public Transform[] path;
    public Vector3[] bakedPath;
    public float gizmoSize = .1f;

    public float speed = 5;
    public float rotateSpeed = 6;

    public Weapon weapon;

    private Vector3 initPos = Vector3.zero;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        if(Application.isPlaying)
            initPos = this.transform.position;
        UpdatePath();
    }

    // Update is called once per frame
    void Update()
    {
        offset = this.transform.position;
         if(Application.isPlaying){
            offset = initPos;
            FollowPath();
        }
        DrawPath();

    }

    int index = 0;
    void FollowPath(){
        if(index >= bakedPath.Length)
            return; //Done

        if(bakedPath[index].Equals(Vector3.positiveInfinity)){
            //Fire Weapon here
            Debug.Log("Firing Weapon!!");
            index++;
        }

        Vector3 dir = ((initPos + bakedPath[index]) - this.transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        
        Quaternion goal = Quaternion.Euler(0,0, angle);

        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, goal, rotateSpeed * Time.deltaTime);
        //this.transform.position = Vector3.Lerp(this.transform.position, initPos + bakedPath[index], speed * Time.deltaTime);
        //this.transform.position += ((initPos + bakedPath[index]) - this.transform.position) * speed * Time.deltaTime;
        this.transform.position += this.transform.up * speed * Time.deltaTime;
        if(Vector3.Distance(this.transform.position, initPos + bakedPath[index]) < 2f){
            index++;
        }
    }


//Editor Garbage down here !! --------------------------------------------------------------------------

    void DrawPath(){
        if(!Application.isEditor) //If we aren't the editor just ignore the function
            return;

        int j = 0;
        if(!Application.isPlaying){
            for(int i = 0; i < path.Length - 1; i++){
                if(path[i].name.ToLower().Contains("fire"))
                    continue;

                for(j = i+1; path[j].name.ToLower().Contains("fire"); j++){}
                Debug.DrawLine(path[i].position, path[j].position, Color.yellow);
            }
        }
        
        for(int i = 0; i < bakedPath.Length-1; i++){
            if(bakedPath[i].Equals(Vector3.positiveInfinity)){
                continue;
            }
            for(j = i+1; bakedPath[i].Equals(Vector3.positiveInfinity); j++){}
            Debug.DrawLine(offset + bakedPath[i], offset + bakedPath[j], Color.cyan);
        }
    }

    //Editor Only Script
    public void UpdatePath(){
        path = this.GetComponentsInChildren<Transform>();
    }

    public void BakePath(bool destroyChildren){
        bakedPath = new Vector3[path.Length];

        for(int i = 0; i < path.Length; i++){
            if(path[i].name.ToLower().Contains("fire")){
                Debug.Log("Adding to pos inif");
                bakedPath[i] = Vector3.positiveInfinity;
                continue;
            }
            bakedPath[i] = path[i].localPosition;
        }
        bakedPath[0] = Vector3.zero;

        if(destroyChildren){
            for(int i = 1; i < path.Length; i++){
                DestroyImmediate(path[i].gameObject);
            }
            UpdatePath();
        }
    }

    void OnDrawGizmosSelected(){
        for(int i = 0; i < path.Length-1; i++){
            if(path[i+1].name.ToLower().Contains("fire")){
                Gizmos.color = Color.magenta;
                Gizmos.DrawSphere(path[i].position, gizmoSize);
                continue;
            }
            
            if(path[i+1].name.ToLower().Contains("pos")){
                Gizmos.color = Color.red;  
                Gizmos.DrawSphere(path[i].position, gizmoSize);
            }
        }

        if(path[path.Length - 1].name.ToLower().Contains("pos")){
            Gizmos.color = Color.blue;  
            Gizmos.DrawSphere(path[path.Length - 1].position, gizmoSize);
        }

        //For Baked Position

        for(int i = 0; i < bakedPath.Length-1; i++){
            if(bakedPath[i+1].Equals(Vector3.positiveInfinity)){
                Gizmos.color = Color.magenta;
                Gizmos.DrawSphere(offset + bakedPath[i], gizmoSize);
                continue;
            }
            
            
            Gizmos.color = Color.cyan;  
            Gizmos.DrawSphere(offset + bakedPath[i], gizmoSize);
            
        }

        if(!bakedPath[bakedPath.Length - 1].Equals(Vector3.positiveInfinity)){
            Gizmos.color = Color.cyan;  
            Gizmos.DrawSphere(offset + bakedPath[path.Length - 1], gizmoSize);
        }
    }
}
