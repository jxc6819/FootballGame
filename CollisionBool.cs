using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionBool : MonoBehaviour
{
    public bool ballCollision;
    public GameObject football;
    public GameObject Player;
    public AudioClip Celebration;
    public GameObject Endzone;
    public Text scoreText;
    public int Score;

         private void OnCollisionEnter(Collision collision)
        {
        IEnumerator ExecuteIn12(System.Action aCallback)
        {
            yield return new WaitForSeconds(1f);
            aCallback();
        }
        

        if (collision.gameObject == football)
            {
                ballCollision = true;
            }
            if (ballCollision == true)
                if (transform.position.x > 36)
                {
                    
                    AudioSource.PlayClipAtPoint(Celebration, transform.position);
                AddScore();
                    StartCoroutine(ExecuteIn12(() => ballCollision = false));
                }

            


        }
    void AddScore()
    {
        Score++;
        scoreText.text = Score.ToString();
    }
   
}

    





