namespace CSharpPlayersGuide.Levels
{
    internal class BonusLevelCSharp12 : ILevel
    {
        public static void Notes()
        {
            int[] myArray1 = [1, 2, 3, 4];
            int[] myArray2 = [5, 6, 7, 8];
            int[] myArray3 = [9, 19, 11, 12];
            int[] myBigArray = [.. myArray1, .. myArray2, .. myArray3, 13, 14, 15, 16];

            Console.WriteLine(
                $$"""
                C# 12:

                collection expressions:
                int[] myArray = [1, 2, 3, 4];

                Can also use the range operator to unpack arrays into another array:

                int[] myArray1 = [1, 2, 3, 4];
                int[] myArray2 = [5, 6, 7, 8];
                int[] myArray3 = [9, 19, 11, 12];
                int[] myBigArray = [..myArray1, ..myArray2, ..myArray3, 13, 14, 15, 16];

                Print myBigArray:
                """);
                
            foreach (var item in myBigArray)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine("\n");

            Console.WriteLine(
                $$"""
                The code for the Hunted exercise is cool:

                int[] sequence = [4, 8, 15, 16, 23, 42];

                var iterations = 0;
                while (true)
                {
                    Utilities.TypewriterType($"{sequence[0]}, ", 100);

                    sequence = [..sequence[1..], sequence[0]];

                    if (iterations++ >= 20) break;
                }
                """);
        }

        public static void Hunted()
        {
            Utilities.PrintInColor("""
                The Manticore has sent spider-like machine to hunt you. To defeat them
                you must emit the following numbers in sequence: 4, 8, 15, 16, 23, 42.

                Note: will run for 20 iterations.
                """);

            int[] sequence = [4, 8, 15, 16, 23, 42];

            var iterations = 0;
            while (true)
            {
                Utilities.TypewriterType($"{sequence[0]}, ", 100);

                sequence = [..sequence[1..], sequence[0]];

                if (iterations++ >= 20) break;
            }
        }

        public static void ANightInTheWastelands()
        {
            Arrow a = new Arrow(Arrowhead.Obsidian, Fletching.TurkeyFeathers, 78);
            Console.WriteLine($"Arrowhead={a.Arrowhead} Fletching={a.Fletching} Length={a.Length}cm");
        }

        // Example code from the book, modified
        public class Arrow(Arrowhead arrowhead, Fletching fletching, float length)
        {
            public Arrowhead Arrowhead { get; } = arrowhead;
            public Fletching Fletching { get; } = fletching;
            public float Length { get; } = length;
        }
        public enum Arrowhead { Steel, Wood, Obsidian }
        public enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }
    }
}
