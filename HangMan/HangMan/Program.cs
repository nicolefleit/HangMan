using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class Program
    {
        static string playerName = "";
        static string[] guessWords = { "Inception", "Interstellar", "Terminator", "Alien", "Metropolis", "Stalker", "XMen", "Solaris", "Akira", "Her", "Frankenstein" };
        static string cpuWord;
        static int guessStart = 7;
        static int guessLeft = guessStart;
        static string currentLetter;
        static List<string> guessList =new List<string>();  
        static bool iWin = false;
        static bool playing = true;

        /// <summary>
        /// Classic Hangman
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            HangMan();

            Console.ReadKey();
        }

        static void HangMan ()
        {
            IntroHangman();
            Loading();
            Console.Clear();
            Loading();
            Console.Clear();
            Loading();
            Console.Clear();

            ComputerChoice();
            PlayGame();

        }
        static void IntroHangman()
        {

            string evilLaugh = "HAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAH";
            string answerNo = "Smart Choice";

                Printing("Do you want to play a game?\n Yes  No\n\n");
                
                string userInput = Console.ReadLine();

                if(userInput == "Yes" || userInput == "yes" || userInput == "y" || userInput == "Y")
                {
                    Console.Clear();
                    bool answerYes = true;

                    if(answerYes)
                    {
                        Printing02(evilLaugh);
                        Console.Clear();
                        Printing("Let's get to know each other.");
                        Console.Clear();
                        Printing("What is your name?");
                        playerName = Console.ReadLine();
                        Console.Clear();
                        Printing("Let's begin " + playerName);
                        Console.Clear();
                        playing = false;  
                    }

                }
                else if(userInput == "No" || userInput == "no" || userInput == "n" || userInput == "N")
                {
                    Console.Clear();
                    Printing(answerNo);
                    playing = false;
                }
                else
                {
                    Console.Clear();
                    Console.Write("");
                }
        }

        static void ComputerChoice()
        {
            Random  rng = new Random();
            int index = rng.Next(0, guessWords.Length);
            cpuWord = guessWords[index].ToUpper();
            Printing("Good Luck...");
            System.Threading.Thread.Sleep(1000);
            //empty space in console
            Console.WriteLine();
            Console.WriteLine();

            var maskedList = new List<string>();
            for (var i = 0; i < cpuWord.Length; i++)
            {
                maskedList.Add("_ ");
            }
            for (var i = 0; i < cpuWord.Length; i++)
            {
                Console.Write(maskedList[i]);
                System.Threading.Thread.Sleep(100);
            };
            Console.WriteLine(); //Extra space in console
            Console.WriteLine();
            Console.WriteLine();
        }


        static void Printing(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(input[i]);
                System.Threading.Thread.Sleep(100);
            }
            Console.WriteLine();
        }
        static void Printing02(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(input[i]);
                System.Threading.Thread.Sleep(20);
            }
            Console.WriteLine();
        }

        static void Loading()
        {
            for (int i = 0; i < 30; i++)
            {
                Console.Write("_-");
                System.Threading.Thread.Sleep(20);
            }
            Console.Write(".");
        } // Fun little "Loading" animation.

        static void PlayGame()
        {
            Printing("Letters Guessed: ");
            Printing("Guesses Left: ");
            

        }

    }
}


