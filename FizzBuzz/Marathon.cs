using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FizzBuzz.Program;

namespace FizzBuzz
{
    class Marathon
    {
        /// <summary>
        /// Currently there is only one player, but if there will be more, maybe something to figure out later.
        /// </summary>
        public static void OnePlayer()
        {
            bool loop2;
            loop2 = true;
            string input = null;
            while (loop2 == true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("" +
                        $"Hello, {Environment.UserName}!\n" +
                        "Welcome to FizzBuzz Marathon mode!\n" +
                        "\n" +
                        "Please enter from which number you want to start from:");
                    int number = Convert.ToInt32(input = Console.ReadLine());
                    Console.WriteLine("Have fun!");
                    loop2 = false;
                    System.Threading.Thread.Sleep(1000);
                    PlayGame(number);
                }
                catch
                {
                    IntegerError(input, 2);
                }
            }
        }

        /// <summary>
        /// Initiates the game (for OnePlayer). Requires a integer number which will be the input
        /// </summary>
        /// <param name="number"></param>
        static void PlayGame(int number)
        {
            string checkMe;
            int checkMeNumber;
            int currentNumber = number;
            int startingNumber = number;
            int score;
            string unecesaryDetails = "";
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.Write($"" +
                $"--------------------------------------------------\n" +
                $"|FizzBuzz Marathon!                              |\n" +
                $"|Current number is: {currentNumber}              |\n" +
                $"--------------------------------------------------\n" +
                $"Fizz, Buzz, FizzBuzz or <number>?\n" +
                $"Answer: ");
            ResetHUD(currentNumber);

            for (bool mistakeMade = false; mistakeMade == false;)
            {
                checkMe = Console.ReadLine();

                if (checkMe == Convert.ToString(currentNumber))
                {
                    checkMeNumber = currentNumber;
                    if (CheckCorrectness(checkMeNumber) == false) { mistakeMade = true; break; }
                }
                else if (checkMe.ToLower() != CheckFizzBuzz(currentNumber).ToLower()) { mistakeMade = true; break; }

                currentNumber++;
                ResetHUD(currentNumber);
            }
            string failReason = CheckFizzBuzz(currentNumber);
            if (failReason == "useNumber") failReason = Convert.ToString(currentNumber);
            Console.SetCursorPosition(0, 4);
            Console.WriteLine("Aaaaah, sorry about that, but that was wrong!");
            Console.WriteLine($"The Correct answer was: \"{failReason}\"");
            score = currentNumber - startingNumber;

            if (score == 0)
            {
                Console.WriteLine("\n" +
                    "Miss-types happens. And it sucks when it happens.\n" +
                    "At least it didn't happen while you were on a roll.\n" +
                    "\n" +
                    "In case you are unsure what the rules are, in the main menu, please type \"3\" or \"rules\" to view the rules.\n" +
                    "Additionally, right under the box that say you are playing Marathon mode, you get the \"permitted alternatives\".\n" +
                    "\n" +
                    "\"Fizz, Buzz, FizzBuzz or <number>?\" - These are the options you have to type in.\n" +
                    "(And no, you can type in lowercase, uppercase or a combination, exception being the number, which has to be an integer.)\n" +
                    "\n" +
                    "You may think \"why not just give me options like in the main menu?\"\n" +
                    "Well... I was considering it, but then I realized: You don't have a timer.\n" +
                    "So, in the end, I decided against it, for the sake of the challenge.");
                Console.WriteLine("\n" +
                    "Click any button on your keyboard to return to menu...");
                Console.ReadKey();
                Console.Clear();
                Title();
            }
            else
            {
                if (score != 1) unecesaryDetails = "s";
                Console.WriteLine("\n" +
                    $"You started from: {startingNumber}\n" +
                    $"And successfully knew/guessed {score} number{unecesaryDetails} from thereon!\n" +
                    $"Your score is therefore: {score}");
                Console.WriteLine($"\nThanks for playing, {Environment.UserName}!");
                Console.WriteLine("\n" +
                    "Click any button on your keyboard to return to menu...");
                Console.ReadKey();
                Console.Clear();
                Title();
            }
        }

        static bool CheckCorrectness(int number)
        {
            if ("useNumber" == CheckFizzBuzz(number)) return true;
            return false;
        }


        static void ResetHUD(int currentNumber)
        {
            {
                Console.SetCursorPosition(8, 5);
                Console.Write("                                                    ");
                Console.SetCursorPosition(20, 2);
                Console.Write("                                                    ");
                Console.SetCursorPosition(49, 2);
                Console.Write("|");
                Console.SetCursorPosition(20, 2);
                Console.Write(currentNumber);
                Console.SetCursorPosition(24, 4);
                Console.Write("                                                    ");
                Console.SetCursorPosition(24, 4);
                Console.Write($"{currentNumber}?");
                Console.SetCursorPosition(8, 5);
            }
        }
    }
}
