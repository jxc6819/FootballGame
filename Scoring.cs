using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public GameObject football8;
    public AudioClip Celebration;
    public GameObject football;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.parent == football8)
        {
            if (gameObject.transform.parent == football)
            {
                AudioSource.PlayClipAtPoint(Celebration, transform.position);
            }
        }
    }
}


