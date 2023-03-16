using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle
{
        public List<string> options = new List<string>();
        public List<string> correctOptions = new List<string>();
        public bool shuffle;
        public Puzzle(List<string> options, List<string> correctOptions, bool suf)
        {
            this.options = options;
            this.correctOptions = correctOptions;
            shuffle = suf;
        }
    }

