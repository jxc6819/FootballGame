using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeBack : MonoBehaviour
{
    public bool isClicked;
    public GameObject MainMenu;
    public GameObject ArcadeMenu;

    void Update()
    {
        if (isClicked == true)
        {
            MainMenu.SetActive(true);
            ArcadeMenu.SetActive(false);
        }
    }
}
