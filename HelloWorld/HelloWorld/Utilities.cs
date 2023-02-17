namespace CSharpPlayersGuide
{
    internal class Utilities
    {
        public static void PrintInColor(string message, int color)
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

            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
