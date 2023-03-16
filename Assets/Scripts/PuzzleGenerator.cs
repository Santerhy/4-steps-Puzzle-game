using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleGenerator : MonoBehaviour
{
    public List<GameObject> selectedButtons = new List<GameObject>();
    public GameObject buttonPrefab, buttonHolder;
    public int rows, columns;
    public Color defCol, green;
    // Start is called before the first frame update
    void Start()
    {
        green = Color.green;
        defCol = buttonPrefab.GetComponent<Image>().color;
        GeneratePuzzle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GeneratePuzzle()
    {
        for(int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                GameObject g = Instantiate(buttonPrefab, buttonHolder.transform);
                g.GetComponentInChildren<TMP_Text>().text =  "row: " + i.ToString() + " column: " + j.ToString();
                g.GetComponent<Button>().onClick.AddListener(delegate { ButtonFunction(g); });
            }
        }
    }

    public void ButtonFunction(GameObject b)
    {
        Debug.Log("Button pressed with text: " + b.GetComponentInChildren<TMP_Text>().text);
        if (selectedButtons.Contains(b))
        {
            b.GetComponent<Image>().color = defCol;
            selectedButtons.Remove(b);
        } else
        {
            b.GetComponent<Image>().color = green;
            selectedButtons.Add(b);
        }
        
    }
}
