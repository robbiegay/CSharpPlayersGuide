namespace CSharpPlayersGuide.Levels
{
    internal class Level3
    {
        public static void HelloWorld()
        {
            Console.WriteLine("Hello, world!");
        }

        public static void WhatComesNext()
        {
            Console.WriteLine("Say something other than 'Hello, world!'");
        }

        public static void TheMakingsOfAProgrammer()
        {
            Console.WriteLine("Hello! I am in a C# RPG game"); // string literal
            Console.WriteLine("And I need a few statements");
            Console.WriteLine("2 more after this");
            Console.WriteLine("one more...");
            Console.WriteLine("done!");
        }

        // Notes:
        // . = member access operator
        // Code map: Base Class Library (BCL) -> system (namespace) -> Console (class) -> WriteLine (method)
        // BCL also includes things like Convert and Math classes

        public static void ConsolasAndTelim()
        {
            Console.WriteLine("Bread is ready.\nWho is the bread ready for?");
            string name = Console.ReadLine() ?? "default"; // compiler warning (could be an issue) vs a compiler error (wont compile)
            Console.WriteLine($"Notes: {name} got bread.");
        }

        // Notes:
        // Build configs -> release has code optimization turns on that will do things like remove unused variables. Good for releases but can make debugging harder
    }
}
