namespace CSharpPlayersGuide.Levels
{
    internal class Level9
    {
        // Notes:
        /*
        var t = 1;
        if (true)
        {
            t = 2;
        }
        Console.WriteLine(t);
        */

        public static void RepairingTheClocktower()
        {
            Console.Title = "The Great Clock of Consola";
            Console.WriteLine("Enter -1 to exit...");
            while (true)
            {
                Console.Write("Enter a number: ");
                int number;
                int.TryParse(Console.ReadLine(), out number);
                if (number == -1) break;

                bool isEven = number % 2 == 0;

                if (isEven)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Tick");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Tock");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        public static void Watchtower()
        {
            Console.Title = "The Watchtower";
            Console.WriteLine("\nConsolas is located at: 0, 0\n");
            Console.Write("Enter an x coordinate: ");
            int x;
            int.TryParse(Console.ReadLine(), out x);
            Console.Write("Enter an y coordinate: ");
            int y;
            int.TryParse(Console.ReadLine(), out y);

            Console.WriteLine($"Enemy location: {x}, {y}");

            Console.Write("The enemy is ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Green;

            if (x < 0 && y > 0)
                Console.Write("to the northwest!");
            else if (x < 0 && y == 0)
                Console.Write("to the west!");
            else if (x < 0 && y < 0)
                Console.Write("to the southwest!");
            else if (x == 0 && y > 0)
                Console.Write("to the north!");
            else if (x == 0 && y == 0)
                Console.Write("here!");
            else if (x == 0 && y < 0)
                Console.Write("to the south!");
            else if (x > 0 && y > 0)
                Console.Write("to the northeast!");
            else if (x > 0 && y == 0)
                Console.Write("to the east!");
            else if (x > 0 && y < 0)
                Console.Write("to the southeast!");

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.Write("\n\n");
        }
    }
}
