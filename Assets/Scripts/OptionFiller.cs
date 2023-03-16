using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OptionFiller : MonoBehaviour
{
    public class Puzzle
    {
        public List<string> options= new List<string>();
        public List<string> correctOptions= new List<string>();
        public bool shuffle;
        public Puzzle(List<string> options, List<string> correctOptions, bool suf)
        {
            this.options = options;
            this.correctOptions = correctOptions;
            shuffle = suf;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        List<Puzzle> puzzleList = new List<Puzzle>();
        puzzleList.Add(FirstPuzzle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Puzzle FirstPuzzle()
    {
        List<string> options = new List<string>();
        List<string> correct = new List<string>();
        for(int i = 1; i < 25; i++)
        {
            if (i % 6 == 0)
                options.Add("6");
            else
                options.Add(i.ToString());
        }
        for (int i = 0; i < 4; i++)
            correct.Add("6");

        Puzzle p = new Puzzle(options, correct, false);
        return p;
    }

    Puzzle SecondPuzzle()
    {
        List<string> options = new List<string>();
        List<string> correct = new List<string>();

    }
}
