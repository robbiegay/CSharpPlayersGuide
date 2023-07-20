using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            // TODO: extension methods notes

            //
            // -----------------------------------------------------
            //

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
            // TODO: extension method notes and better random
        }
    }
}
