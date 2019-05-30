using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(EnemyHealth))]
[ExecuteInEditMode]
public class EasyEnemyController : MonoBehaviour
{
    public struct Waypoint{
        public enum Action{nothing, fire};

        public Vector3 position;
        public Action action;

        public Waypoint(Vector3 position, Action action){
            this.position = position;
            this.action = action;
        }
    }

    private List<Transform> path;
    public Waypoint[] bakedPath = new Waypoint[0];
    public float gizmoSize = .1f;

    public float speed = 5;
    public float rotateSpeed = 6;
    public float distanceToPoints = 1f;

    public Weapon weapon;

    private Vector3 initPos = Vector3.zero;
    Vector3 offset;

    // Start is called before the first frame update
    void Awake()
    {
        if(Application.isPlaying)
            initPos = this.transform.position;
        UpdatePath();
    }

    void Start(){
        if(Application.isPlaying){
            BakePath(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        offset = this.transform.position;
         if(Application.isPlaying){
            offset = initPos;
            FollowPath();
        }
    }

    int index = 0;
    bool alreadyShot = false;
    void FollowPath(){
        if(index >= bakedPath.Length)
            return; //Done
        if(index != 0){
            if(bakedPath[index-1].action == Waypoint.Action.fire && alreadyShot == false){
                weapon.shoot();
                alreadyShot = true;
            }
        }
        

        Vector3 dir = ((initPos + bakedPath[index].position) - this.transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        
        Quaternion goal = Quaternion.Euler(0,0, angle);

        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, goal, rotateSpeed * Time.deltaTime);
        //this.transform.position = Vector3.Lerp(this.transform.position, initPos + bakedPath[index].position, speed * Time.deltaTime);
        //this.transform.position += ((initPos + bakedPath[index].position) - this.transform.position) * speed * Time.deltaTime;
        this.transform.position += this.transform.up * speed * Time.deltaTime;
        if(Vector3.Distance(this.transform.position, initPos + bakedPath[index].position) < distanceToPoints){
            index++;
            alreadyShot = false;
        }
    }


//Editor Garbage down here !! --------------------------------------------------------------------------

    void DrawPath(){
        if(!Application.isEditor) //If we aren't the editor just ignore the function
            return;

        if(!Application.isPlaying){
            if(path.Count <= 1)
                return;

            for(int i = 0; i < path.Count-1; i++){
                Debug.DrawLine(path[i].position, path[i+1].position, Color.red);
            }
        }
    }

    void DrawBakedPath(Vector3 offset){
        if(!Application.isEditor) //If we aren't the editor just ignore the function
            return;

        for(int i = 0; i < bakedPath.Length-1; i++){
            Debug.DrawLine(offset + bakedPath[i].position, offset + bakedPath[i+1].position, Color.cyan);
        }
    }

    //Editor Only Script
    public void UpdatePath(){
        path = new List<Transform>(this.GetComponentsInChildren<Transform>());
        for(int i = 0; i < path.Count; i++){
            if(path[i].name.ToLower().Contains("weapon")){
                foreach(Transform t in path[i].GetComponentsInChildren<Transform>()){
                    path.Remove(t);
                }
            }
        }
    }

    public void BakePath(bool destroyChildren){
        bakedPath = new Waypoint[path.Count];

        for(int i = 1; i < path.Count; i++){
            if(path[i].name.ToLower().Contains("fire")){
                bakedPath[i] = new Waypoint(path[i].localPosition, Waypoint.Action.fire);
                continue;
            }
            bakedPath[i] = new Waypoint(path[i].localPosition, Waypoint.Action.nothing);
        }

        if(destroyChildren){
            for(int i = 1; i < path.Count; i++){
                DestroyImmediate(path[i].gameObject);
            }
            UpdatePath();
        }
    }

    void OnDrawGizmos(){
        
        if(!Application.isPlaying){
            UpdatePath();
            BakePath(false);
            offset = this.transform.position;
        }

        DrawBakedPath(offset);
        
        for(int i = 0; i < bakedPath.Length; i++){
            if(bakedPath[i].action == Waypoint.Action.fire){
                Gizmos.color = Color.magenta;
                Gizmos.DrawSphere(offset + bakedPath[i].position, gizmoSize);
                continue;
            }
            
            if(bakedPath[i].action == Waypoint.Action.nothing){
                Gizmos.color = Color.cyan;
                Gizmos.DrawSphere(offset + bakedPath[i].position, gizmoSize);
                continue;
            }
        }
        
    }
}
