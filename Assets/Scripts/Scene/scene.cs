using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Test");
    }

    public void Quit()
    {
       Application.Quit();
    }
}
