using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePost : MonoBehaviour
{
    public GameObject postRoute;
    public GameObject streakRoute;
    public GameObject postPlayer;
    public GameObject streakPlayer;

    private void Start()
    {
        postRoute.SetActive(true);
        streakRoute.SetActive(false);
        postPlayer.SetActive(true);
        streakPlayer.SetActive(false);
    }
}
