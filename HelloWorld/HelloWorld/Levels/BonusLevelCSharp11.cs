using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.Reflection;

namespace CSharpPlayersGuide.Levels
{
    internal class BonusLevelCSharp11 : ILevel
    {
        public static void Notes()
        {
            Console.WriteLine($$$"""""
                C# 11 Expansion:

                Raw string literal:
                Use """ to create a raw string literal:

                """
                This is a raw string literal
                    whitespace
                        like this
                            is respected
                Whitespace before the closing """ is ignored.

                Starting and ending """ must be on their own line.
                Escape chars are not honored.

                To include """ in a raw string literal, start and end with a
                matching number of ", 3 is just the minimum. This example text
                is wrapped in 5 double quotes.
                """

                $$$"""
                String interpolation is supported. If you need to have {}, then add 
                multiple $. This means braces equal to $ will be interpolated:

                Example: wrapping 3 + 4:
                {3 + 4}
                {{ 3 + 4 }}
                {{{ 3 + 4 }}}
                {{{{ 3 + 4 }}}}
                """

                -----------------------------------

                This is how I ran a string as code:

                Nuget: Microsoft.CodeAnalysis.CSharp.Scripting

                var options = ScriptOptions.Default
                    .AddReferences(Assembly.GetExecutingAssembly())
                    .AddImports("System");

                await CSharpScript.EvaluateAsync(program, options);

                -----------------------------------
                
                A good use for tuples is when you need to associate some data and 
                its not worth making a class. A good example is tuple parsing:

                while (true)
                {
                    Console.WriteLine("Enter a land type: ");
                    var input = Console.ReadLine();
                    (bool wasSuccessful, Land land) = input.ToLower() switch
                    {
                        "water" =>      (true, Land.Water),
                        "plain" =>      (true, Land.Plain),
                        "city" =>       (true, Land.City),
                        "mountain" =>   (true, Land.Mountain),
                        _ =>            (false, Land.Plain)
                    };

                    if (wasSuccessful)
                    {
                        Console.WriteLine($"You selected {land}!");
                        break;
                    }
                    else 
                        Console.WriteLine("Please enter a valid land type: water, plain, city, mountain.");
                }

                This is pretty neat as you can spin up a tuple to temporarily associate
                a value with the tuple parsing.
                """"");

            while (true)
            {
                Console.WriteLine("Enter a land type: ");
                var input = Console.ReadLine();
                (bool wasSuccessful, Land land) = input.ToLower() switch
                {
                    "water" =>      (true, Land.Water),
                    "plain" =>      (true, Land.Plain),
                    "city" =>       (true, Land.City),
                    "mountain" =>   (true, Land.Mountain),
                    _ =>            (false, Land.Plain)
                };

                if (wasSuccessful)
                {
                    Console.WriteLine($"You selected {land}!");
                    break;
                }
                else 
                    Console.WriteLine("Please enter a valid land type: water, plain, city, mountain.");
            }
        }

        public static async Task ProgramMakingProgram()
        {
            Utilities.PrintInColor("Warning: This program runs a raw string as code. This can be dangerous.\n\n", 1);

            Utilities.PrintInColor("Enter a unit (inches, feet, etc): ", 7, true);
            Console.ForegroundColor = ConsoleColor.Blue;
            var UNITS = Console.ReadLine();
            Console.ResetColor();

            Utilities.PrintInColor("Enter a C# numerical type (int, double, etc): ", 7, true);
            Console.ForegroundColor = ConsoleColor.Blue;
            var TYPE = Console.ReadLine();
            Console.ResetColor();

            var program = $$"""
                Console.WriteLine("Enter the width (in {{UNITS}}) of the triangle: ");
                {{TYPE}} width = {{TYPE}}.Parse(Console.ReadLine());
                Console.WriteLine("Enter the height (in {{UNITS}}) of the triangle: ");
                {{TYPE}} height = {{TYPE}}.Parse(Console.ReadLine());
                {{TYPE}} result = width * height / 2;
                Console.WriteLine($"{result} square {{UNITS}}");
                """;

            Console.WriteLine("Code output:\n");

            Utilities.PrintInColor(program, 7);

            Utilities.TypewriterType("\nPreparing to run program", 100, shouldAddNewline: false);
            Utilities.TypewriterType("...", 500);

            var options = ScriptOptions.Default
                .AddReferences(Assembly.GetExecutingAssembly())
                .AddImports("System");

            try
            {
                await CSharpScript.EvaluateAsync(program, options);
            }
            catch
            {
                Console.WriteLine("An exception was thrown while trying to run user generated code.");
            }
        }

        public static void TheMap()
        {
            var map = new Land[4, 8] { 
                { Land.Water, Land.Plain, Land.City, Land.Plain, 
                    Land.Water, Land.Plain, Land.Water, Land.Water },
                { Land.Mountain, Land.Plain, Land.Plain, Land.Plain, 
                    Land.Water, Land.Plain, Land.Plain, Land.Water },
                { Land.Water, Land.Mountain, Land.Plain, Land.Plain,
                    Land.Plain, Land.Plain, Land.Plain, Land.Plain, },
                { Land.Water, Land.Water, Land.Mountain, Land.City, 
                    Land.Mountain, Land.Water, Land.Water, Land.Water },
            };

            var index = 0;
            foreach (var space in map)
            {
                PrintLand(space);
                if (++index % 8 == 0) Console.Write("\n");
            }
        }

        private static void PrintLand(Land land)
        {
            Console.ForegroundColor = ConsoleColor.Black;

            Console.BackgroundColor = land switch
            {
                Land.Water => ConsoleColor.Blue,
                Land.City => ConsoleColor.Gray,
                Land.Plain => ConsoleColor.Yellow,
                Land.Mountain => ConsoleColor.Green
            };

            Console.Write(land switch
            {
                Land.Water => "~~",
                Land.City => "()",
                Land.Plain => "  ",
                Land.Mountain => "^^"
            });

            Console.ResetColor();
        }

        private enum Land
        {
            Water,
            City,
            Plain,
            Mountain
        }

        public static void PremixedPotions()
        {
            Utilities.PrintInColor("""
                Note: I'm not following this one fully, just doing the pattern matching part.

                Press 'Enter' to exit, 'backspace' to clear all keys.

                Some patterns:
                A..
                ..A
                TEST
                Y..Y
                """, 3);
            Console.WriteLine("");

            Console.WriteLine("");

            List<ConsoleKey> keys = new();

            while (true)
            {
                foreach (var key in keys)
                {
                    Utilities.PrintInColor($"{key} ", 7, true);
                }
                Console.WriteLine("\n");

                keys.Add(Console.ReadKey(true).Key);
                if (keys.Last() == ConsoleKey.Enter) break;
                if (keys.Last() == ConsoleKey.Backspace) keys.Clear();

                Utilities.PrintInColor(keys switch
                {
                    [] => "Empty",
                    [ConsoleKey.A, ..] => "Could be the alphabet...",
                    [.., ConsoleKey.A] => "Could be the alphabet... in reverse!",
                    [ConsoleKey.T, ConsoleKey.E, ConsoleKey.S, ConsoleKey.T] => "You must be running a TEST...",
                    [ConsoleKey.Y, .., ConsoleKey.Y] => "Starts and ends with Y!",
                    _ => "No pattern match found... yet!"
                }, 2);
            }
        }

        public static void BlastDamage()
        {
            Console.WriteLine("This exercise is for Generic Math. Honestly, just going to skip this one :)");
        }
    }
}
