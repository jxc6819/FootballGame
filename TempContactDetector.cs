using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempContactDetector : MonoBehaviour
{
    public FieldManager2 FM;
    public GameObject Ground;

    public void OnCollisionEnter(Collision col)
    {


        if (col.gameObject == FM.Receiver1)
        {
            FM.R1hasCaught = true;
            Debug.Log("Contact");

           // FM.rend.enabled = false;
        }

        if (col.gameObject == FM.Receiver2)
        {
            FM.R2hasCaught = true;
            Debug.Log("Contact");
           // FM.rend.enabled = false;
        }
        if (col.gameObject == FM.Receiver3)
        {
            FM.R3hasCaught = true;
            Debug.Log("Contact");
           // FM.rend.enabled = false;
        }
        if (col.gameObject == FM.Receiver4)
        {
            Debug.Log("Contact");
            FM.R4hasCaught = true;
           // FM.rend.enabled = false;
        }
        if(col.gameObject == Ground)
        {
            Debug.Log("Contact");
        }
    }

    public float holdDuration;

}
        
     

