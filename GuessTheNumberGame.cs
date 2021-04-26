using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessing_Game
{
    class GuessTheNumberGame
    {
        private int GuessCount = 0; //counter for number of guesses
        private string input = string.Empty; //player input
        private int rightNumber = 0;  //data member to hold the secret number;
        private RangedRandomInteger secretNumberGenerator = new RangedRandomInteger();
        private bool validMenu;
        private const int MIN_MENU = 0;
        private const int MAX_MENU = 3;

        //default constructor
        public GuessTheNumberGame()
        {
            secretNumberGenerator.setMinimum(1);
        }

        //the play method controls the whole game. it will record the user's guess and contains the random number to be guessed.
        public void Play(int rightNumber)
        {
            int guess = 100;

            //restarting the guessCount and the rightGuess members
            GuessCount = 0;

            //looping through until the user finds the right guess
            do
            {
                Console.WriteLine("Enter your Guess here");
                try
                {
                    input = Console.ReadLine();
                    guess = Convert.ToInt32(input);
                }
                //handling the input error exceptions
                catch (Exception e)
                {
                    if (e is FormatException)
                    {
                        Console.Write("Invalid input: " + e.Message);
                    }
                    else
                    {
                        Console.Write("Number too high or too low: " + e.Message);
                    }
                }
                //exiting the game if the user inserts a lower/upper n
                if (input == "n" || input == "N")
                {
                    Console.WriteLine("You quit the game");
                    Console.WriteLine("\n");
                    Console.WriteLine($"Your total tries were: {GuessCount}. Try again later!");
                    break;
                }
                //setting conditionals for the user guess
                else if (guess < rightNumber)
                {
                    Console.WriteLine("Too low! Try again");
                    Console.WriteLine("\n");
                    GuessCount++; //incrementing the guess count 
                    //continuing the loop
                    continue;
                }
                else if (guess > rightNumber)
                {
                    Console.WriteLine("Too high! Try again");
                    Console.WriteLine("\n");
                    GuessCount++; // incrementing the guess count
                    continue;
                }
                else if (guess == rightNumber)
                {
                    //the user input is the same as the secret number
                    Console.WriteLine($"You rock! You guessed the number! {rightNumber}");
                    Console.WriteLine("\n");
                    GuessCount++;
                    Console.WriteLine($"Your total guesses were: {GuessCount}");
                    //setting the global variable to true
                    Console.WriteLine("\n");
                    Console.WriteLine("Play again? Press 1 to restart");
                    input = Console.ReadLine();
                    //restarting the game if the user wants to.
                    if (input == "1")
                    {
                        Start();
                    }

                }
            }
            //looping through while the guess matches the random number.
            while (guess != rightNumber);
        }
        public int Setup(int chosenOpt)
        {
            int generatedNumber = 1;
            //setup will change the difficulty level, based on the used choice.
            switch (chosenOpt)
            {
                case 0:
                    Console.WriteLine("Sorry to see you go, try again later");
                    validMenu = false;
                    break;
                case 1:
                    validMenu = true;
                    secretNumberGenerator.setMaximum(20);
                    generatedNumber = secretNumberGenerator.GenerateRandomNumber();
                    break;
                case 2:
                    validMenu = true;
                    secretNumberGenerator.setMaximum(100);
                    generatedNumber = secretNumberGenerator.GenerateRandomNumber();
                    break;
                case 3:
                    validMenu = true;
                    secretNumberGenerator.setMaximum(1000);
                    generatedNumber = secretNumberGenerator.GenerateRandomNumber();
                    break;
                default:
                    return 0;
            }
            rightNumber = generatedNumber;
            return rightNumber;
        }
        private int ShowMenu()   //show menu is responsible to show the menu and validate the user input.
        {
            //display menu code goes here
            //changing the background colour
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            //cleaning the console
            Console.Clear();
            //changing the letters colours
            Console.ForegroundColor = ConsoleColor.White;

            //showing the menu
            Console.WriteLine("                       PLEASE TRY YOUR GUESS                        ");
            Console.WriteLine("##----------------------------------------------------------------##");
            Console.WriteLine("##                                                                ##");
            Console.WriteLine("##                                                                ##");
            Console.WriteLine("##          1: Easy - Guess a number between 1 and 20             ##");
            Console.WriteLine("##                                                                ##");
            Console.WriteLine("##                                                                ##");
            Console.WriteLine("##          2: Medium - Guess a number between 1 and 100          ##");
            Console.WriteLine("##                                                                ##");
            Console.WriteLine("##                                                                ##");
            Console.WriteLine("##          3: Hard - Guess a number between 1 and 1000           ##");
            Console.WriteLine("##                                                                ##");
            Console.WriteLine("##                                                                ##");
            Console.WriteLine("##          0: Exit the game                                      ##");
            Console.WriteLine("##                                                                ##");
            Console.WriteLine("##----------------------------------------------------------------##");

            //local variable to hold the chosen option;
            int chosenOpt = 100;
            
            do
            {
                //reading the user's input
                Console.WriteLine("Choose your option");

                try
                {
                    input = Console.ReadLine();
                    chosenOpt = Convert.ToInt32(input);
                }

                catch (Exception e)
                {
                    if (e is FormatException)
                    {
                        Console.WriteLine("Invalid input: " + e.Message);
                    }
                    else
                    {
                        Console.WriteLine("Number too large or too low " + e.Message);
                    }
                }

                //verify the range
                validMenu = (chosenOpt >= MIN_MENU) && (chosenOpt <= MAX_MENU);

                if (!validMenu)
                {
                    Console.WriteLine("Please enter 0, 1, 2 or 3");
                    Console.WriteLine("\n");
                }

            } while (!validMenu);

            Console.Write($"Your option is: {chosenOpt} \n");
           return Setup(chosenOpt);
        }

        public void Start()
        {//this function is responsible to control the flow of the game
            do
            {//showing the menu until an unvalid menu option is inserted
                ShowMenu();
            }
            while (!validMenu);
            //caling the play method and assignemnt the number to be guessed.
            Play(rightNumber);
        }
    }
}
