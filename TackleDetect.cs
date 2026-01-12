using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TackleDetect : MonoBehaviour
{
    public bool hasTackled;
    public GameObject Player;
    public GameObject Defender;
    Vector3 oldPos;
    float totalDistance1 = 0;
    public GameObject User;
    public GameObject football;
    public CollisionBool CollisionBool;
    public GameObject Route;
    public bool isTackling;
    public bool startDelay;
    public bool stopDelay;
    public bool moveRoute;
    
    
    void Start()
    {
        oldPos = transform.position;
    }
        private void OnCollisionEnter(Collision tackle)
    {
        IEnumerator ExecuteIn12(System.Action aCallback)
        {
            yield return new WaitForSeconds(1f);
            aCallback();
        }
        IEnumerator ExecuteIn1(System.Action aCallback)
        {
            yield return new WaitForSeconds(0.3f);
            aCallback();
        }
          
        if (CollisionBool.ballCollision == true)
            if (tackle.gameObject == Defender)
            {
                isTackling = true;
                StartCoroutine(ExecuteIn12(() => isTackling = true));
                hasTackled = true;
            }

        if (isTackling == true)
        {

            //Remember to add "Stop Running" command when you finish animation
            Vector3 distanceVector = transform.position - oldPos;
            float distanceThisFrame = distanceVector.magnitude;
            totalDistance1 += distanceThisFrame;
            oldPos = transform.position;
            Debug.Log("Distance Calculated Successfully." + totalDistance1);

            Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
            Defender.transform.position = new Vector3(Player.transform.position.x + 5, Defender.transform.position.y, Player.transform.position.z);
            User.transform.position = new Vector3(Player.transform.position.x - 1, User.transform.position.y, Player.transform.position.z + 10);
            Route.transform.position = new Vector3(Player.transform.position.x, Route.transform.position.y, Route.transform.position.z);
        }

        // Route.transform.position = new Vector3(Player.transform.position.x +10, Route.transform.position.y, Route.transform.position.z);


    }








    }
 


