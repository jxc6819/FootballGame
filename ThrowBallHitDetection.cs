using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBallHitDetection : MonoBehaviour
{
    public GameObject Receiver1;
    public GameObject Receiver2;
    public GameObject Receiver3;
    public GameObject Receiver4;

    public GameObject Defender1;
    public GameObject Defender2;
    public GameObject Defender3;
    public GameObject Defender4;
    

    public FieldManager2 FM;
    public SnappingTEMP ST;
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == Receiver1 && Receiver1.transform.position.z < 245.34)
        {
            Debug.Log("Caught");
            FM.R1hasCaught = true;
            ST.Caught = true;
            // gameObject.SetActive(false);
        }
        if (collision.gameObject == Receiver2 && Receiver2.transform.position.z < 245.34)
        {
            Debug.Log("Caught");
            FM.R2hasCaught = true;
            ST.Caught = true;
          //  gameObject.SetActive(false);
        }
        if (collision.gameObject == Receiver3 && Receiver3.transform.position.z < 245.34)
        {
            Debug.Log("Caught");
            FM.R3hasCaught = true;
            ST.Caught = true;
          //  gameObject.SetActive(false);
        }
        if(collision.gameObject == Receiver4 && Receiver3.transform.position.z < 245.34)
        {
            Debug.Log("Caught");
            FM.R4hasCaught = true;
            ST.Caught = true;
          //  gameObject.SetActive(false);
        }

        if (collision.gameObject == Defender1 && Defender1.transform.position.z < 245.34)
        {
            if (UnityEngine.Random.Range(1, 100) <= 70)
            {
                FM._D1Int = true;

            }
            ST.Caught = true;
        }
        if (collision.gameObject == Defender2 && Defender1.transform.position.z < 245.34)
        {
            if (UnityEngine.Random.Range(1, 100) <= 70)
            {
                FM._D2Int = true;

            }
            ST.Caught = true;
        }
        if (collision.gameObject == Defender3 && Defender1.transform.position.z < 245.34)
        {
            if (UnityEngine.Random.Range(1, 100) <= 70)
            {
                FM._D3Int = true;

            }
            ST.Caught = true;
        }
        if (collision.gameObject == Defender4 && Defender4.transform.position.z < 245.34)
        {
            if (UnityEngine.Random.Range(1, 100) <= 70)
            {
                FM._D4Int = true;

            }
            ST.Caught = true;
        }
    }
}
