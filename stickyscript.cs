using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickyscript : MonoBehaviour
{
    public GameObject football;
    public GameObject football8;
    public GameObject Player;
    void OnCollisionEnter(Collision collision)
    {

        //If the object that is colliding has the tag "football8"
        if (collision.gameObject.tag == "football8")
        { }
        if (collision.gameObject.tag == "football")
            //Set the parent of that object to the platform
            collision.transform.parent = GameObject.Find("Player").transform;
        {

        }
    }
}