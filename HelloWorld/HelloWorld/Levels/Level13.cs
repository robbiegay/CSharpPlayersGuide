namespace CSharpPlayersGuide.Levels
{
    // Use /// to make XML documentation comments -- hover over the method to see the documentation
    /// <summary>
    /// Level 13 summary
    /// </summary>
    internal class Level13
    {
        // Notes:
        // A group of overloaded methods = a method group
        // Local functions cannot be overloaded

        // TakingANumber exercise
        public static int AskForNumber(string text)
        {
            Console.Write(text);

            return Convert.ToInt32(Console.ReadLine());
        }

        /// <summary>
        /// Returns a user inputted number
        /// </summary>
        /// <param name="text">Asks for a number in response to this text</param>
        /// <param name="min">Number must be greater than this value</param>
        /// <param name="max">Number must be less than this value</param>
        /// <returns></returns>
        public static int AskForNumberInRange(string text, int min, int max) 
        {
            var isValidNumber = false;
            int number = 0;

            while (!isValidNumber) 
            {
                Console.Write(text);

                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Utilities.PrintInColor("Invalid input. Please try again.", 1);
                }

                if (number > min && number < max) 
                    isValidNumber= true;
                else
                    Utilities.PrintInColor($"The number {number} is outside of the valid range ({min + 1}-{max - 1}).", 1);
            }

            return number;
        }

        public static void Countdown()
        {
            Console.WriteLine("The Countdown\n");
            Console.WriteLine("The writing on the wall of the tomb of Agol the Wise says");
            Console.WriteLine("that you must be able to write loops using recursion.\n");
            Console.WriteLine("Rewrite the following code using recursion:\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("""
for (int x = 10; x > 0; x--)
    Console.WriteLine(x);

""");
            Console.ForegroundColor = ConsoleColor.White;

            int countDownFrom = AskForNumberInRange("Enter a number that is > 0 and <= 1,000 to count down from: ", 0, 1_001);
            Console.WriteLine();

            RecursiveCountdown(countDownFrom);
        }

        /// <summary>
        /// Recursivly counts down from 10 - 1
        /// </summary>
        /// <param name="count">Count must be > 0 and <= 1,000</param>
        static void RecursiveCountdown(int count)
        {
            // Set some saftey parameters
            if (count > 1_000 || count < 1)
                return;

            Utilities.PrintInColor($"{count}...");

            if (count == 1)
                return;

            RecursiveCountdown(count - 1);
        }
    }
}
