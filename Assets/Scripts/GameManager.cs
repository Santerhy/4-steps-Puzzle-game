using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int puzzleCounter, maxPuzzleCount, tryCounter;
    public float overallTime = 0;
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
            return "Endscreen";
        else
        {
            puzzleCounter++;
            return "Gameplay";
        }
    }

    public void StartEasy()
    {
        normalDifficulty = false;
    }

    public void StartNormal()
    {
        normalDifficulty = true;
    }

    public void StartMusic()
    {
        FindObjectOfType<MusicPlayer>().PlayMusic();
    }

    public float GetOverallTime() { return overallTime; }

    public int GetOverallAttemps() { return tryCounter; }
}
