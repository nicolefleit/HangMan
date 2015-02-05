using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HangMan
{
    class Program
    {
        static string playerName = "";
        static string[] Animals = { "Fox", "Wolf", "SnowLeopard", "Cheetah", "Tiger", "Lion", "Panther", "Hyena", "Zebra", "Horse", "Kangaroo", "Bear", "Snake" }; //Word Choices
        static string cpuWord;
        static int guessStart = 10;
        static int guessLeft = guessStart;
        static string currentLet;
        static List<string> guessList = new List<string>();
        static List<bool> boolList = new List<bool>();
        static bool iWin = false;
        /// <summary>
        /// This is HangMan!
        /// A classic hangman game (that i will base words on animals)
        /// BUT IN CODE FORM!!!
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            HangMan();
            Console.ReadKey();
        }
        static void HangMan()
        {
            Intro();
            LoadingAnim();

            Console.Clear();
            cpuChoice();

            Console.Clear();

            do
            {
                GamePlay();
            }
            while (iWin == false && guessLeft > 0);

            if (iWin)
            {
                Victory();
            }
            else
            {
                Defeat();
            }
        }
        static void Intro()
        {
            Printing("Welcome to the wonderful game of HangMan!");
            Thread.Sleep(1000);
            Printing("The theme of this HangMan game will be animals!");
            Thread.Sleep(500);
            Console.WriteLine();
            Printing("Before we start, what is your name?");
            Thread.Sleep(500);
            Console.WriteLine();
            Printing("--------");
            playerName = Console.ReadLine();
            Console.Clear();

            Printing("Welcome to the game, " + playerName + "! Lets name that animal shall we?");
            Console.WriteLine();
            Printing("But 1st, allow me to chose an animal...");
            Console.WriteLine();
            Thread.Sleep(300);
            LoadingAnim();
        }
        static void cpuChoice()
        {
            Random random = new Random(); //Random generator
            int index = random.Next(0, Animals.Length); // Setting the random choice to the options wihtin animals
            cpuWord = Animals[index].ToUpper(); // Cpu choice made here
            Printing("The animal has been chosen!");
            Thread.Sleep(500);

            var maskedList = new List<string>();
            for (var i = 0; i < cpuWord.Length; i++)
            {
                maskedList.Add("_ ");
            }
            for (var i = 0; i < cpuWord.Length; i++)
            {
                Console.Write(maskedList[i]);
                Thread.Sleep(100);
            };
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            GuessRecieved();
        }//The random word will be chosen here
        static void GamePlay()//This is the main screen that displays the current letters guessed, attempts, and correct letters
        {
            Printing("Ok then. This is what we have currently!");
            Console.WriteLine();
            //Getting good spacing
            PrintLetters();
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Current Guessed: ");
            for (int i = 0; i < guessList.Count; i++)
            {
                Console.Write(guessList[i] + ' ');
            }
            Console.WriteLine();
            Thread.Sleep(300);
            Console.WriteLine("Remaning Attempts: " + guessLeft);
            Thread.Sleep(300);
            Console.WriteLine();

            Console.WriteLine("________________________________________________________________");
            Console.WriteLine();
            Thread.Sleep(300);

            GuessRecieved();
        }
        static void GuessRecieved()
        {
            Printing("Time to guess! what would your letter or word be?");

            currentLet = Console.ReadLine().ToUpper(); // updates the current choice to new input
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(500);
            LoadingAnim();
            Thread.Sleep(400);
            Console.Clear();

            //Time to check if it matches the cpu word or letters
            //1st will be if its a word guess
            if (currentLet.Length > 1)
            {
                if (currentLet == cpuWord)
                {
                    iWin = true;
                }
                else
                {
                    Printing("That is not the same animal that was chosen... try another word or letter!");
                    Console.WriteLine();
                    Thread.Sleep(500);
                    guessLeft -= 1;
                    Console.WriteLine();
                    Printing("Press a key to continue!");
                    LoadingAnim();
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            if (currentLet.Length == 1)
            {
                guessList.Add(currentLet);//add letter to guess list
            }
            //now to see if the letter is equal to the chosen letter
            bool guessThere = false;
            for (int i = 0; i < cpuWord.Length; i++)
            {
                char y = cpuWord[i];
                if (currentLet.Where(x => x == y).Any())
                {
                    guessThere = true;
                }
            }
            if (!guessThere)
            {
                guessLeft -= 1;
                Printing("That letter is not within the chosen animal name. Try another!");
            }
            else
            {
                Printing("Great guess! Thats one down, keep going!");
            }

            Thread.Sleep(1300);//this delays for message to be read
            Console.Clear();

            if (TestGuessed())
            {
                iWin = true;
            }
        }//processed the guessed letter/word and puts it in guessed list
        static bool TestGuessed()
        {
            boolList.Clear();
            for (int i = 0; i < cpuWord.Length; i++)
            {
                if (guessList.Where(x => x == cpuWord[i].ToString()).Any())
                {
                    boolList.Add(true);
                }
                else
                {
                    boolList.Add(false);
                }
            }
            if (boolList.Where(i => i == false).Any())
            {
                return false;
            }
            else
            {
                return true;
            }
        }//checks the guessed letter/word for accuracy
        static void Printing(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(input[i]);
                Thread.Sleep(1);
            }
            Console.WriteLine();
        } //Printing animation for text
        static void PrintLetters()//This will print any correctly guessed letters in the word.
        {
            for (int i = 0; i < cpuWord.Length; i++)
            {
                string y = cpuWord[i].ToString();
                if (guessList.Where(x => x == y).Any())
                {
                    Console.Write(cpuWord[i] + " ");
                    Thread.Sleep(250);
                }
                else
                {
                    Console.Write("_ ");
                    Thread.Sleep(250);
                }
            }
        }
        static void LoadingAnim()
        {
            for (int i = 0; i < 30; i++)
            {
                Console.Write("_-");
                Thread.Sleep(40);
            }
            Console.Write(".");
        } // Fun little "Loading" animation. Idea borrowed from Dakota
        static void Victory()
        {
            Printing("That is correct! That is the animal that was chosen! Victory!");
            Printing("The amount of attempts remaing were: " + guessLeft + " out of " + guessStart);
            Console.WriteLine();
            Thread.Sleep(300);

            Printing("The correct word was the following!");
            Console.WriteLine();
            Printing(cpuWord);
            Thread.Sleep(500);
            Console.WriteLine();
            Console.WriteLine("That was a fun game! Should we play again?");
            guessLeft = guessStart;
            guessList.Clear();
            iWin = false;
            if (Console.ReadLine() != "no")
            {
                Console.WriteLine("Okay then! Try a new name instead of " + playerName + " this time!");
                Thread.Sleep(300);
                HangMan();
            }
            else
            {
                Console.WriteLine("Then stop pestering my animals! Goodbye!");
            }

        }
        static void Defeat()
        {
            Printing("Sorry, but you have failed to guess correctly in the amount of attempts");
            Thread.Sleep(300);
            Printing("Too bad... maybe next time.");
            Console.WriteLine();
            Printing("The correct word was the following!");
            Console.WriteLine();
            Printing(cpuWord);
            Thread.Sleep(500);
            Console.WriteLine();
            Console.WriteLine("That was a fun game! Should we play again?");
            guessLeft = guessStart;
            guessList.Clear();
            if (Console.ReadLine() != "no")
            {
                Console.WriteLine("Okay then! Try a new name instead of " + playerName + " this time!");
                Thread.Sleep(300);
                HangMan();
            }
            else
            {
                Console.WriteLine("Then stop pestering my animals! Goodbye!");
            }

        }
    }
}