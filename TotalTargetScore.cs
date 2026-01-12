using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalTargetScore : MonoBehaviour
{
    
    public GameObject Target1;
    public GameObject Target2;
    public GameObject Target3;
    public GameObject Target4;
    public GameObject Target5;
    public GameObject Target6;
    public GameObject Target7;
    public GameObject Target8;
    public GameObject Target9;
    public GameObject Target10;
    public bool isHitt;
    public int HitCount;
    public TargetScore totalScore;
    public GameObject football;
    public GameObject Floor;
    public TargetScore tscore;


  
    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        IEnumerator ExecuteIn13(System.Action aCallback)
        {
            yield return new WaitForSeconds(0.5f);
            aCallback();
        }

        if (collision.gameObject == Target1 || collision.gameObject == Target2 || collision.gameObject == Target3 || collision.gameObject == Target4 || collision.gameObject == Target5 || collision.gameObject == Target6 || collision.gameObject == Target7 || collision.gameObject == Target8 || collision.gameObject == Target9) {
            isHitt = true;
            HitCount += 1;
            Debug.Log("It Works!");
            StartCoroutine(ExecuteIn13(() => isHitt = false));
            

        }
       
        }

    }


