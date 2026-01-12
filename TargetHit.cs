using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    public GameObject football;
    public GameObject Player;
    public AudioClip Ding;
    public int RandomOption;
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;
    public GameObject target5;
    public GameObject target6;
    public GameObject target7;
    public GameObject target8;
    public GameObject target9;
    public GameObject target10;
    public bool isHit;
    public int t1hit;

    public void OnCollisionEnter(Collision collision)
    {
        t1hit += 1;
        
            AudioSource.PlayClipAtPoint(Ding, Player.transform.position);

            RandomOption = Random.Range(1, 10);
          

            if (RandomOption == 1)
            {
                target1.SetActive(true);
                Debug.Log("1");
            }
            if (RandomOption == 2)
            {
                target2.SetActive(true);
                Debug.Log("2");
            }
            if (RandomOption == 3)
            {
                target3.SetActive(true);
                Debug.Log("3");
            }
            if (RandomOption == 4)
            {
                target4.SetActive(true);
                Debug.Log("4");
            }
            if (RandomOption == 5)
            {
                target5.SetActive(true);
                Debug.Log("5");
            }
            if (RandomOption == 6)
            {
                target6.SetActive(true);
                Debug.Log("6");
            }
            if (RandomOption == 7)
            {
                target7.SetActive(true);
                Debug.Log("7");
            }
            if (RandomOption == 8)
            {
                target8.SetActive(true);
                Debug.Log("8");
            }
            if (RandomOption == 9)
            {
                target9.SetActive(true);
                Debug.Log("9");
            }
            if (RandomOption == 10)
            {
                target10.SetActive(true);
                Debug.Log("10");

            }
            gameObject.SetActive(false);

        }
    }


