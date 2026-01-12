using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportFootball : MonoBehaviour
{
    public GameObject football;
    public GameObject TeleportGoal;
    public GameObject postPlayer;
        public GameObject Floor;
    public GameObject streakPlayer;
    public TackeMovePos TackleDetect;
    Vector3 oldPos1;
    Vector3 oldPos2;
    Vector3 oldPos3;
    Vector3 oldPos4;
    public GameObject Defender;
    public GameObject User;
    //public CollisionBool CollisionBool;


    private void Start()
    {
        oldPos1 = User.transform.position;
        oldPos2 = Defender.transform.position;
        oldPos3 = postPlayer.transform.position;
        oldPos4 = streakPlayer.transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject == postPlayer)
           
        {
            
            football.transform.position = TeleportGoal.transform.position; }

        if (collision.gameObject == streakPlayer)

        {

            football.transform.position = TeleportGoal.transform.position;
        }
       if (collision.gameObject == Floor)
        {

            football.transform.position = TeleportGoal.transform.position;
           // TackleDetect.stoppedPlay = true;
          // User.transform.position = oldPos1;
          // Defender.transform.position = oldPos2;
           // postPlayer.transform.position = oldPos3;
        }

    }
}



