namespace CSharpPlayersGuide.Levels
{
    internal class Level40 : ILevel
    {
        public static void Notes()
        {
            Utilities.PrintNotesTitle(40);
            Console.WriteLine("Pattern matching is cool. Below are the types you can match.");
            Console.WriteLine("You can also pattern match using switch statements or expressions");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

        }

        private int GetPoints(Monster monster)
        {
            return monster switch
            {
                Dragon { Age: Lifecycle.Adult or Lifecycle.Ancient } => 150, // Property, with and, or, not keywords
                Dragon                                               => 100, // Type
                Orc { SwordType.Length: SwordLength.Magic }          => 20, // Nested patterns
                Orc                                                  => 15,
                Snake s when s.Length > 5                            => 15, // gaurd expression or case guard
                Snake { Length: >= 3 }                               => 12, // Relational pattern
                Snake s                                              => (int)(s.Length * 1.25), // Declaration: gives a variable you can use
                //var x                                              => 2, // var pattern: matches anything and creates a variable that you can use.
                _                                                    => 1
            };
        }

        // 8.18.23
        // Robbie: This is so elegant...
        private Player DetermineWinner(Choice playerOne, Choice playerTwo)
        {
            return (playerOne, playerTwo) switch
            {
                (Choice.Rock,     Choice.Scissors)        => Player.One,
                (Choice.Paper,    Choice.Rock)            => Player.One,
                (Choice.Scissors, Choice.Paper)           => Player.One,
                (Choice a,        Choice b) when a == b   => Player.None, // could also use 'var'
                _                                         => Player.Two
            };
        }

        private enum Player { None, One, Two }
        private enum Choice { Rock, Paper, Scissors }

        private abstract record Monster;
        private record Dragon(Lifecycle Age) : Monster;
        private enum Lifecycle { Egg, Young, Adult, Ancient }
        private record Snake(int Length) : Monster;
        private record Orc(Sword SwordType) : Monster;
        private record Sword(SwordLength Length);
        private enum SwordLength { WoodenStick, Metal, Magic }

        public static void ThePotionMastersOfPattren()
        {
            throw new NotImplementedException();
        }
    }
}
