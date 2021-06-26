using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goBack : MonoBehaviour
{
    public void goEnglish()
    {
        FindObjectOfType<AudioManager>().Play("button");
        SceneManager.LoadScene(1);
    }
    public void goMath()
    {
        FindObjectOfType<AudioManager>().Play("button");
        SceneManager.LoadScene(2);
    }
    public void goGeography()
    {
        FindObjectOfType<AudioManager>().Play("button");
        SceneManager.LoadScene(3);
    }
    public void goMenu()
    {
        FindObjectOfType<AudioManager>().Play("button");
        SceneManager.LoadScene(0);
    }
    public void quit()
    {
        FindObjectOfType<AudioManager>().Play("button");
        Application.Quit();
    }
}
