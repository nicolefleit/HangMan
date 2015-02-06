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
        static string dustin = "Dustin";
       

        /// <summary>
        /// Classic Hangman
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            HangMan();
            
            Console.ReadKey();
        }

        /// <summary>
        /// Calls all functions to play Hangman
        /// </summary>
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
            
            Dustin();
            GuessRecieved();

        }

        /// <summary>
        /// Introduction before the game
        /// </summary>
        static void IntroHangman()
        {
            //Defining variables to use in the function
            string evilLaugh = "HAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAH";
            string answerNo = "Smart Choice";

            //Ask the user to play
            Printing("Do you want to play a game?\n Yes  No\n\n");
            //Store the user's answer
            string userInput = Console.ReadLine();
            //Various yes answers
            if(userInput == "Yes" || userInput == "yes" || userInput == "y" || userInput == "Y")
            {
                //Clear console and continue playing
                Console.Clear();
                bool answerYes = true;

                if(answerYes)
                {
                    //Print evili Laugh
                     Printing02(evilLaugh);
                     Printing02(evilLaugh);
                     Printing02(evilLaugh);
                     Console.Clear();
                    //Continue introductions
                     Printing("Let's get to know each other.");
                     Console.Clear();
                     Printing("What is your name?");
                    //store playerName
                     playerName = Console.ReadLine();
                     Console.Clear();
                     Printing("Let's begin " + playerName);
                     Console.Clear();
                    //stop and continue to game
                     playing = false;  
                    }

                }
                //Various no answers
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

         /// <summary>
        /// Choses a random word
        /// </summary>
        static void ComputerChoice()
        {
            //Create a new Random
            Random  rng = new Random();
            //define a variable and chose a word from the guessWords array
            int index = rng.Next(0, guessWords.Length);
            //use empty string cpuWord to store the guessWord
            cpuWord = guessWords[index].ToUpper();
            Printing("Good Luck...");
            System.Threading.Thread.Sleep(1000);
            //empty space in console
            Console.WriteLine();
            Console.WriteLine();

            //Create a hidden list to hide the word from the user
            var maskedList = new List<string>();
            //loop through the letters in the chosen word 
            for (var i = 0; i < cpuWord.Length; i++)
            {
                //replace a _ for every letter in the cpuWord
                maskedList.Add("_ ");
                Console.Write(maskedList[i]);
                System.Threading.Thread.Sleep(100);
            }

            Console.WriteLine(); //Extra space in console
            Console.WriteLine();
            Console.WriteLine();
        }


        static void PrintHangman (string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(input[i]);
  
                Console.WriteLine(@" ___________.._______
| .__________))______|
| | / /      ||
| |/ /       ||
| | /        ||
| |/         ||
| |          ||_  
| |          (   )
| |           `--'
| |        
| |       
| |      
| |     
| |         
| |          
| |         
| |          
| |         
""""""""""|         |""".PadLeft(100));

            }

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
Console.Write(@" _,   _,  _, __, _ _, _  _,
 |   / \ /_\ | \ | |\ | / _
 | , \ / | | |_/ | | \| \ /
 ~~~  ~  ~ ~ ~   ~ ~  ~  ~ 
        ");
                System.Threading.Thread.Sleep(20);
            }
            Console.Write(".");
        } // Fun little "Loading" animation.

        static void PrintLetters()//This will print any correctly guessed letters in the word.
        {
            for (int i = 0; i < cpuWord.Length; i++)
            {
                string y = cpuWord[i].ToString();
                if (guessList.Where(x => x == y).Any())
                {
                    Console.Write(cpuWord[i] + " ");
                    System.Threading.Thread.Sleep(250);
                }
                else
                {
                    Console.Write("_ ");
                    System.Threading.Thread.Sleep(250);
                }
            }
        }

        static void PlayGame()
        {
            Console.WriteLine();
            Console.WriteLine();

            Printing("Letters Guessed: ");
            for (int i = 0; i < guessList.Count; i++)
            {
                Console.Write(guessList[i] + ' ');
            }
            Console.WriteLine();
            Console.WriteLine();
            System.Threading.Thread.Sleep(300);
            Console.WriteLine("Remaning Attempts: " + guessLeft);
            System.Threading.Thread.Sleep(300);
            Console.WriteLine();

            GuessInput();

        }
        static void GuessInput()
        {
            currentLetter = Console.ReadLine().ToUpper();

            if(currentLetter.Length > 1)
            {
                if(currentLetter == cpuWord)
                {
                    iWin = true;
                }
                else
                {
                Printing("Not a bad guess... \n For a disowned child.");
                System.Threading.Thread.Sleep(300);
                iWin = false;
                Console.Clear();
                Console.WriteLine(@" ___________.._______
| .__________))______|
| | / /      ||
| |/ /       ||
| | /        ||.-''.
| |/         |/  _  \
| |          ||  `/,|
| |          (\\`_.'
| |         .-`--'.
| |        /Y . . Y\
| |       // |   | \\
| |      //  | . |  \\
| |     ')   |   |   (`
| |          ||'||
| |          || ||
| |          || ||
| |          || ||
| |         / | | \
""""""""""|_`-' `-' |""");
                Console.Clear();
                HangMan();
                }
            }

            if (currentLetter.Length == 1)
            {
                guessList.Add(currentLetter);
            }

        }

        static void Dustin()
        {
            if(playerName == "Dustin")
            {
                int timeLeft = 0;
                int startTime = 180;

                while(startTime >= timeLeft)
                {
                    startTime--;
                    timeLeft++;
                    System.Threading.Thread.Sleep(1000);

                    Console.WriteLine("Time Left: " + startTime);
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearCurrentConsoleLine();
                }
            }
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        static void GuessRecieved()
        {
            Printing("Guess a letter".PadLeft(45));

            currentLetter = Console.ReadLine().ToUpper();
            System.Threading.Thread.Sleep(500);
            Loading();
            System.Threading.Thread.Sleep(400);
            Console.Clear();
            
            //check to see if user guessed the word
            if(currentLetter.Length > 1)
            {
                if(currentLetter == cpuWord)
                {
                    iWin = true;
                }
                else
                {
                    Console.WriteLine("Death");
                }
            }
            if(currentLetter.Length == 1)
            {
                //if(currentLetter.Length == cpuWord[i].ToString();computer word at index i)
            }

        }

    }
}



