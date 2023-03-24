using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int puzzleCounter, maxPuzzleCount, tryCounter;

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(this.gameObject); }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public int GetPuzzleCounter(int maxPuzzles)
    {
        maxPuzzleCount= maxPuzzles;
        return puzzleCounter;
    }

    public void LoadNextPuzzle(int trys)
    {
        tryCounter += trys;
        if (maxPuzzleCount == puzzleCounter)
            SceneManager.LoadScene("Endscreen");
        else
        {
            puzzleCounter++;
            SceneManager.LoadScene("Gameplay");
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
