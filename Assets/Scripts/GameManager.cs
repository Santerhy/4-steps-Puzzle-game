using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int puzzleCounter, maxPuzzleCount, tryCounter, highscoreAttemps;
    public float overallTime = 0, highscoreTime;
    public bool normalDifficulty;

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(this.gameObject); }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    
    public void ResetStats()
    {
        puzzleCounter = 0;
        maxPuzzleCount = 0;
        tryCounter = 0;
        overallTime = 0;
    }
    
    public int GetPuzzleCounter(int maxPuzzles)
    {
        maxPuzzleCount= maxPuzzles;
        return puzzleCounter;
    }

    public void SaveStats(int trys, float time)
    {
        tryCounter += trys;
        overallTime += time;
    }

    public string GetNextScene()
    {
        if (maxPuzzleCount == puzzleCounter)
        {
            SaveData();
            return "Endscreen";
        }
        else
        {
            puzzleCounter++;
            SaveData();
            return "Gameplay";
        }
    }

    public void StartEasy()
    {
        ResetStats();
        normalDifficulty = false;
    }

    public void StartNormal()
    {
        ResetStats();
        normalDifficulty = true;
    }

    public void StartMusic()
    {
        FindObjectOfType<MusicPlayer>().PlayMusic();
    }

    public float GetOverallTime() { return overallTime; }

    public int GetOverallAttemps() { return tryCounter; }

    public void SaveData()
    {
        PlayerPrefs.SetInt("PuzzleCounter", puzzleCounter);
        PlayerPrefs.SetFloat("OverallTime", overallTime);
        PlayerPrefs.SetInt("TryCounter", tryCounter);
        int difficulty = (normalDifficulty == true) ? 1 : 0;
        PlayerPrefs.SetInt("Difficulty", difficulty);
    }

    public void LoadData()
    {
        puzzleCounter = PlayerPrefs.GetInt("PuzzleCounter", 0);
        overallTime = PlayerPrefs.GetFloat("OverallTime", 0f);
        tryCounter = PlayerPrefs.GetInt("TryCounter", 0);
        normalDifficulty = (PlayerPrefs.GetInt("Difficulty", 0) == 1) ? true : false;
    }

    public void SaveHighscores()
    {
        if (GetOverallAttemps() < highscoreAttemps && GetOverallTime() < highscoreTime || highscoreAttemps == 0)
        {
            PlayerPrefs.SetInt("HighscoreAttemps", GetOverallAttemps());
            PlayerPrefs.SetFloat("HighscoreTime", GetOverallTime());
        }
    }

    public void LoadHighscores()
    {
        highscoreAttemps = PlayerPrefs.GetInt("HighscoreAttemps", 0);
        highscoreTime = PlayerPrefs.GetFloat("HighscoreTime", 0f);
    }
}
