using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleGenerator : MonoBehaviour
{
    public List<GameObject> selectedButtons = new List<GameObject>();
    public GameObject buttonPrefab, buttonHolder, clickPreventPanel, levelClearPanel, easyPanel;
    public int buttonCount, puzzleCounter, tryCounter, correctTiles;
    public OptionFiller optionFiller;
    public Puzzle currentPuzzle;
    public GameManager gameManager;
    public TMP_Text puzzleTitle, puzzleHint, tryCounterText, timeText, easyText;
    public Sprite tileSelected, tileDefault, tileFalse, tileCorrect;
    public Sprite defaultTieRight, defaultTieLeft, defaultTieRL, selectedTieRight, selectedTieLeft, selectedTieRL, falseTieRight, falseTieLeft, falseTieRL, correctTieRight, correctTieLeft, correctTieRL;
    public Animator menuAnimator;
    private MusicPlayer musicPlayer;
    private SoundeffectPlayer soundeffectPlayer;
    public Timer timer;
    public bool normalMode, helpMenuOpen = false;
    public TransitionManager transitionManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        puzzleCounter = gameManager.GetPuzzleCounter(optionFiller.GetMaxPuzzle());
        puzzleTitle.text = "Puzzle " + (puzzleCounter + 1).ToString();
        GeneratePuzzle();
        if (currentPuzzle.shuffle)
            buttonHolder.GetComponent<GridLayoutGroup>().spacing = new Vector2(10, 20);
        puzzleHint.text = currentPuzzle.hint;
        //musicPlayer = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicPlayer>();
        //musicPlayer.PlayMusic();
        soundeffectPlayer = FindObjectOfType<SoundeffectPlayer>();
        tryCounter = 0;
        normalMode = gameManager.normalDifficulty;
    }

    void GeneratePuzzle()
    {
        currentPuzzle = optionFiller.GetPuzzle(puzzleCounter);

        for(int i = 0; i < buttonCount; i++)
        {
            GameObject g = Instantiate(buttonPrefab, buttonHolder.transform);
            g.GetComponentInChildren<TMP_Text>().text = currentPuzzle.options[i];
            g.GetComponent<Button>().onClick.AddListener(delegate { ButtonFunction(g); });
            if (!currentPuzzle.shuffle)
            {
                if ((i + 1) % 6 == 0)
                {
                    g.GetComponent<Image>().sprite = defaultTieLeft;
                    g.GetComponent<ButtonData>().spriteType = 1;
                }
                else if ((i + 1) % 6 == 1)
                {
                    g.GetComponent<Image>().sprite = defaultTieRight;
                    g.GetComponent<ButtonData>().spriteType = 0;
                }
                else
                {
                    g.GetComponent<Image>().sprite = defaultTieRL;
                    g.GetComponent<ButtonData>().spriteType = 2;
                }
            }
                
        }
    }

    public void ButtonFunction(GameObject b)
    {
        //soundeffectPlayer.PlayClick();
        if (selectedButtons.Contains(b))
        {
            if (currentPuzzle.shuffle)
            {
                b.GetComponent<Image>().sprite = tileDefault;
                
            } else
            {
                int type = b.GetComponent<ButtonData>().spriteType;
                if (type == 0)
                    b.GetComponent<Image>().sprite = defaultTieRight;
                else if (type == 1)
                    b.GetComponent<Image>().sprite = defaultTieLeft;
                else
                    b.GetComponent<Image>().sprite = defaultTieRL;
            }
            selectedButtons.Remove(b);
        } else
        {
            if (currentPuzzle.shuffle)
            {
                b.GetComponent<Image>().sprite = tileSelected;
            } else
            {
                int type = b.GetComponent<ButtonData>().spriteType;
                if (type == 0)
                    b.GetComponent<Image>().sprite = selectedTieRight;
                else if (type == 1)
                    b.GetComponent<Image>().sprite = selectedTieLeft;
                else
                    b.GetComponent<Image>().sprite = selectedTieRL;
            }
            selectedButtons.Add(b);
        }

        if (selectedButtons.Count >= 4)
        {
            if (CheckAnswers())
                LevelCleared();
            else
                ResetPuzzle();

        }
    }

    private void LevelCleared()
    {
        tryCounter++;
        soundeffectPlayer.PlayLevelClear();
        levelClearPanel.SetActive(true);
        clickPreventPanel.SetActive(true);
        menuAnimator.SetTrigger("OpenMenu");
        tryCounterText.text = "Attempts: " + tryCounter.ToString();
        timeText.text = "Time: " + TimeSpan.FromSeconds(timer.GetTime()).ToString("mm\\:ss");
        easyPanel.gameObject.SetActive(false);
        foreach (GameObject g in selectedButtons)
        {
            if (currentPuzzle.shuffle)
                g.GetComponent<Image>().sprite = tileCorrect;
            else
            {
                int type = g.GetComponent<ButtonData>().spriteType;
                if (type == 0)
                    g.GetComponent<Image>().sprite = correctTieRight;
                else if (type == 1)
                    g.GetComponent<Image>().sprite = correctTieLeft;
                else
                    g.GetComponent<Image>().sprite = correctTieRL;
            }
        }
    }

    public void NextPuzzle()
    {
        soundeffectPlayer.PlayClick();
        gameManager.SaveStats(tryCounter, timer.GetTime());
        transitionManager.StartTransition(gameManager.GetNextScene());
    }

    private void ResetPuzzle()
    {
        soundeffectPlayer.PlayFail();
        tryCounter++;
        clickPreventPanel.SetActive(true);
        foreach (GameObject g in selectedButtons)
        {
            if (currentPuzzle.shuffle)
                g.GetComponent<Image>().sprite = tileFalse;
            else
            {
                int type = g.GetComponent<ButtonData>().spriteType;
                if (type == 0)
                    g.GetComponent<Image>().sprite = falseTieRight;
                else if (type == 1)
                    g.GetComponent<Image>().sprite = falseTieLeft;
                else
                    g.GetComponent<Image>().sprite = falseTieRL;
            }
            g.GetComponent<Animator>().SetTrigger("Fail");
        }
        if (!normalMode)
        {
            easyPanel.gameObject.SetActive(true);
            easyText.text = "Correct tiles in last try: " + correctTiles.ToString();
        }
        StartCoroutine(ButtonsDisabled());
    }

    IEnumerator ButtonsDisabled()
    {
        yield return new WaitForSeconds(1);
        if (!helpMenuOpen)
            clickPreventPanel.SetActive(false);
        foreach (GameObject g in selectedButtons)
        {
            if (currentPuzzle.shuffle)
                g.GetComponent<Image>().sprite = tileDefault;
            else
            {
                int type = g.GetComponent<ButtonData>().spriteType;
                if (type == 0)
                    g.GetComponent<Image>().sprite = defaultTieRight;
                else if (type == 1)
                    g.GetComponent<Image>().sprite = defaultTieLeft;
                else
                    g.GetComponent<Image>().sprite = defaultTieRL;
            }
        }
        selectedButtons.Clear();
    }

    private bool CheckAnswers()
    {
        int correct = 0;
        foreach(GameObject g in selectedButtons)
        {
            if (currentPuzzle.correctOptions.Contains(g.GetComponentInChildren<TMP_Text>().text))
                correct++;
        }
        correctTiles = correct;
        if (correct == 4)
            return true;
        else
            return false;
    }
}
