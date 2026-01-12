using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateStreak : MonoBehaviour
{
    public GameObject postRoute;
    public GameObject streakRoute;
    public GameObject postPlayer;
    public GameObject streakPlayer;

    private void Start()
    {
        postRoute.SetActive(false);
        streakRoute.SetActive(true);
        postPlayer.SetActive(false);
        streakPlayer.SetActive(true);
    }
}

