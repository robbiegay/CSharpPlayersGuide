namespace CSharpPlayersGuide.Levels
{
    internal class Level8
    {
        // Notes:
        /*
        for (int i = 0; i < 1000; i++)
        {
            Console.ForegroundColor = (ConsoleColor)(i % 16);
            Console.BackgroundColor = (ConsoleColor)(i % 16);
            Console.WriteLine();
            Thread.Sleep(100);
        }

        var x = 5;
        Console.WriteLine($@"how to put x in \t {{{x}}}"); // {{ to escape to {
        Console.WriteLine(@"how to put x in \t {{{x}}}"); 
        Console.WriteLine($"how to put x in \t {{{x}}}"); 
        Console.WriteLine("how to put x in \t {{{x}}}"); 
        // @ means no escape chars
        // $ means -> can use {} to evaluate expressions in strings
        Console.ReadKey(true); // ReadKey(true) -> Read a key but don't write it to the console

        Console.WriteLine($"Formating numbers");
        Console.WriteLine($"{042.0100}");
        Console.WriteLine($"{042.0100:000.000000}"); // 0's = display digits no matter what
        Console.WriteLine($"{042.0100:###.######}"); // #'s = only display significant digits
        Console.WriteLine($"{042.0100:0.00%}"); // display a decimal as a percent
        Console.ReadKey(true);
        */

        public static void ColorsAndSounds()
        {
            // Create some rainbows
            for (int i = 0; i < 100; i++)
            {
                var colorNumber = i % 16;
                Console.Title = $"Adding color: {Enum.GetName(typeof(ConsoleColor), colorNumber)}";
                Console.BackgroundColor = (ConsoleColor)(colorNumber);
                Console.Write("                   ");
                Thread.Sleep(50);
            }

            // make some music
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Title = "Playing F\u00FCr Elise...";

            double bpm = 30;
            double quarter = (60 / bpm) * 1000;
            var eighth = quarter / 2;
            var sixteenth = quarter / 4;
            var half = quarter * 2;
            var whole = quarter * 4;

            var notes = new List<(int, double)>() {
                (659, sixteenth), // E5
                (622, sixteenth), // D#5
                (659, sixteenth), // E5
                (622, sixteenth), // D#5
                (659, sixteenth), // E5
                (493, sixteenth), // B4
                (587, sixteenth), // D5
                (523, sixteenth), // C5
                (440, eighth) // A4
            };

            for (int i = 0; i < notes.Count; i++)
            {
                var note = notes[i];
                Console.WriteLine($"freq: {note.Item1,5} -- duration: {note.Item2,5}"); // {x , [whitespace before word]}
                Console.Beep(note.Item1, (int)note.Item2);
            }
        }

        public static void TheDefenseOfConsolas()
        {
            Console.Title = "Defense of Consolas";
            Console.Write("Target Row? ");
            int targetRow;
            int.TryParse(Console.ReadLine(), out targetRow);
            Console.Write("Target Column? ");
            int targetColumn;
            int.TryParse(Console.ReadLine(), out targetColumn);
            Console.WriteLine("\nDeploy to:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"({targetRow}, {targetColumn - 1})");
            Console.WriteLine($"({targetRow - 1}, {targetColumn})");
            Console.WriteLine($"({targetRow}, {targetColumn + 1})");
            Console.WriteLine($"({targetRow + 1}, {targetColumn})");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Beep();
        }
    }
}
