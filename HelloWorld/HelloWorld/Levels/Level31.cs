using System.Drawing;
using static CSharpPlayersGuide.Levels.Level18;

namespace CSharpPlayersGuide.Levels
{
    internal class Level31
    {
        public static void DesignNotes()
        {
            Console.WriteLine(
"""
Design Notes:

Create a text-based game using a grid.
The grid will be 4x4 but size should not be tightly coupled.

The grid should hold game objects: empty, enterance, fountain, monster, etc.
The game should do the following:
- check the 8 surrounding squares, display messages from those objects
- allow the player to do an action (command pattern?). Move, fire arrow, enable fountain, etc

I think that the game should have a UI. That is optional but would be a lot more fun
Could have an option to play in the dark or view objects


GameObject
- name
- message

Did the following:
- base game
- size expansion
- pits expansion
""");
        }

        public static void TheFountainOfObjects()
        {
            var size = 0;

            while (size < 2 || size > 10)
            {
                Console.WriteLine("Enter a size (must be > 1 and <= 10):");
                var sizeInput = Console.ReadLine();
                int.TryParse(sizeInput, out size);
                Console.Clear();
            }

            var gameConfig = new GameConfig(size);

            var gameBoard = new GameObject[size, size];

            // Set game board to empty
            for (int i = 0; i < gameBoard.GetLength(0); i++) 
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    gameBoard[i, j] = new GameObject(GameObjectType.Empty);
                }
            }

            // Add game objects
            var player = gameConfig.PlayerLocation;
            var entrance = gameConfig.EntranceLocation;
            var fountain = gameConfig.FountainLocation;

            gameBoard[entrance.Row, entrance.Col] = new GameObject(GameObjectType.Entrance);
            gameBoard[fountain.Row, fountain.Col] = new GameObject(GameObjectType.Fountain);

            foreach (var pit in gameConfig.PitLocations)
            {
                gameBoard[pit.Row, pit.Col] = new GameObject(GameObjectType.Pit);
            }

            RunGame(gameBoard, gameConfig);
        }


        private static void RunGame(GameObject[,] board, GameConfig gameConfig)
        {
            var startTime = DateTime.Now;

            while (!gameConfig.isGameOver)
            {
                Console.Clear();

                PrintGame(board, gameConfig);

                Console.WriteLine();
                Console.WriteLine("Enter a command:");
                Console.WriteLine("\t- move [north,east,south,west]");
                Console.WriteLine("\t- enable fountain");
                Console.WriteLine("\t- exit -> leave the cavern");
                Console.WriteLine("\t- end game -> quit the game");
                Console.WriteLine("\t- toggle dark mode -> turn on the lights!");
                var cmd = Console.ReadLine();

                if (cmd.Contains("move"))
                {
                    if (cmd.Contains("north"))
                    {
                        MovePlayer(board, gameConfig, Direction.North);
                    }
                    else if (cmd.Contains("east"))
                    {
                        MovePlayer(board, gameConfig, Direction.East);
                    }
                    else if (cmd.Contains("south"))
                    {
                        MovePlayer(board, gameConfig, Direction.South);
                    }
                    else if (cmd.Contains("west"))
                    {
                        MovePlayer(board, gameConfig, Direction.West);
                    }
                    else
                    {
                        Console.WriteLine("Invalid direction");
                        Console.ReadKey();
                    }
                }
                else if (cmd == "enable fountain")
                {
                    EnableFountain(board, gameConfig);
                }
                else if (cmd == "exit")
                {
                    CheckForWin(board, gameConfig);
                }
                else if (cmd == "end game")
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have opted to end the game...");
                    Console.ResetColor();

                    gameConfig.isGameOver = true;
                }
                else if (cmd == "toggle dark mode")
                {
                    gameConfig.isDarkMode = !gameConfig.isDarkMode;

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Dark mode has been turned {(gameConfig.isDarkMode ? "on" : "off")}\nPress any key to continue...");
                    Console.ResetColor();

                    Console.ReadKey();
                }
            }

            var endTime = DateTime.Now;
            var timeInCaven = endTime - startTime;

            Console.WriteLine();
            Utilities.PrintInColor("You spent ", 5, true);
            Utilities.PrintInColor($"{timeInCaven.Minutes} ", 14, true);
            Utilities.PrintInColor("minutes, ", 5, true);
            Utilities.PrintInColor($"{timeInCaven.Seconds} ", 14, true);
            Utilities.PrintInColor("seconds, and ", 5, true);
            Utilities.PrintInColor($"{timeInCaven.Milliseconds} ", 14, true);
            Utilities.PrintInColor("milliseconds in the cavern.", 5, true);
            Console.WriteLine();
        }

        private enum Direction
        {
            North,
            East,
            South,
            West
        }

        private static void MovePlayer(GameObject[,] board, GameConfig gameConfig, Direction direction)
        {
            var player = gameConfig.PlayerLocation;
            var oldLocation = board[player.Row, player.Col];

            if (direction == Direction.North && player.Row > 0)
            {
                gameConfig.PlayerLocation.Row = player.Row - 1;
                gameConfig.PlayerLocation.Col = player.Col;
            }
            else if (direction == Direction.East && player.Col < board.GetLength(1) - 1)
            {
                gameConfig.PlayerLocation.Row = player.Row;
                gameConfig.PlayerLocation.Col = player.Col + 1;
            }
            else if (direction == Direction.South && player.Row < board.GetLength(0) - 1)
            {
                gameConfig.PlayerLocation.Row = player.Row + 1;
                gameConfig.PlayerLocation.Col = player.Col;
            }
            else if (direction == Direction.West && player.Col > 0)
            {
                gameConfig.PlayerLocation.Row = player.Row;
                gameConfig.PlayerLocation.Col = player.Col - 1;
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ivalid move: cannot go out of bounds!\nPress any key to continue...");
                Console.ResetColor();
                Console.ReadKey();
            }

            // Check for pits
            var currentPlayerLocation = gameConfig.PlayerLocation;
            foreach (var pit in gameConfig.PitLocations)
            {
                if (currentPlayerLocation.Row == pit.Row && currentPlayerLocation.Col == pit.Col)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You fell into a pit! Game over...");
                    Console.ResetColor();

                    gameConfig.isGameOver = true;
                }
            }
        }

        private static void EnableFountain(GameObject[,] board, GameConfig gameConfig)
        {
            var player = gameConfig.PlayerLocation;
            var fountain = gameConfig.FountainLocation;

            if (player.Col == fountain.Col && player.Row == fountain.Row)
            {
                gameConfig.isFountainEnabled = true;

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Fountain enabled!\nPress any key to continue...");
                Console.ResetColor();
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You still need to find the fountain...\nPress any key to continue...");
                Console.ResetColor();
                Console.ReadLine();
            }
        }

        private static void CheckForWin(GameObject[,] board, GameConfig gameConfig)
        {
            var player = gameConfig.PlayerLocation;
            var entrance = gameConfig.EntranceLocation;

            if (!gameConfig.isFountainEnabled)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You still need to turn on the fountain...\nPress any key to continue...");
                Console.ResetColor();
                Console.ReadLine();

                return;
            }

            if (!(player.Row == entrance.Row && player.Col == entrance.Col))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The fountain is on, but you still need to find the exit...\nPress any key to continue...");
                Console.ResetColor();
                Console.ReadLine();

                return;
            }

            Console.Clear();

            var colors = new ConsoleColor[6]
                {
                ConsoleColor.Red,
                ConsoleColor.Yellow,
                ConsoleColor.Green,
                ConsoleColor.Cyan,
                ConsoleColor.Blue,
                ConsoleColor.DarkCyan
                };
            var timeInMilliseconds = 250;

            for (int i = 25; i > 0; i--)
            {
                Console.Clear();

                Console.ForegroundColor = colors[(i + 0) % 6];
                Console.WriteLine("----------------------------------------");
                Console.ForegroundColor = colors[(i + 1) % 6];
                Console.WriteLine("----------------------------------------");
                Console.ForegroundColor = colors[(i + 2) % 6];
                Console.WriteLine("----------------------------------------");
                Console.ForegroundColor = colors[(i + 3) % 6];
                Console.WriteLine("----------------------------------------");
                Console.ForegroundColor = colors[(i + 4) % 6];
                Console.WriteLine("----------------------------------------");
                Console.ForegroundColor = colors[(i + 5) % 6];
                Console.WriteLine("----------------------------------------");

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You made your escape! The island has been restored!");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Animation will exit in {(i * timeInMilliseconds) / 1000} seconds...");
                Console.WriteLine();

                Console.ForegroundColor = colors[(i + 0) % 6];
                Console.WriteLine("----------------------------------------");
                Console.ForegroundColor = colors[(i + 1) % 6];
                Console.WriteLine("----------------------------------------");
                Console.ForegroundColor = colors[(i + 2) % 6];
                Console.WriteLine("----------------------------------------");
                Console.ForegroundColor = colors[(i + 3) % 6];
                Console.WriteLine("----------------------------------------");
                Console.ForegroundColor = colors[(i + 4) % 6];
                Console.WriteLine("----------------------------------------");
                Console.ForegroundColor = colors[(i + 5) % 6];
                Console.WriteLine("----------------------------------------");

                Thread.Sleep(timeInMilliseconds);
            }

            Console.ResetColor();

            gameConfig.isGameOver = true;
        }

        private static void PrintGame(GameObject[,] board, GameConfig gameConfig)
        {
            var gameMessages = "";

            var edgeColor = ConsoleColor.Gray;
            var edgeTextColor = ConsoleColor.Black;
            var tileSize = 5;

            Console.Title = "The Fountain of Objects";

            // Top:
            Console.Write("     ");
            for (int i = 0; i < (board.GetLength(0) * tileSize) + 2; i++)
            {
                Console.BackgroundColor = edgeColor;
                Console.ForegroundColor = edgeTextColor;
                Console.Write("-");
                Console.ResetColor();
            }
            Console.Write("\n");

            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.Write("     ");

                // Edge
                Console.BackgroundColor = edgeColor;
                Console.ForegroundColor = edgeTextColor;
                Console.Write("|");
                Console.ResetColor();

                for (int j = 0; j < board.GetLength(1); j++) 
                {
                    var gameObject = board[i, j];

                    ConsoleColor color = gameObject.Type switch
                    {
                        GameObjectType.Empty => ConsoleColor.Black,
                        GameObjectType.Entrance => ConsoleColor.Yellow,
                        GameObjectType.Fountain => gameObject.IsEnabled ? ConsoleColor.Blue : ConsoleColor.DarkBlue,
                        GameObjectType.Pit => ConsoleColor.Magenta,
                        _ => ConsoleColor.Red
                    };

                    var player = gameConfig.PlayerLocation;
                    if (i == player.Row && j == player.Col)
                    {
                        color = ConsoleColor.Green;

                        // Add game messages

                        // NW
                        gameMessages += "To the northwest... ";
                        if (i > 0 && j > 0)
                            gameMessages += board[i - 1, j - 1].Message;
                        else
                            gameMessages += "nothing";
                        gameMessages += "\n";
                        // N
                        gameMessages += "To the north... ";
                        if (i > 0)
                            gameMessages += board[i - 1, j].Message;
                        else
                            gameMessages += "nothing";
                        gameMessages += "\n";
                        // NE
                        gameMessages += "To the northeast... ";
                        if (i > 0 && j < board.GetLength(1) - 1)
                            gameMessages += board[i - 1, j + 1].Message;
                        else
                            gameMessages += "nothing";
                        gameMessages += "\n";
                        // W
                        gameMessages += "To the west... ";
                        if (j > 0)
                            gameMessages += board[i, j - 1].Message;
                        else
                            gameMessages += "nothing";
                        gameMessages += "\n";
                        // Current location
                        gameMessages += "At your location... ";
                        gameMessages += board[i, j].Message;
                        gameMessages += "\n";
                        // E
                        gameMessages += "To the east... ";
                        if (j < board.GetLength(1) - 1)
                            gameMessages += board[i, j + 1].Message;
                        else
                            gameMessages += "nothing";
                        gameMessages += "\n";
                        // SW
                        gameMessages += "To the southwest... ";
                        if (i < board.GetLength(0) - 1 && j > 0)
                            gameMessages += board[i + 1, j - 1].Message;
                        else
                            gameMessages += "nothing";
                        gameMessages += "\n";
                        // S
                        gameMessages += "To the south... ";
                        if (i < board.GetLength(0) - 1)
                            gameMessages += board[i + 1, j].Message;
                        else
                            gameMessages += "nothing";
                        gameMessages += "\n";
                        // SE
                        gameMessages += "To the southeast... ";
                        if (i < board.GetLength(0) - 1 && j < board.GetLength(1) - 1)
                            gameMessages += board[i + 1, j + 1].Message;
                        else
                            gameMessages += "nothing";
                        gameMessages += "\n";
                    }
                    else if (gameConfig.isDarkMode)
                    {
                        color = ConsoleColor.Black;
                    }

                    Console.BackgroundColor = color;
                    Console.Write("  +  ");
                    Console.ResetColor();
                }

                // Edge
                Console.BackgroundColor = edgeColor;
                Console.ForegroundColor = edgeTextColor;
                Console.Write("|");
                Console.ResetColor();

                Console.Write("\n");
            }

            // Bottom:
            Console.Write("     ");
            for (int i = 0; i < (board.GetLength(0) * tileSize) + 2; i++)
            {
                Console.BackgroundColor = edgeColor;
                Console.ForegroundColor = edgeTextColor;
                Console.Write("-");
                Console.ResetColor();
            }
            Console.Write("\n");

            Console.WriteLine("\n\n");

            // Add item messages
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(gameMessages);
            Console.ResetColor();
        }

        //
        // Game objects
        //
        private class GameObject
        {
            public GameObjectType Type { get; init; } = GameObjectType.Empty;
            public string Message { 
                get
                {
                    return Type switch
                    {
                        GameObjectType.Empty => "You hear the sound of flat, empty space",
                        GameObjectType.Entrance => "You see light in this room coming from outside the cavern. This is the entrance.",
                        GameObjectType.Fountain => IsEnabled ? "You hear the water rushing from the Fountain of Objects. It has been reactivated!" : "You hear water dripping in this room. The Fountain of Objects is here!",
                        GameObjectType.Pit => "You feel a draft. There is a pit in a nearby room",
                        _ => ""
                    };
                }
            }
            // Violation of ISP: not all objects need an IsEnabled prop
            public bool IsEnabled {  get; set; }

            public GameObject(GameObjectType type)
            {
                Type = type;
            }
        }
        
        private enum GameObjectType
        {
            Empty,
            Entrance,
            Fountain,
            Pit,
            Maelstrom,
            Amarok
        }
        
        private class GameConfig
        {
            public Position PlayerLocation { get; set; } = new Position(0, 0);
            public Position EntranceLocation { get; set; } = new Position(0, 0);
            public Position FountainLocation { get; set; }
            public List<Position> PitLocations { get; set; } = new List<Position>();
            public bool isFountainEnabled { get; set; } = false;
            public bool isGameOver { get; set; } = false;
            public bool isDarkMode { get; set; } = true;

            public GameConfig(int size)
            {
                var rnd = new Random();

                var row = 0;
                var col = 0;
                while (row == 0 && col == 0)
                {
                    row = rnd.Next(0, size);
                    col = rnd.Next(0, size);
                }
                FountainLocation = new Position(row, col);

                // Add pits
                var maxPits = size / 3;
                while (PitLocations.Count < maxPits)
                {
                    var pitRow = 0;
                    var pitCol = 0;

                    // Dont put a pit at the enterance or fountain
                    while (
                        (pitRow == 0 && pitCol == 0) || 
                        (pitRow == FountainLocation.Row && pitCol == FountainLocation.Col)
                    )
                    {
                        // don't allow duplicates
                        do
                        {
                            pitRow = rnd.Next(0, size);
                            pitCol = rnd.Next(0, size);
                        }
                        while (PitLocations.Where(p => p.Row == pitRow && p.Col == pitCol).Count() > 0);
                    }

                    // check for dupes
                    PitLocations.Add(new Position(pitRow, pitCol));
                }
            }
        }

        private class Position
        {
            public int Row { get; set; }
            public int Col { get; set; }

            public Position(int row, int col)
            {
                Row = row;
                Col = col;
            }
        }

    }
}
