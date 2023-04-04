using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndscreenManager : MonoBehaviour
{
    GameManager gameManager;
    public TransitionManager transitionManager;
    public TMP_Text attempsText, timeText;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        attempsText.text = "Total attemps: " + gameManager.GetOverallAttemps().ToString();
        timeText.text = "Time: " + TimeSpan.FromSeconds(gameManager.GetOverallTime()).ToString("mm\\:ss");
    }
    
    public void ReturnToMenu()
    {
        transitionManager.StartTransition("Menu");
    }
}
