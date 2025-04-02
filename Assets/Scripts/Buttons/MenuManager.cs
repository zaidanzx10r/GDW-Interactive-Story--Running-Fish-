using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public LeaderboardManager leaderboardManager;

    public void PlayButton()
    {
        // Continues to Game scene
        Debug.Log("Pressed");
        SceneManager.LoadScene("LevelTest");
    }

    public void QuitButton()
    {
        // Ends game
        Debug.Log("pressed");
        Application.Quit();
    }

    public void CreditsButton()
    {
        // Goes to Credits scene
        SceneManager.LoadScene("Credits");
    }

    public void BackButton()
    {
        // Returns to Main Menu
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        Debug.Log("pressed");
        SceneManager.LoadScene("LevelTest");
    }

    public void SubmitScoreButton()
    {
        // Submits the player's final time to the leaderboard
        if (leaderboardManager != null)
        {
            leaderboardManager.SubmitScore(GlobalTimer.finalTime); // Submit the score to leaderboard
            Debug.Log($"Score submitted: {GlobalTimer.finalTime}");
        }
        else
        {
            Debug.LogWarning("LeaderboardManager is not assigned!");
        }
    }

    public void LeaderboardButton()
    {
        SceneManager.LoadScene("Leaderboard");
    }
}
