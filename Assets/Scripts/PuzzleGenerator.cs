using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleGenerator : MonoBehaviour
{
    public List<GameObject> selectedButtons = new List<GameObject>();
    public GameObject buttonPrefab, buttonHolder, clickPreventPanel, levelClearPanel;
    public int buttonCount, puzzleCounter;
    public OptionFiller optionFiller;
    public Puzzle currentPuzzle;
    public GameManager gameManager;
    public TMP_Text puzzleTitle;
    public Sprite tileSelected, tileDefault, tileFalse;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        puzzleCounter= gameManager.puzzleCounter;
        puzzleTitle.text = "Puzzle: " + (puzzleCounter + 1).ToString();
        GeneratePuzzle();
    }

    void GeneratePuzzle()
    {
        currentPuzzle = optionFiller.GetPuzzle(puzzleCounter);

        for(int i = 0; i < buttonCount; i++)
        {
            GameObject g = Instantiate(buttonPrefab, buttonHolder.transform);
            g.GetComponentInChildren<TMP_Text>().text = currentPuzzle.options[i];
            g.GetComponent<Button>().onClick.AddListener(delegate { ButtonFunction(g); });
        }
    }

    public void ButtonFunction(GameObject b)
    {
        if (selectedButtons.Contains(b))
        {
            b.GetComponent<Image>().sprite =tileDefault;
            selectedButtons.Remove(b);
        } else
        {
            b.GetComponent<Image>().sprite = tileSelected;
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
        levelClearPanel.SetActive(true);
        clickPreventPanel.SetActive(true);
    }

    public void NextPuzzle()
    {
        gameManager.LoadNextPuzzle();
    }

    private void ResetPuzzle()
    {
        clickPreventPanel.SetActive(true);
        foreach (GameObject g in selectedButtons)
            g.GetComponent<Image>().sprite = tileFalse;
        StartCoroutine(ButtonsDisabled());
    }

    IEnumerator ButtonsDisabled()
    {
        yield return new WaitForSeconds(1);
        clickPreventPanel.SetActive(false);
        foreach (GameObject g in selectedButtons)
            g.GetComponent<Image>().sprite = tileDefault;
        selectedButtons.Clear();
    }

    private bool CheckAnswers()
    {
        foreach(GameObject g in selectedButtons)
        {
            if (!currentPuzzle.correctOptions.Contains(g.GetComponentInChildren<TMP_Text>().text))
                return false;
        }
        return true;
    }
}
