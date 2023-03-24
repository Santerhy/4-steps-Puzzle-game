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

    public void LoadNextPuzzle(int trys, float time)
    {
        tryCounter += trys;
        overallTime += time;
        if (maxPuzzleCount == puzzleCounter)
            SceneManager.LoadScene("Endscreen");
        else
        {
            puzzleCounter++;
            SceneManager.LoadScene("Gameplay");
        }
    }

    public void StartEasy()
    {
        normalDifficulty = false;
        SceneManager.LoadScene("Gameplay");
    }

    public void StartNormal()
    {
        normalDifficulty = true;
        SceneManager.LoadScene("Gameplay");
    }

    public float GetOverallTime() { return overallTime; }

    public int GetOverallAttemps() { return tryCounter; }
}
