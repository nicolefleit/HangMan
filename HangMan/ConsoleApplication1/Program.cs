﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    class HangmanWord
    {
        public string Word { get; set; }
        public HashSet<char> AllLetters { get; set; }
        public HashSet<char> WordLetters { get; set; }
        public int WrongCount { get; set; }
        public static readonly int MAX_WRONG_COUNT = 7;

        public HangmanWord(string word)
        {
            Word = word;
            WordLetters = new HashSet<char>();
            foreach (char c in Word)
            {
                if (!char.IsWhiteSpace(c))
                    WordLetters.Add(Char.ToUpper(c));
            }
            AllLetters = new HashSet<char>();
            WrongCount = 0;
        }

        public bool IsGuessed
        {
            get
            {
                return WordLetters.Count == 0;
            }
        }

        public bool IsGameOver
        {
            get
            {
                return WrongCount == MAX_WRONG_COUNT;
            }
        }

        public bool GuessLetter(char letter)
        {
            if (AllLetters.Contains(letter))
            {
                return false;
            }
            AllLetters.Add(letter);
            if (WordLetters.Contains(letter))
            {
                WordLetters.Remove(letter);
            }
            else
            {
                WrongCount++;
            }
            return true;
        }

        public string WordMask()
        {
            StringBuilder guess = new StringBuilder();
            for (int i = 0; i < Word.Length; i++)
            {
                char c = Word[i];
                c = Char.ToUpper(c);
                if (WordLetters.Contains(c))
                {
                    guess.Append("_");
                }
                else
                {
                    guess.Append(Word[i]);
                }
                if (i != Word.Length - 1)
                    guess.Append(" ");
            }
            return guess.ToString();
        }

        public string GuessedLettersMask()
        {
            StringBuilder res = new StringBuilder();
            for (char c = 'a'; c <= 'z'; c++)
            {
                if (AllLetters.Contains(c))
                {
                    res.Append(Char.ToUpper(c));
                }
                else
                {
                    res.Append("_");
                }
                res.Append(" ");
            }
            return res.ToString();
        }

        public void EndGame()
        {
            WordLetters.Clear();
        }
    }
}