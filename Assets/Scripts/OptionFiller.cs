using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OptionFiller : MonoBehaviour
{
    
    List<Puzzle> puzzleList = new List<Puzzle>();
    // Start is called before the first frame update
    void Start()
    {
        puzzleList.Add(FirstPuzzle());
        puzzleList.Add(SecondPuzzle());
        puzzleList.Add(ThirdPuzzle());
        puzzleList.Add(FourthPuzzle());
        puzzleList.Add(FifthPuzzle());
    }

    public Puzzle GetPuzzle(int index)
    {
        if (puzzleList[index].shuffle)
            Shuffle(puzzleList[index].options);

        return puzzleList[index];
    }

    private static void Shuffle(List<string> optionsList)
    {
        int n = optionsList.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n);
            string value = optionsList[k];
            optionsList[k] = optionsList[n];
            optionsList[n] = value;
        }
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

        options.Add("-5");
        options.Add("10");
        options.Add("-7");
        options.Add("22");
        options.Add("2");
        options.Add("23");
        correct.Add("23");

        correct.Add("66");
        options.Add("66");
        options.Add("4");
        options.Add("13");
        options.Add("54");
        options.Add("22");
        options.Add("3");

        options.Add("55");
        options.Add("43");
        correct.Add("150");
        options.Add("150");
        options.Add("88");
        options.Add("102");
        options.Add("6");

        options.Add("27");
        options.Add("-12");
        options.Add("65");
        correct.Add("73");
        options.Add("73");
        options.Add("-105");
        options.Add("59");

        Puzzle p = new Puzzle(options, correct, false);
        return p;
    }

    Puzzle ThirdPuzzle()
    {
        List<string> options = new List<string>();
        List<string> correct = new List<string>();

        correct.Add("5€");
        correct.Add("10€");
        correct.Add("20€");
        correct.Add("100€");

        options.Add("5€");
        options.Add("10€");
        options.Add("20€");
        options.Add("100€");
        options.Add("1€");
        options.Add("7€");
        options.Add("3€");
        options.Add("12€");
        options.Add("19€");
        options.Add("24€");
        options.Add("25€");
        options.Add("34€");
        options.Add("37€");
        options.Add("41€");
        options.Add("43€");
        options.Add("66€");
        options.Add("69€");
        options.Add("70€");
        options.Add("72€");
        options.Add("77€");
        options.Add("80€");
        options.Add("88€");
        options.Add("89€");
        options.Add("90€");

        Puzzle p = new Puzzle(options, correct, true);
        return p;
    }

    Puzzle FourthPuzzle()
    {
        List<string> options = new List<string>();
        List<string> correct = new List<string>();

        options.Add("three");
        options.Add("nine");
        options.Add("thirteen");
        options.Add("twenty-three");
        options.Add("thirty-one");
        options.Add("thirty-three");
        options.Add("forty");
        options.Add("forty-three");
        options.Add("forty-seven");
        options.Add("forty-nine");
        options.Add("fifty-five");
        options.Add("fifty-nine");
        options.Add("sixty-three");
        options.Add("sixty-nine");
        options.Add("seventy-three");
        options.Add("eighty-three");
        options.Add("eighty-seven");
        options.Add("ninety-one");
        options.Add("ninety-seven");
        options.Add("one hundred");
        options.Add("sevn");
        options.Add("elven");
        options.Add("tventu");
        options.Add("eighty-sex");

        correct.Add("sevn");
        correct.Add("elven");
        correct.Add("tventu");
        correct.Add("eighty-sex");

        Puzzle p = new Puzzle(options, correct, true);
        return p;
    }

    Puzzle FifthPuzzle()
    {
        //prime Numbers
        List<string> options = new List<string>();
        List<string> correct = new List<string>();

        options.Add("2");
        options.Add("3");
        options.Add("5");
        options.Add("7");
        options.Add("11");
        options.Add("13");
        options.Add("17");
        options.Add("19");
        options.Add("23");
        options.Add("29");
        options.Add("31");
        options.Add("37");
        options.Add("41");
        options.Add("43");
        options.Add("47");
        options.Add("53");
        options.Add("59");
        options.Add("61");
        options.Add("67");
        options.Add("71");
        options.Add("6");
        options.Add("8");
        options.Add("12");
        options.Add("18");

        correct.Add("6");
        correct.Add("8");
        correct.Add("12");
        correct.Add("18");

        Puzzle p = new Puzzle(options, correct, true);
        return p;
    }
}
