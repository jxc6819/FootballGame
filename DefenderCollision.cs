using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderCollision : MonoBehaviour
{
    public GameObject football;
    public GameObject Player;
    public AudioClip Interception;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject == football)


        {

            

            

                AudioSource.PlayClipAtPoint(Interception, transform.position);
                
            }



        }
    }






