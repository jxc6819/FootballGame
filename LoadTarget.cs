using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTarget : MonoBehaviour
{
    public void LoadScene(string TargetPractice)
    {
        SceneManager.LoadScene(TargetPractice);
    }
}
