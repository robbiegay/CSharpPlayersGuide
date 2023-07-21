using CSharpPlayersGuide.Extensions;
using System.Globalization;

namespace CSharpPlayersGuide.Levels
{
    internal class Level34 : ILevel // Added a Level interface
    {
        public static void Notes()
        {
            Utilities.PrintNotesTitle(34);

            //
            // -----------------------------------------------------
            //

            Console.WriteLine("Optional parameters:");
            void Test1(int optional = 4)
            {
                Console.WriteLine("Test1 = " + optional);
            }
            Utilities.PrintCode(
"""
void Test1(int optional = 4)
{
    Console.WriteLine(optional);
}
Test1();
Test1(5);
""");
            Test1();
            Test1(5);

            //
            // -----------------------------------------------------
            //

            Console.WriteLine("Named parameters allow them to be called in any order, often paired with default values:");
            void Test2(int a = 1, int b = 2, int c = 3)
            {
                Console.WriteLine($"Test2:\na: {a}\nb: {b}\nc: {c}");
            }
            Utilities.PrintCode(
"""
void Test2(int a = 1, int b = 2, int c = 3)
{
    Console.WriteLine($"Test2:\na: {a}\nb: {b}\nc: {c}");
}
Test2();
Test2(c: 5);
Test2(4, 5, 6);
Test2(c: 0, b: -1, a: -2);
""");
            Test2();
            Test2(c: 5);
            Test2(4, 5, 6);
            Test2(c: 0, b: -1, a: -2);

            //
            // -----------------------------------------------------
            //

            Console.WriteLine("'params' lets you call multiple variables, must be at the end");
            void Test3(int a, int b, params int[] more)
            {
                Console.WriteLine($"Test3:\na: {a}\nb: {b}");
                char c = 'c';
                foreach (var i in more ) 
                {
                    Console.WriteLine($"{c++}: {i}");
                }
            }
            Utilities.PrintCode(
"""
void Test3(int a, int b, params int[] more)
{
    Console.WriteLine($"Test3:\na: {a}\nb: {b}");
    char c = 'c';
    foreach (var i in more ) 
    {
        Console.WriteLine($"{c++}: {i}");
    }
}
Test3(1, 2);
Test3(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
""");
            Test3(1, 2);
            Test3(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

            //
            // -----------------------------------------------------
            //

            Console.WriteLine("You can pass by refererance using ref and out.");
            Console.WriteLine("Passing by ref is riskier but can make programs much faster");
            Console.WriteLine("if passing large structs OR doing frequent passing");
            void Test4(ref int x)
            {
                x *= 10;
            };
            void Test5(bool useBigNumber, out int x)
            {
                x = useBigNumber ? 10_000 : 1;
            };

            Utilities.PrintCode(
"""
void Test4(ref int x)
{
    x *= 10;
};
void Test5(bool useBigNumber, out int x)
{
    x = useBigNumber ? 10_000 : 1;
};

int x = 10;
Test4(ref x);
Console.WriteLine($"Test5: {x}"); // 100
Test4(ref x);
Console.WriteLine($"Test5: {x}"); // 1_000
Test5(false, out int y);
Console.WriteLine($"Test5: {y}"); // 1
Test4(ref y);
Console.WriteLine($"y should now be 10: {y}");
Test5(true, out y);
Console.WriteLine($"Test5: {y}"); // 10_000
""");

            int x = 10;
            Test4(ref x);
            Console.WriteLine($"Test5: {x}"); // 100
            Test4(ref x);
            Console.WriteLine($"Test5: {x}"); // 1_000
            Test5(false, out int y);
            Console.WriteLine($"Test5: {y}"); // 1
            Test4(ref y);
            Console.WriteLine($"y should now be 10: {y}");
            Test5(true, out y);
            Console.WriteLine($"Test5: {y}"); // 10_000

            //
            // -----------------------------------------------------
            //

            Console.WriteLine("You can add extenson methods like this:");
            Utilities.PrintCode(
"""
// Typically, put them in a file call [Type]Extensions.cs

internal static class StringExtensions // must be in a static class
{
    public static string ChangeToRob(this string text, bool makeRobbie = false) // must be a static method, with first (and only first param calling 'this'
    {
        if (makeRobbie)
            return "Robbie";

        return "Rob";
    }
}

var test = "test string";
Console.WriteLine($"Test: {test}");
Console.WriteLine($"Test.ChangeToRob(): {test.ChangeToRob()}");
Console.WriteLine($"Test.ChangeToRob(makeRobbie: true): {test.ChangeToRob(makeRobbie: true)}");
""");
            var test = "test string";
            Console.WriteLine($"Test: {test}");
            Console.WriteLine($"Test.ChangeToRob(): {test.ChangeToRob()}");
            Console.WriteLine($"Test.ChangeToRob(makeRobbie: true): {test.ChangeToRob(makeRobbie: true)}");

            //
            // -----------------------------------------------------
            //

            Console.WriteLine("");
            Console.WriteLine(
"""
Quiz: 

1: y, z
2: 1, 2, 4 
3: 2, 3, 9 
4: true
5: true
6: this
7: ref or out
8: b, c, d (did not know that d was valid)
""");
        }

        public static void SaferNumberCrunching()
        {
            while (true)
            {
                Console.WriteLine("Enter an int (e to exit):");
                var input = Console.ReadLine();
                if (input == "e") 
                {
                    break;
                }
                var didWork = int.TryParse(input, out int x);
                if (didWork)
                {
                    Utilities.PrintInColor($"Success, your number is: {x}", 6);
                }
                else
                {
                    Utilities.PrintInColor($"Error, {input} is not a valid int!", 1);
                }

                Console.WriteLine("Enter an double (e to exit):");
                var input2 = Console.ReadLine();
                if (input2 == "e")
                {
                    break;
                }
                var didWork2 = double.TryParse(input2, out double y);
                if (didWork2)
                {
                    Utilities.PrintInColor($"Success, your number is: {y}", 6);
                }
                else
                {
                    Utilities.PrintInColor($"Error, {input2} is not a valid double!", 1);
                }

                Console.WriteLine("Enter a bool (e to exit):");
                var input3 = Console.ReadLine();
                if (input3 == "e")
                {
                    break;
                }
                var didWork3 = bool.TryParse(input3, out bool z);
                if (didWork3)
                {
                    Utilities.PrintInColor($"Success, your value is: {z}", 6);
                }
                else
                {
                    Utilities.PrintInColor($"Error, {input3} is not a valid bool!", 1);
                }
            }
        }

        public static void BetterRandom()
        {
            Console.WriteLine("Random.NextDouble() only returns a value between 0 and 1");
            var r = new Random();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(r.NextDouble());
            }

            Console.WriteLine("");
            Console.WriteLine("Added an extension method that lets you set a max value for NextDouble()");
            int maxValue = 10;
            Console.WriteLine($"Max Value = {maxValue}");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(r.NextDouble(maxValue));
            }

            Console.WriteLine("");
            Console.WriteLine("Create an extension method for passing in strings and randomly selecting one.");
            var input = new string[] { "up", "down", "left", "right" };
            Console.Write("Input: ");
            foreach (var i in input) 
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(r.NextString(input));
            }

            Console.WriteLine("");
            Console.WriteLine("Added a CoidToss() extension with an optional parameter for the probabilityOfHeads");
            Console.WriteLine("Default 50% coin toss:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(r.CoinFlip());
            }

            for (double probabilityOfHeads = 0.0; probabilityOfHeads <= 1; probabilityOfHeads += 0.25)
            {
                Console.WriteLine($"{probabilityOfHeads}% chance of heads");
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(r.CoinFlip(probabilityOfHeads));
                }
            }
        }
    }
}
