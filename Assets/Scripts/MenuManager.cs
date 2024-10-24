using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayButton()
    {
        Debug.Log("Pressed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Ends game
    public void QuitButton()
    {
        Debug.Log("pressed");
        Application.Quit();
    }

    public void GOQuitButton()
    {
        Debug.Log("pressed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ResetSceneButton()
    {
        SceneManager.LoadScene("GameScene");
    }

}
