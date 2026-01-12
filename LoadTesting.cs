using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadTesting : MonoBehaviour
{
    public void LoadScene(string DevTest)
    {
        SceneManager.LoadScene(DevTest);
    }
}
