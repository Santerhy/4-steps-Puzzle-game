using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    GameManager gameManager;
    public TransitionManager transitionManager;
    public Button continueGame;
    public TMP_Text highscoreTimeText, highscoreAttempsText;
    public GameObject highscorePanel;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.LoadData();
        gameManager.StartMusic();
        if (gameManager.puzzleCounter >0)
            continueGame.gameObject.SetActive(true);
        gameManager.LoadHighscores();
        if (gameManager.highscoreAttemps > 0)
        {
            highscorePanel.gameObject.SetActive(true);
            highscoreAttempsText.text = "Attemps: " + gameManager.highscoreAttemps.ToString();
            highscoreTimeText.text = "Time: " + TimeSpan.FromSeconds(gameManager.highscoreTime).ToString("mm\\:ss");
        }

    }
    public void ContinueGame()
    {
        StartTransition();
    }

    public void EasyS() {
        gameManager.StartEasy();
        StartTransition();
    }

    public void NormalS() {
        gameManager.StartNormal();
        StartTransition();
    }

    private void StartTransition()
    {
        transitionManager.StartTransition("Gameplay");
    }
}
