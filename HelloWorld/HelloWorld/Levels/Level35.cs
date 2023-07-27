using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayersGuide.Levels
{
    internal class Level35 : ILevel
    {
        public static void Notes()
        {
            Utilities.PrintNotesTitle(35);

            Console.WriteLine("Enter 'y' to attempt all errors");
            var input = Console.ReadLine();

            if (input == "y")
            {
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

            Console.WriteLine("\n\n");
            Console.WriteLine("Exception Guidelines:");
            Console.WriteLine("- Avoid catching all exceptions: catch (Exception)");
            Console.WriteLine("- Avoid swollowing exceptions: catch ([exp name]) { [do nothing] }");
            Console.WriteLine("- Only handle exception when you can address them: ie fix them or at least log the error (and maybe then throw the error again)");
            Console.WriteLine("- For saftey prgrams (where human injury is possible), you really want to have good error handling and fail safes");
            Console.WriteLine("- Favor the right exception (or custom) over generic Exception");
            Console.WriteLine("- Come back with your sheild or one it: Either work or handle the exception and put yourself back in");
            Console.WriteLine("  a consistant state using a finally block");
            Console.WriteLine();
            Console.WriteLine("More notes:");
            Console.WriteLine("Calling 'throw' by itself preserves the stack trace. Useful for when your error handling is just logging and wants to pass the error on up the stack");
            Console.WriteLine("When throwing a custom exception, you can keep the origional exception and pass it along as an innerException. Need to override to do this. You can auto gen them in VS");
            Console.WriteLine("A filter can be added to only catch when some bool condition is met: catch (Exception e) when (!string.IsNullOrEmpty(e.Message))");
            Console.WriteLine("\n\n");

            try
            {
                DoStuff();

                void DoStuff() => DoMoreStuff();
                void DoMoreStuff() => throw new Exception("Something terrible has happened...");
            }
            catch (Exception e) when (!string.IsNullOrEmpty(e.Message))
            {
                Console.WriteLine(e); // Calles the override of ToString that shows the stack trace
            }

            Console.WriteLine("To escape, enter a valid number, a non-number, and a number that is too big or too small");
            var isNumber = false;
            var isNonNumber = false;
            var isOverflow = false;

            while (!isNonNumber || !isNonNumber || !isOverflow)
            {
                Console.WriteLine("isNumber: " + isNumber);
                Console.WriteLine("isNonNumber: " + isNonNumber);
                Console.WriteLine("isOverflow: " + isOverflow);
                Console.WriteLine();
                Console.WriteLine("Enter a value from 0-255");
                var input2 = Console.ReadLine();

                try
                {
                    byte b = byte.Parse(input2);
                    
                    Utilities.PrintInColor("Entered a valid number", 3);
                    isNumber = true;
                }
                catch (FormatException e)
                {
                    Utilities.PrintInColor(e.Message, 1);
                    isNonNumber = true;
                }
                catch (OverflowException e)
                {
                    Utilities.PrintInColor(e.Message, 1);
                    isOverflow = true;
                }
                catch (Exception e)
                {
                    Utilities.PrintInColor(e.Message, 1);
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static void ExeptisGame()
        {
            var rnd = new Random();
            var cookieNumber = rnd.NextInt64(0, 10);
            var numbersPicked = new List<int>();
            var shouldCatch = false; // Just because I wanted to use an exception filter

            while (true)
            {
                Console.WriteLine("Number's picked:");
                foreach (var n in numbersPicked) 
                {
                    Console.WriteLine($"\t- {n}");
                }
                Console.WriteLine();

                Console.WriteLine("Pick a number between 0-9 inclusive:");
                var input = Console.ReadLine();
                var number = int.Parse(input);

                if (number < 0 || number > 9 || numbersPicked.Contains(number))
                {
                    Utilities.PrintInColor("Pick another number. You picked: " + number, 8);
                    continue;
                }

                numbersPicked.Add(number);

                try
                {
                    if (number == cookieNumber)
                    {
                        shouldCatch = true;
                        
                        var ex = new Exception("I added an inner exception, just because...");
                        throw new CookieException($"You picked the oatmeal cookie ({cookieNumber}), ew...", ex);
                    }
                }
                catch (CookieException e) when (shouldCatch)
                {
                    Console.WriteLine();
                    Utilities.PrintInColor("A Cookie exception was found!", 3);
                    Utilities.PrintInColor("");
                    Utilities.PrintInColor("Exception:", 1);
                    Utilities.PrintInColor(e.Message, 2);
                    Utilities.PrintInColor("");
                    Utilities.PrintInColor("Stack Trace:", 1);
                    Utilities.PrintInColor(e.ToString(), 2);
                    Utilities.PrintInColor("");
                    Utilities.PrintInColor("Inner exception:", 1);
                    Utilities.PrintInColor(e.InnerException.Message, 2);

                    break;
                }
            }
        }

        private class CookieException : Exception
        {
            public CookieException(string? message) : base(message)
            {
            }

            public CookieException(string? message, Exception? innerException) : base(message, innerException)
            {
            }

            protected CookieException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
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
