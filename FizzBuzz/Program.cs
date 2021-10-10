using System;
using static FizzBuzz.Marathon;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            //Rules of FizzBuzz: (WikiPedia)
            //Players generally sit in a circle.
            //The player designated to go first says the number "1", and the players then count upwards in turn.
            //However, any number divisible by three is replaced by the word fizz
            //Any number divisible by five by the word buzz.
            //Numbers divisible by 15 become fizz buzz.
            //A player who hesitates or makes a mistake is eliminated from the game.
            //Wikipedia contributors. Fizz buzz [Internet]. Wikipedia, The Free Encyclopedia; 2021 Sep 25, 15:18 UTC [cited 2021 Oct 10]. Available from: https://en.wikipedia.org/w/index.php?title=Fizz_buzz&oldid=1046416644.
            Title();
            string input;
            while (true)
            {
                input = Console.ReadLine();
                if (input.ToLower() == "2" || input.ToLower() == "play")  OnePlayer();
                else if (input.ToLower() == "1" || input.ToLower() == "generate")
                {
                    bool loop = true;
                    while (loop == true)
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Let us generate a number!");
                            Console.WriteLine("Please input the smallest/start number.");
                            Console.Write("Smallest Number: ");
                            input = Console.ReadLine();
                            int start = Int32.Parse(input);
                            Console.SetCursorPosition(0, 1);
                            Console.WriteLine("Please input the largest/end number.          ");
                            Console.WriteLine("                                         ");
                            Console.SetCursorPosition(0, 2);
                            Console.Write("Biggest Number: ");
                            input = Console.ReadLine();
                            int end = Int32.Parse(input);
                            Console.Clear();

                            SequenticFizzBuzzGenerator(start, end);
                            loop = false;

                            Console.WriteLine("\n" +
                                "Click any button on your keyboard to return to menu...");
                            Console.ReadKey();
                            Title();
                        }
                        catch
                        {
                            IntegerError(input, 1);
                            Title();
                        }
                    }
                }

                else if (input.ToLower() == "3" || input.ToLower() == "rules")
                {
                    Console.Clear();
                    Console.WriteLine("" +
                    "Rules of FizzBuzz: (WikiPedia)\n" +
                    "Players generally sit in a circle.\n" +
                    "The player designated to go first says the number \"1\", and the players then count upwards in turn.\n" +
                    "However, any number divisible by three (3) is replaced by the word Fizz\n" +
                    "Any number divisible by five (5) by the word Buzz.\n" +
                    "Numbers divisible by fifteen (15) become FizzBuzz.\n" +
                    "A player who hesitates or makes a mistake is eliminated from the game.\n" +
                    "(Although the playable version in this exe does not have a timer and technically no multiplayer.)\n" +
                    "\n" +
                    "Wikipedia contributors. Fizz buzz [Internet]. (Slightly modified)\n" +
                    "Wikipedia, The Free Encyclopedia; 2021 Sep 25, 15:18 UTC [cited 2021 Oct 10].\n" +
                    "Available from: https://en.wikipedia.org/w/index.php?title=Fizz_buzz&oldid=1046416644.");
                    Console.WriteLine("\n" +
                        "Click any button on your keyboard to return...");
                    Console.ReadKey();
                    Console.Clear();
                    Title();
                }
                else
                {
                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("                                    ");
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("Please choose between 1, 2 or 3.");
                }
            }
        }

        /// <summary>
        ///Generates a sequence of numbers, Fizz, Buzz and FizzBuzz from 0 to a number of your choice.
        /// </summary>
        /// <param name="end"></param>
        static void SequenticFizzBuzzGenerator(int end)
        {
            SequenticFizzBuzzGenerator(0, end);
        }

        /// <summary>
        /// Generates a sequence of numbers, Fizz, Buzz and FizzBuzz between the numbers you have given it.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        static void SequenticFizzBuzzGenerator(int start, int end)
        {
            if (start > end)
            {
                Console.WriteLine("You did the reverse of what you were supposed to.\n" +
                    $"You made the \"Biggest Number\" lower than the \"Lowest Number\" (LN: {start}, BN: {end})\n" +
                    "Just imagine what would have happened to the program if I hadn't caught this!\n" +
                    "You could have KILLED my program!... GLaDOS were right... You are monsters...");
                int temp = start;
                start = end;
                end = temp;
            }

            {
                for (int i = start; i < end + 1; i++)
                {
                    string result = CheckFizzBuzz(i);
                    if (result == "useNumber")
                        Console.WriteLine(i);
                    else Console.WriteLine(result);
                }
            }
        }

        /// <summary>
        /// Checks for Fizz, Buzz, FizzBuzz or if normal number shall be used or not.
        /// Separated for potential player-engagement game-mode in the future.
        /// </summary>
        /// <param name="finput"></param>
        public static string CheckFizzBuzz(int finput)
        {
            if (finput == 0) return "useNumber";
            else if (finput % 15 == 0) return "FizzBuzz";
            else if (finput % 3 == 0) return "Fizz";
            else if (finput % 5 == 0) return "Buzz";
            else return "useNumber";
        }

        /// <summary>
        /// Used to display the "Main Menu"/"Title Screen". No need to write it 10 times.
        /// </summary>
        public static void Title()
        {
            Console.Clear();
            Console.WriteLine("Want to generate, play or view the rules of the game?");
            Console.WriteLine("(1=generate, 2=play, 3=rules)");
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("Code put together by ShiftTGC\n" +
                "\"Yes, I made this because of Tom Scott's FizzBuzz video.\"");
            Console.SetCursorPosition(0, 2);
        }
        /// <summary>
        /// Tells the user they have typed in something other than an integer and gives them a quick message if there is an error code
        /// </summary>
        /// <param name="input"></param>
        /// <param name="errorCode"></param>
        public static void IntegerError(string input, int errorCode)
        {
            Console.Clear();
            Console.WriteLine("ERROR: Oopsie woopsie, someone did a fucky wucky~ UwU\n");
            if (errorCode == 0) { Console.WriteLine($"Unknown integer error. Tell the developer \"errorCode 0, {input}\"\n"); }
            if (errorCode == 1) { Console.WriteLine("Unlike the Main Menu, the \"Lowest Number\" & \"Biggest Number\" has to be integers.\n"); }
            if (errorCode == 2) { Console.WriteLine("Unlike the Main Menu, your starting number has to be an integer.\n"); }
            Console.WriteLine("" +
                "If you don't know, an integer is a whole number, like \"1\", \"2\", \"3\",\"10\", \"20\", \"30\", \"123\" and so on.\n" +
                $"\"1.01\",\"0.99\", letters, words, commas, symbols and what you typed: \"{input}\"\n" +
                "These are NOT integer(s).\n" +
                "\n" +
                "Press a key to try again, but please use integers this time...");
            if (errorCode == 0) { Console.WriteLine("Due to it being an unknown integer error, program may crash\n"); }
            Console.ReadKey();
            Console.Clear();
        }
        public static void IntegerError(string input)
        { IntegerError(input, 0); }
        public static void IntegerError()
        { IntegerError("<no input>"); }

    }
}
