namespace CSharpPlayersGuide
{
    internal class Utilities
    {
        // Make color optional and add a default value of 4
        public static void PrintInColor(string message, int color = 4, bool writeToOneLine = false)
        {
            if (color == 0)
                Console.ForegroundColor = ConsoleColor.White;
            else if (color == 1)
                Console.ForegroundColor = ConsoleColor.Red;
            else if (color == 2)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else if (color == 3)
                Console.ForegroundColor = ConsoleColor.Blue;
            else if (color == 4)
                Console.ForegroundColor = ConsoleColor.Cyan;
            else if (color == 5)
                Console.ForegroundColor = ConsoleColor.DarkGray;
            else if (color == 6)
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            else if (color == 7)
                Console.ForegroundColor = ConsoleColor.Green;

            if (!writeToOneLine)
                Console.WriteLine(message);
            else
                Console.Write(message);

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
