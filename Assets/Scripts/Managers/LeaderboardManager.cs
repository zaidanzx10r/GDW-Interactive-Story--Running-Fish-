using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderboardManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Transform nameList;
    public Transform scoreList;
    public TMP_InputField playerNameInput;

    private List<PlayerData> leaderboard = new();

    void Start()
    {
        LoadLeaderboard();
        DisplayLeaderboard();
    }

    public void SubmitScore(float score)
    {
        string playerName = playerNameInput.text;
        if (!string.IsNullOrEmpty(playerName))
        {
            // Add new player data to the leaderboard
            PlayerData newPlayer = new(playerName, score);
            leaderboard.Add(newPlayer);
            SortLeaderboard();
            SaveLeaderboard();
            DisplayLeaderboard();
        }
    }

    private void SortLeaderboard()
    {
        // Sort the leaderboard in ascending order by score
        leaderboard.Sort((a, b) => a.time.CompareTo(b.time));
        if (leaderboard.Count > 10)
        {
            leaderboard = leaderboard.GetRange(0, 10);
        }
    }

    private void DisplayLeaderboard()
    {
        for (int i = 0; i < nameList.childCount; i++)
        {
            if (i < leaderboard.Count)
            {
                // Update the name and time
                nameList.GetChild(i).GetComponent<TMP_Text>().text = leaderboard[i].name;
                scoreList.GetChild(i).GetComponent<TMP_Text>().text = FormatTime(leaderboard[i].time);
            }
            else
            {
                // Removes unused slots
                nameList.GetChild(i).GetComponent<TMP_Text>().text = "";
                scoreList.GetChild(i).GetComponent<TMP_Text>().text = "";
            }
        }
    }

    private void SaveLeaderboard()
    {
        for (int i = 0; i < leaderboard.Count; i++)
        {
            PlayerPrefs.SetString($"Leaderboard_Name_{i}", leaderboard[i].name);
            PlayerPrefs.SetFloat($"Leaderboard_Score_{i}", leaderboard[i].time);
        }
    }

    private void LoadLeaderboard()
    {
        leaderboard.Clear();
        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.HasKey($"Leaderboard_Name_{i}"))
            {
                // Load each player's data from PlayerPrefs
                string name = PlayerPrefs.GetString($"Leaderboard_Name_{i}");
                float score = PlayerPrefs.GetFloat($"Leaderboard_Score_{i}");
                leaderboard.Add(new PlayerData(name, score));
            }
        }
    }

    public void ClearLeaderboard()
    {
        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.DeleteKey($"Leaderboard_Name_{i}");
            PlayerPrefs.DeleteKey($"Leaderboard_Score_{i}");
        }
        PlayerPrefs.Save();
        leaderboard.Clear();
        DisplayLeaderboard();
        Debug.Log("Leaderboard cleared!");
    }

    private string FormatTime(float timeInSeconds)
    {
        float minutes = Mathf.FloorToInt(timeInSeconds / 60);
        float seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
