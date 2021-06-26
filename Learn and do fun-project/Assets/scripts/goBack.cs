using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goBack : MonoBehaviour
{
    public int teleportNumber;
    public int teleportNumber2;
    public void goEnglish()
    {
        FindObjectOfType<AudioManager>().Play("button");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + teleportNumber);
    }
    public void goMath()
    {
        FindObjectOfType<AudioManager>().Play("button");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + teleportNumber2);
    }
    public void quit()
    {
        FindObjectOfType<AudioManager>().Play("button");
        Application.Quit();
    }
}
