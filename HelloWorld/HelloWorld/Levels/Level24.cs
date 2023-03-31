using System.Reflection.Metadata.Ecma335;

namespace CSharpPlayersGuide.Levels
{
    internal static class Level24
    {
        public static void BossBattles()
        {
            Utilities.PrintInColor("Level 24 Boss Battles:", 2);
            Console.WriteLine("");
            Utilities.PrintInColor("The Point:", 4);
            var p1 = new Point(2, 3);
            var p2 = new Point(-4, 0);
            Console.WriteLine($"Point 1: X:{p1.X}, Y:{p1.Y}");
            Console.WriteLine($"Point 2: X:{p2.X}, Y:{p2.Y}");
            Console.WriteLine("X and Y are immutable because the design requierments did not say that they need to be changed: YAGNI");
            Console.WriteLine("");
            Utilities.PrintInColor("The Color:", 4);
            var c1 = new Color(-1, 256, 128); // Should change -1 to 0 and 256 to 255
            var c2 = Color.Purple;
            Console.WriteLine($"Color 1: red: {c1.R}, green: {c1.G}, blue: {c1.B}");
            Console.WriteLine($"Color 2: red: {c2.R}, green: {c2.G}, blue: {c2.B}");
            Console.WriteLine("");
            Utilities.PrintInColor("The Card", 4);
            Console.WriteLine("");
            var deck = new Deck();
            deck.CreateDeck();
            deck.ReadDeck();
            Console.WriteLine("");
            Console.WriteLine("We made color enum's in this challenge because color was limited to 4 options.");
            Console.WriteLine("In 'The Color' challenge, each of the 3 color channels had 256 possible values");
            Console.WriteLine("meaning that though we do technically have a finite set of possible colors,");
            Console.WriteLine("that set is 16 million in size so we probably don't want to use enums. That said,");
            Console.WriteLine("we did create a few static values for commonly used colors.");
            Console.WriteLine("");
            Utilities.PrintInColor("The Locked Door", 4);
            Console.WriteLine("");
            var door = new Door();
            var input = "";

            while (input != "e")
            {
                door.ChangeDoorState();

                Console.WriteLine("Type 'e' to exit");
                input = Console.ReadLine();
            }
            Console.WriteLine("");
            Utilities.PrintInColor("The Password Validator", 4);
            Console.WriteLine("");
            Utilities.PrintInColor("Rules:\n\t- Length: >= 6 and <= 13\n\t- Must have: 1 upper, 1 lower, 1 number\n\t- Cannot have: capital T, ampersand (&)", 2);
            Console.WriteLine("");

            var endPasswordLoop = "";

            while (endPasswordLoop != "e")
            {
                Console.WriteLine("Enter a password:");
                var password = Console.ReadLine();

                var isValid = PasswordValidator.IsValid(password);

                if (isValid)
                    Utilities.PrintInColor($"The password '{password}' is valid!", 7);
                else
                    Utilities.PrintInColor($"The password '{password}' is not valid!", 1);

                Console.WriteLine("Enter 'e' to exit");
                endPasswordLoop = Console.ReadLine();
            }

            Console.WriteLine("");
            Utilities.PrintInColor("Rock, Paper, Scissors", 4);
            Console.WriteLine("");
            var rpsDesignNotes =
"""
 Rock, Paper Scissors Design Reqs:
- Two human players
- 3 possible moves: Rock, Paper, Scissors
- A way to determine outcome: Win, Lost, Tie
- 3 possible outcomes: Win, Lose, Tie
- Display: who won
- Round Records

-------------------------------

Player Class:
- Name

Move Enum:
- Rock
- Paper
- Scissors

Result Enum:
- Win
- Lose
- Draw

 Game Class:
- Run() -> loops the game until asked to end
- Play() -> asks for user names, asks for user inputs, returns a game record
- Record
    - PlayerOneOutcome
    - PlayerTwoOutcome

- Outcome
    - Player
    - Result

    -> Some stuff that came up during implementation:
    - DetermineWinner() -> later decided to just include this logic in 'Play()'
    - PrintResults()
    - Changed 'Record' to have each player and their results as I thought that made more sense

Overall:
- I felt like my initial design got me about 80% there, and working through the implmentation resulted in changes to the remaining 20%.
- For a bigger project that this, doing a 'mock implementation' on a white board would probably help flesh out these changes while still being much faster that actual code.
""";
            Console.WriteLine(rpsDesignNotes);
            Console.WriteLine("");
            var game = new Game();
            game.Run();
        }
    }

    internal class Point
    {
        public int X { get; init; }
        public int Y { get; init; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point()
        {
            X = 0;
            Y = 0;
        }
    }

    internal class Color
    {
        public static Color White => new Color(255, 255, 255);
        public static Color Black => new Color(0, 0, 0);
        public static Color Red => new Color(255, 0, 0);
        public static Color Orange => new Color(255, 165, 0);
        public static Color Yellow => new Color(255, 255, 0);
        public static Color Green => new Color(0, 128, 0);
        public static Color Blue => new Color(0, 0, 255);
        public static Color Purple => new Color(128, 0, 128);

        private int _red;
        private int _green;
        private int _blue;

        public int R
        {
            get => _red;
            init
            {
                if (value < 0)
                    _red = 0;
                else if (value > 255)
                    _red = 255;
                else
                    _red = value;
            }
        }

        public int G
        {
            get => _green;
            init
            {
                if (value < 0)
                    _green = 0;
                else if (value > 255)
                    _green = 255;
                else
                    _green = value;
            }
        }
        public int B
        {
            get => _blue;
            init
            {
                if (value < 0)
                    _blue = 0;
                else if (value > 255)
                    _blue = 255;
                else
                    _blue = value;
            }
        }

        public Color(int red, int green, int blue)
        {
            R = red;
            G = green;
            B = blue;
        }
    }

    internal class Card
    {
        internal enum CardColor
        {
            Red = 1,
            Green = 2,
            Blue = 3,
            Yellow = 4
        }

        internal enum CardRank
        {
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Dollar = 11,
            Percent = 12,
            Carrot = 13,
            Ampersand = 14
        }

        private CardColor _color;
        private CardRank _rank;

        public CardColor Color
        {
            get
            {
                return _color;
            }
            init
            {
                _color = value;
            }
        }

        public CardRank Rank
        {
            get
            {
                return _rank;
            }
            init
            {
                _rank = value;
            }
        }

        public Card(CardColor color, CardRank rank)
        {
            Color = color;
            Rank = rank;
        }

        public void ReadCard()
        {
            var color = Color switch
            {
                CardColor.Red => 1,
                CardColor.Green => 7,
                CardColor.Blue => 3,
                CardColor.Yellow => 2
            };

            Utilities.PrintInColor($"\tThe {Color} {Rank}", color);
        }
    }

    internal class Deck
    {
        public List<Card> Cards;

        public Deck()
        {
            Cards = new List<Card>();
        }

        public void CreateDeck()
        {
            Utilities.PrintInColor("Creating a deck of cards...", 2);

            for (int i = 1; i <= 4; i++)
            {
                var color = (Card.CardColor)i;

                for (int j = 1; j <= 14; j++)
                {
                    var rank = (Card.CardRank)j;

                    Cards.Add(new Card(color, rank));
                }
            }
        }

        public void ReadDeck()
        {
            foreach (var card in Cards)
            {
                card.ReadCard();
            }
        }
    }

    internal class Door
    {
        internal enum DoorState
        {
            Open,
            Closed,
            Locked
        }

        private DoorState _state = DoorState.Closed;
        private string _passcode = "";

        public string Passcode
        {
            set
            {
                if (value.Length != 4)
                {
                    Utilities.PrintInColor($"Passcode must be 4 numbers in length. Invalid: {value}", 1);
                }
                else
                {
                    Utilities.PrintInColor("Enter the current passcode: ", 2);
                    var input = Console.ReadLine();

                    if (input == _passcode)
                    {
                        _passcode = value;
                    }
                    else
                    {
                        Utilities.PrintInColor("You entered the wrong value for the previous passcode", 1);
                    }
                }
            }
        }

        public DoorState State
        {
            get => _state;
        }

        public Door()
        {
            while (_passcode == "")
            {
                Utilities.PrintInColor("Enter a passcode:", 2);
                var passcode = Console.ReadLine();

                _passcode = passcode ?? "";
            }
        }

        public void ChangeDoorState()
        {
            Utilities.PrintInColor($"The door is: {State}", 15);

            Utilities.PrintInColor("Select an option:\n\t- 1 = lock door\n\t- 2 = unlock door\n\t- 3 = open door\n\t- 4 = close door\n\t- 5 = change passcode", 2);

            var input = Console.ReadLine();

            if (input == "5")
            {
                Utilities.PrintInColor("Enter the passcode:", 2);

                var passcode = Console.ReadLine() ?? "";

                Passcode = passcode;
                return;
            }

            if (State == DoorState.Locked)
            {
                if (input == "1")
                {
                    Utilities.PrintInColor("The door is already locked, you cannor lock it again...", 1);
                }
                else if (input == "2")
                {
                    Utilities.PrintInColor("Enter the passcode:", 2);

                    var passcode = Console.ReadLine();

                    if (passcode == _passcode)
                    {
                        _state = DoorState.Closed;
                        Utilities.PrintInColor("The door is unlocked...", 7);
                    }
                    else
                        Utilities.PrintInColor("Passcode incorrect!", 1);
                }
                else if (input == "3")
                {
                    Utilities.PrintInColor("You cannot open a locked door...", 1);
                }
                else if (input == "4")
                {
                    Utilities.PrintInColor("The door is already closed!", 1);
                }
                else
                    Utilities.PrintInColor("Unknown input: " + input, 1);
            }
            else if (State == DoorState.Closed)
            {
                if (input == "1")
                {
                    _state = DoorState.Locked;
                    Utilities.PrintInColor("The door is now locked...", 7);
                }
                else if (input == "2")
                {
                    Utilities.PrintInColor("The door is already unlocked!", 1);
                }
                else if (input == "3")
                {
                    _state = DoorState.Open;
                    Utilities.PrintInColor("The door is now open...", 7);
                }
                else if (input == "4")
                {
                    Utilities.PrintInColor("The door is already closed!", 1);
                }
                else
                    Utilities.PrintInColor("Unknown input: " + input, 1);
            }
            else if (State == DoorState.Open)
            {
                if (input == "1")
                {
                    Utilities.PrintInColor("You cannot lock an open door!", 1);
                }
                else if (input == "2")
                {
                    Utilities.PrintInColor("You cannot unlock an open door -- it is already unlocked!", 1);
                }
                else if (input == "3")
                {
                    Utilities.PrintInColor("You cannot open an open door -- it is already open!", 1);
                }
                else if (input == "4")
                {
                    _state = DoorState.Closed;
                    Utilities.PrintInColor("The door isnow closed...", 7);
                }
                else
                    Utilities.PrintInColor("Unknown input: " + input, 1);
            }
        }
    }

    internal class PasswordValidator
    {
        public static bool IsValid(string password)
        {
            if (password.Length < 6 || password.Length > 13)
                return false;

            var hasUpper = false;
            var hasLower = false;
            var hasNumber = false;
            var hasT = false;
            var hasAmpersand = false;

            foreach (var ch in password)
            {
                if (char.IsUpper(ch))
                    hasUpper = true;
                if (char.IsLower(ch))
                    hasLower = true;
                if (char.IsDigit(ch))
                    hasNumber = true;

                if (ch == 'T')
                    hasT = true;
                if (ch == '&')
                    hasAmpersand = true;
            }

            if (!hasUpper || !hasLower || !hasNumber || hasT || hasAmpersand)
                return false;

            return true;
        }
    }

    internal class Player
    {
        public string Name { get; set; }

        public Player(string name)
        {
            Name = name;
        }
    }

    internal enum Move
    {
        Rock,
        Paper,
        Scissors
    }

    internal enum Result
    {
        Win,
        Lose,
        Draw
    }

    internal class Game
    {
        public void Run()
        {
            Console.WriteLine("");
            Utilities.PrintInColor("-----------------------------------------------------", 14);
            Utilities.PrintInColor("--------------- Rock, Paper, Scissors ---------------", 7);
            Utilities.PrintInColor("-----------------------------------------------------", 14);
            Console.WriteLine("");
            var input = "";

            var gameRecords = new GameRecords();

            while (input != "e")
            {
                gameRecords.Records.Add(Play());
                PrintResults(gameRecords);

                Console.WriteLine("");
                Utilities.PrintInColor("Type 'e' to exit or any other key to play again!", 12);
                input = Console.ReadLine();
            }
        }

        private GameRecord Play()
        {
            Console.WriteLine("Player 1, enter your name:");
            var p1Name = Console.ReadLine();
            var p1 = new Player(p1Name);

            Console.WriteLine("Player 2, enter your name:");
            var p2Name = Console.ReadLine();
            var p2 = new Player(p2Name);

            var selection = "1 = Rock, 2 = Paper, 3 = Scissors";
            Console.WriteLine($"{p1.Name}, enter your selection: {selection}:");
            var p1Selection = Console.ReadLine();

            Move p1Move = p1Selection switch
            {
                "1" => Move.Rock,
                "2" => Move.Paper,
                "3" => Move.Scissors,
                _ => Move.Rock // Default
            };

            Console.WriteLine($"{p2.Name}, enter your {selection}:");
            var p2Selection = Console.ReadLine();

            Move p2Move = p2Selection switch
            {
                "1" => Move.Rock,
                "2" => Move.Paper,
                "3" => Move.Scissors,
                _ => Move.Rock // Default
            };

            var record = new GameRecord();
            record.PlayerOne = p1;
            record.PlayerTwo = p2;

            if ((p1Move == Move.Rock && p2Move == Move.Rock) || (p1Move == Move.Paper && p2Move == Move.Paper) || (p1Move == Move.Scissors && p2Move == Move.Scissors))
            {
                record.PlayerOneResult = Result.Draw;
                record.PlayerTwoResult = Result.Draw;
            }
            else if ((p1Move == Move.Rock && p2Move == Move.Scissors) || (p1Move == Move.Paper && p2Move == Move.Rock) || (p1Move == Move.Scissors && p2Move == Move.Paper))
            {
                record.PlayerOneResult = Result.Win;
                record.PlayerTwoResult = Result.Lose;
            }
            else if ((p1Move == Move.Rock && p2Move == Move.Paper) || (p1Move == Move.Paper && p2Move == Move.Scissors) || (p1Move == Move.Scissors && p2Move == Move.Rock))
            {
                record.PlayerOneResult = Result.Lose;
                record.PlayerTwoResult = Result.Win;
            }

            return record;
        }

        private void PrintResults(GameRecords records)
        {
            for (int i = 0; i < records.Records.Count; i++)
            {
                var record = records.Records[i];

                Utilities.PrintInColor($"Game {i + 1}: {record.PlayerOne.Name} ({record.PlayerOneResult}) vs {record.PlayerTwo.Name} ({record.PlayerTwoResult})", 2);
            }
        }

        private class GameRecord
        {
            public Player PlayerOne { get; set; }
            public Result PlayerOneResult { get; set; }
            public Player PlayerTwo { get; set; }
            public Result PlayerTwoResult { get; set; }
        }

        private class GameRecords
        {
            public List<GameRecord> Records;

            public GameRecords()
            {
                Records = new List<GameRecord>();
            }
        }
    }


}
