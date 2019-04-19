using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum world { cyber, steam };
public class TimeTravelManager : MonoBehaviour
{
    public List<GameObject> cyberWorldObjects;
    public List<GameObject> steamWorldObjects;
    public world currentWorld; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void swapWorlds()
    {
        if (currentWorld == 0)
        {
            foreach (GameObject a in cyberWorldObjects)
            {
                a.SetActive(true);
            }
            foreach (GameObject a in steamWorldObjects)
            {
                a.SetActive(false);
            }
            currentWorld = (world) 1;
        }
        else
        {
            foreach (GameObject a in cyberWorldObjects)
            {
                a.SetActive(false);
            }
            foreach (GameObject a in steamWorldObjects)
            {
                a.SetActive(true);
            }
            currentWorld = (world) 0;
        }
        
    }
}
