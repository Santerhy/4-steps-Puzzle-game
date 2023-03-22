using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle
{
        public List<string> options = new List<string>();
        public List<string> correctOptions = new List<string>();
        public bool shuffle;
        public string hint;

        public Puzzle(List<string> options, List<string> correctOptions, bool suf, string h)
        {
            this.options = options;
            this.correctOptions = correctOptions;
            shuffle = suf;
            hint = h;
        }
    }

