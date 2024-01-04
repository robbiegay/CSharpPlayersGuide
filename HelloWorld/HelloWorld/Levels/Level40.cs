using System;

namespace CSharpPlayersGuide.Levels
{
    internal class Level40 : ILevel
    {
        public static void Notes()
        {
            Utilities.PrintNotesTitle(40);
            Console.WriteLine("You can pattern match using switch statements or expressions.");
            Console.WriteLine("");
            Console.WriteLine("An elegant way to use switch expressions for tic-tac-toe:");
            Utilities.PrintCode(
"""
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
""");
            Console.WriteLine("");
            Console.WriteLine("Game Results:");
            for (int i = 0; i < 9; i++)
            {
                var player1 = (Choice)(i % 3);
                var player2 = (Choice)(i / 3);
                var winner = DetermineWinner(player1, player2);
                Utilities.PrintInColor($"{player1.ToString().PadRight(10)} x {player2.ToString().PadRight(10)} => {winner}");
            }
            Console.WriteLine("");
            Console.WriteLine("Types of pattern matching:");
            Utilities.PrintCode(
"""
private static int GetPoints(Monster monster)
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
""");
            Console.WriteLine("");
            Utilities.PrintInColor(
                "GetPoints(new Dragon(Lifecycle.Ancient));".PadRight(55) + "=> " + 
                GetPoints(new Dragon(Lifecycle.Ancient)), 12);
            Utilities.PrintInColor(
                "GetPoints(new Dragon(Lifecycle.Adult));".PadRight(55) + "=> " +
                GetPoints(new Dragon(Lifecycle.Adult)), 12);
            Utilities.PrintInColor(
                "GetPoints(new Dragon(Lifecycle.Young));".PadRight(55) + "=> " +
                GetPoints(new Dragon(Lifecycle.Young)), 12);
            Utilities.PrintInColor(
                "GetPoints(new Dragon(Lifecycle.Egg));".PadRight(55) + "=> " +
                GetPoints(new Dragon(Lifecycle.Egg)), 12);
            Utilities.PrintInColor(
                "GetPoints(new Orc(new Sword(SwordLength.Magic));".PadRight(55) + "=> " +
                GetPoints(new Orc(new Sword(SwordLength.Magic))), 12);
            Utilities.PrintInColor(
               "GetPoints(new Orc(new Sword(SwordLength.WoodenStick));".PadRight(55) + "=> " +
               GetPoints(new Orc(new Sword(SwordLength.WoodenStick))), 12);
            for (int i = 9; i > 0; i -= 2)
            {
                Utilities.PrintInColor(
                   $"GetPoints(new Snake({i}));".PadRight(55) + "=> " +
                   GetPoints(new Snake(i)), 12);
            }
        }

        private static int GetPoints(Monster monster)
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
        private static Player DetermineWinner(Choice playerOne, Choice playerTwo)
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
            var p1 = new Potion();
            p1.Add(Ingredient.DragonBreath);

            Console.WriteLine("");
            var p2 = new Potion();
            p2.Add(Ingredient.Stardust);
            p2.Add(Ingredient.SnakeVenom);

            Console.WriteLine("");
            var p3 = new Potion();
            p3.Add(Ingredient.Stardust);
            p3.Add(Ingredient.DragonBreath);

            Console.WriteLine("");
            var p4 = new Potion();
            p4.Add(Ingredient.Stardust);
            p4.Add(Ingredient.ShadowGlass);
            p4.Add(Ingredient.EyeshineGem);
            p4.Add(Ingredient.Stardust);


            Console.WriteLine("");
            var p5 = new Potion();
            p5.Add(Ingredient.Stardust);
            p5.Add(Ingredient.EyeshineGem);
            p5.Add(Ingredient.ShadowGlass);
        }

        private class Potion
        {
            public PotionType Type { get; private set; }

            public Potion()
            {
                Type = PotionType.Water;
            }

            public void Add(Ingredient ingredient)
            {
                var oldType = Type;

                Type = (Type, ingredient) switch
                {
                    (PotionType.Water,            Ingredient.Stardust)       => PotionType.Elixir,
                    (PotionType.Elixir,           Ingredient.SnakeVenom)     => PotionType.Poison,
                    (PotionType.Elixir,           Ingredient.DragonBreath)   => PotionType.Flying,
                    (PotionType.Elixir,           Ingredient.ShadowGlass)    => PotionType.Invisibility,
                    (PotionType.Elixir,           Ingredient.EyeshineGem)    => PotionType.NightSight,
                    (PotionType.NightSight,       Ingredient.ShadowGlass)    => PotionType.CloudyBrew,
                    (PotionType.Invisibility,     Ingredient.EyeshineGem)    => PotionType.CloudyBrew,
                    (PotionType.CloudyBrew,       Ingredient.Stardust)       => PotionType.Wraith,
                    _                                                        => PotionType.Ruined
                };

                Utilities.PrintInColor($"You added {ingredient.ToString().PadRight(12)} to your {oldType.ToString().PadRight(12)} and got {Type}.", 9);
            }
        }

        private enum PotionType
        {
            Water,
            Elixir,
            Poison,
            Flying,
            Invisibility,
            NightSight,
            CloudyBrew,
            Wraith,
            Ruined
        }

        private enum Ingredient
        {
            Stardust,
            SnakeVenom,
            DragonBreath,
            ShadowGlass,
            EyeshineGem
        }

        
    }
}
