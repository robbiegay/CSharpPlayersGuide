﻿namespace CSharpPlayersGuide
{
    internal class Utilities
    {
        /// <summary>
        /// Prints in a message in color.
        /// </summary>
        /// <param name="message">The message to write</param>
        /// <param name="color">Optional (defaults to blue) -- 0: White, 1: Red, 2: Yellow, 3: Blue, 4: Cyan, 5: DarkGray, 6: DarkGreen, 7: Green, 8: Black, 9: DarkBlue, 10: DarkCyan, 11: DarkRed, 12: DarkMagenta, 13: DarkYellow, 14: Gray, 15: Magenta</param>
        /// <param name="writeToOneLine">Optional (defaults to false) -- True: Write(message), Fale: WriteLine(message)</param>
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
            else if (color == 8)
                Console.ForegroundColor = ConsoleColor.Black;
            else if (color == 9)
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            else if (color == 10)
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            else if (color == 11)
                Console.ForegroundColor = ConsoleColor.DarkRed;
            else if (color == 12)
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            else if (color == 13)
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            else if (color == 14)
                Console.ForegroundColor = ConsoleColor.Gray;
            else if (color == 15)
                Console.ForegroundColor = ConsoleColor.Magenta;

            if (!writeToOneLine)
                Console.WriteLine(message);
            else
                Console.Write(message);

            Console.ForegroundColor = ConsoleColor.White;
        }

        // Moved this to Utilities class because it spans multiple levels
        public static void PrintObjectOrientedPrinciples()
        {
            PrintInColor("The 5 Object-Oriented Principles:\n", 4);

            PrintInColor("1: Encapsulation\tCombining data (fields) and the operations on that", 2);
            PrintInColor("\t\t\tdata (methods) into a well-defined unit (like a class).", 2);
            Console.WriteLine();
            PrintInColor("2: Information Hiding\tOnly the object itself should directly access the data.", 2);
            Console.WriteLine();
            PrintInColor("3: Abstraction\t\tThe outside world does not need to know about the inner workings", 2);
            PrintInColor("\t\t\tof a class or object, but rather interacts through its public interface.", 2);
            PrintInColor("\t\t\tThis allows the public workings of the class to change without affecting anything else.", 2);
            Console.WriteLine();

            PrintInColor("TODO: Add the remaining principles...", 1);
        }
    }
}
