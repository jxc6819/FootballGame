using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TackeMovePos : MonoBehaviour
{
    public TackleDetect TackleDetect;
   
    public GameObject PostPlayer;
    public string PathFollower;
    public bool stoppedPlay;
    public bool idle;
    public CollisionBool CollisionBool;
    public void Start()
    {
        (PostPlayer.GetComponent(PathFollower) as MonoBehaviour).enabled = false;
    }
    void Update()
    {
        if (TackleDetect.hasTackled == true)
        {
            stoppedPlay = true;
            
            
        }
        if (stoppedPlay == true)
        {
            Debug.Log("Bool Works");
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            idle = true;
            CollisionBool.ballCollision = false;

        }
        if (stoppedPlay == false)
        {
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
            idle = false;
        }
        

    }
    
    
    
}


