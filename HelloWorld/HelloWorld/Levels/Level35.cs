using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayersGuide.Levels
{
    internal class Level35 : ILevel
    {
        public static void Notes()
        {
            Utilities.PrintNotesTitle(35);

            Console.WriteLine("Attempting to throw all common exceptions");

            try
            {
                object[] x = new string[5];
                x[0] = "hi";
                x[1] = 123;
                x[2] = "hey";

                Utilities.PrintInColor($"No Error thrown");
            }
            catch (ArrayTypeMismatchException e)
            {
                Utilities.PrintInColor($"Error: {e.Message}", 1);
            }

            try
            {
                var y = 0;
                var x = 5 / y;

                Utilities.PrintInColor($"No Error thrown");
            }
            catch (DivideByZeroException e)
            {
                Utilities.PrintInColor($"Error: {e.Message}", 1);
            }

            try
            {
                var arr = new int[5];
                var x = arr[arr.Length];

                Utilities.PrintInColor($"No Error thrown");

            }
            catch (IndexOutOfRangeException e)
            {
                Utilities.PrintInColor($"Error: {e.Message}", 1);
            }

            try
            {
                object x = "hi";
                object y = (int)x;

                Utilities.PrintInColor($"No Error thrown");

            }
            catch (InvalidCastException e)
            {
                Utilities.PrintInColor($"Error: {e.Message}", 1);
            }

            try
            {
                object x = null;
                x.ToString();

                Utilities.PrintInColor($"No Error thrown");

            }
            catch (NullReferenceException e)
            {
                Utilities.PrintInColor($"Error: {e.Message}", 1);
            }

            try
            {
                var bigList = new List<int>();
                var keepGoing = true;
                while (keepGoing)
                {
                    bigList.Add(1);
                }

                Utilities.PrintInColor($"No Error thrown");

            }
            catch (OutOfMemoryException e)
            {
                Utilities.PrintInColor($"Error: {e.Message}", 1);
            }

            try
            {
                checked
                {
                    byte x = 255;
                    x++;
                }

                Utilities.PrintInColor($"No Error thrown");

            }
            catch (OverflowException e)
            {
                Utilities.PrintInColor($"Error: {e.Message}", 1);
            }

            try
            {
                // Will result in StackOverflow
                // StackOverflow cannot be caught by a catch block and will cause an application crash
                // Run at your own risk...
                //RecursiveMethod();

                Utilities.PrintInColor($"OverflowException code is commented out...", 2);

            }
            catch (StackOverflowException e)
            {
                Utilities.PrintInColor($"Error: {e.Message}", 1);
            }

            try
            {
                var test = new Test();

                Utilities.PrintInColor($"No Error thrown");

            }
            catch (TypeInitializationException e)
            {
                Utilities.PrintInColor($"Error: {e.Message}", 1);
            }

            try
            {
                int x = 10;
                int y = 0;
                int z = x / y;

                Utilities.PrintInColor($"No Error thrown");

            }
            catch (ArithmeticException e)
            {
                Utilities.PrintInColor($"Error: {e.Message}", 1);
            }
        }

        static void RecursiveMethod()
        {
            RecursiveMethod();
        }

        private class Test
        {
            static Test()
            {
                throw new Exception();
            }
        }
    }
}
