using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;


public class OptionFiller : MonoBehaviour
{
    
    List<Puzzle> puzzleList = new List<Puzzle>();
    // Start is called before the first frame update
    void Start()
    {
        puzzleList.Add(EverySixth());
        puzzleList.Add(HighestOfRow());
        puzzleList.Add(Bills());
        puzzleList.Add(Typos());
        puzzleList.Add(EvenNumbers());
        puzzleList.Add(Tens());
        puzzleList.Add(SNumbers());
        puzzleList.Add(PrimeNumbers());
    }

    public Puzzle GetPuzzle(int index)
    {
        if (puzzleList[index].shuffle)
            Shuffle(puzzleList[index].options);

        return puzzleList[index];
    }
    public int GetMaxPuzzle()
    {
        return puzzleList.Count - 1;
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

    Puzzle EverySixth()
    {
        //Every sixth is six
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
        string hint = "If only you had a sixth sense";

        Puzzle p = new Puzzle(options, correct, false, hint);
        return p;
    }

    Puzzle HighestOfRow()
    {
        //Highest of row
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

        string hint = "The higher they fly...";

        Puzzle p = new Puzzle(options, correct, false, hint);
        return p;
    }

    Puzzle Bills()
    {
        //Bills
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

        string hint = "Remember to pay your bills";

        Puzzle p = new Puzzle(options, correct, true, hint);
        return p;
    }

    Puzzle Typos()
    {
        //Typos
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

        string hint = "This one is a real mytsery";

        Puzzle p = new Puzzle(options, correct, true, hint);
        return p;
    }

    Puzzle PrimeNumbers()
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

        string hint = "This is your prime moment";

        Puzzle p = new Puzzle(options, correct, true, hint);
        return p;
    }

    Puzzle EvenNumbers()
    {
        List<string> options = new List<string>
{
    "27", "73", "91", "11", "51", "59", "79", "61", "83", "9", "3", "67", "87", "19", "71", "93", "49", "75", "39", "97", "8", "44", "70", "98"
};
        List<string> correct = new List<string>();

        correct.Add("8");
        correct.Add("44");
        correct.Add("70");
        correct.Add("98");

        string hint = "You could say that the odds are even in this one";

        Puzzle p = new Puzzle(options, correct, true, hint);
        return p;
    }

    Puzzle Tens()
    {
        List<string> options = new List<string>
        {
            "37", "53", "95", "79", "33", "91", "57", "93", "71", "47", "51", "63", "27", "73", "43", "77", "19", "61", "89", "67", "30", "40", "60", "90"
        };
        List<string> correct = new List<string>
        {
            "30", "40", "60", "90"
        };

        string hint = "Can you feel the tension?";

        Puzzle p = new Puzzle(options, correct, true, hint);
        return p;
    }

    Puzzle SNumbers()
    {
        List<string> options = new List<string>
        {
            "14", "35", "46", "59", "28", "25", "86", "93", "37", "48", "91", "52", "13", "54", "89", "26", "38", "31", "82", "97", "69", "61", "77", "16"
        };

        List<string> correct = new List<string>
        {
            "69", "61", "77", "16"
        };

        string hint = "Samantha sells sea shells so successfully, she sometimes stocks surplus supplies.";

        Puzzle p = new Puzzle(options, correct, true, hint);
        return p;
    }
}
