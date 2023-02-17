namespace CSharpPlayersGuide.Levels
{
    internal class Level11
    {
        public static void ThePrototype()
        {
            int airshipLocation;

            do
            {
                Console.Write("User 1, enter a number between 0 and 100: ");
                int.TryParse(Console.ReadLine(), out airshipLocation);
            }
            while (airshipLocation < 0 || airshipLocation > 100);

            Console.Clear();
            Console.WriteLine("User 2, guess the number.");

            var userGuess = -1;
            while (airshipLocation != userGuess)
            {
                Console.Write("What is your next guess? ");
                int.TryParse(Console.ReadLine(), out userGuess);

                if (userGuess > airshipLocation)
                    Utilities.PrintInColor($"{userGuess} is too high.", 4);
                else if (userGuess < airshipLocation)
                    Utilities.PrintInColor($"{userGuess} is too low.", 4);
            }

            Utilities.PrintInColor("\nYou guessed the number!", 4);
        }

        public static void TheMagicCannon()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                    Utilities.PrintInColor($"{i}: Combined blast", 3);
                else if (i % 3 == 0)
                    Utilities.PrintInColor($"{i}: Fire", 1);
                else if (i % 5 == 0)
                    Utilities.PrintInColor($"{i}: Electric", 2);
                else
                    Utilities.PrintInColor($"{i}: Normal", 0);
            }
        }
    }
}
