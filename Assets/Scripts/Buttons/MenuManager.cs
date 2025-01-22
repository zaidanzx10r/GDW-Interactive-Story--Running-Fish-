using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayButton()
    {
        // Continues to Game scene
        Debug.Log("Pressed");
        SceneManager.LoadScene("GameScene");
    }

    //Ends game
    public void QuitButton()
    {
        Debug.Log("pressed");
        Application.Quit();
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        Debug.Log("pressed");
        SceneManager.LoadScene("MainMenu");

    }

    // Reset to beginning of Game scene
    public void ResetSceneButton()
    {
        SceneManager.LoadScene("GameScene");
    }


}
