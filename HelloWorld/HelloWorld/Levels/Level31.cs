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

Create a text bases game using a grid.
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
""");
        }

        public static void TheFountainOfObjects()
        {
            var size = 4;
            var gameConfig = new GameConfig();

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

            gameBoard[entrance.Item1, entrance.Item2] = new GameObject(GameObjectType.Entrance);
            gameBoard[fountain.Item1, fountain.Item2] = new GameObject(GameObjectType.Fountain);
            gameBoard[player.Item1, player.Item2].IsPlayerHere = true;

            RunGame(gameBoard, gameConfig);
        }

        private class GameConfig
        {
            public (int, int) PlayerLocation { get; set; } = (0, 0);
            public (int, int) EntranceLocation { get; set; } = (0, 0);
            public (int, int) FountainLocation { get; set; } = (2, 2);
        }

        private static void RunGame(GameObject[,] board, GameConfig gameConfig)
        {
            // todo: add exit ability
            while (true)
            {
                Console.Clear();

                PrintGame(board);

                Console.WriteLine("Enter a command:");
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
                    break;
                }
            }
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
            var oldLocation = board[player.Item1, player.Item2];


            if (direction == Direction.North && player.Item1 > 0)
            {
                board[player.Item1 - 1, player.Item2].IsPlayerHere = true;
                oldLocation.IsPlayerHere = false;
            }
            else if (direction == Direction.East && player.Item2 < board.GetLength(1) - 1)
            {
                board[player.Item1, player.Item2 + 1].IsPlayerHere = true;
                oldLocation.IsPlayerHere = false;
            }
            else if (direction == Direction.South && player.Item1 < board.GetLength(0) - 1)
            {
                board[player.Item1 + 1, player.Item2].IsPlayerHere = true;
                oldLocation.IsPlayerHere = false;
            }
            else if (direction == Direction.West && player.Item2 > 0)
            {
                board[player.Item1, player.Item2 - 1].IsPlayerHere = true;
                oldLocation.IsPlayerHere = false;
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ivalid move: cannot go out of bounds!\nPress any key to continue...");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        private static void EnableFountain(GameObject[,] board, GameConfig gameConfig)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    var gameObject = board[i, j];

                    if (gameObject.IsPlayerHere)
                    {
                        if (gameObject.Type == GameObjectType.Fountain) 
                        {
                            gameObject.IsEnabled = true;

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

                        return;
                    }
                }
            }
        }

        private static void CheckForWin(GameObject[,] board, GameConfig gameConfig)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    var gameObject = board[i, j];

                    if (gameObject.IsPlayerHere)
                    {
                        if (gameObject.Type == GameObjectType.Entrance)
                        {
                            //
                        }
                        else
                        {
                            //
                        }    

                        return;
                    }
                }
            }
        }

        private static void PrintGame(GameObject[,] board)
        {
            var edgeColor = ConsoleColor.Gray;
            var edgeTextColor = ConsoleColor.Black;
            var tileSize = 5;

            Console.WriteLine("The Fountain of Objects");
            Console.WriteLine("\n\n");

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
                        _ => ConsoleColor.Red
                    };

                    if (gameObject.IsPlayerHere)
                    {
                        color = ConsoleColor.Green;
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
        }

        private class GameObject
        {
            public GameObjectType Type { get; init; } = GameObjectType.Empty;
            public bool IsPlayerHere { get; set; } = false;
            public string Message { 
                get
                {
                    return Type switch
                    {
                        GameObjectType.Empty => "",
                        GameObjectType.Entrance => "You see light in this room coming from outside the cavern. This is the entrance.",
                        GameObjectType.Fountain => IsEnabled ? "You hear the water rushing from the Fountain of Objects. It has been reactivated!" : "You hear water dripping in this room. The Fountain of Objects is here!",
                        _ => ""
                    };
                }
            }
            // Violation of ISP: not all objects need an IsEnabled prop
            public bool IsEnabled {  get; set; }
            //{ 
            //    get
            //    {
            //        if (Type == GameObjectType.Fountain)
            //            return IsEnabled;
            //        else
            //            return false;
            //    }

            //    set
            //    {
            //        if (Type == GameObjectType.Fountain)
            //            IsEnabled = value;
            //    }
            //}

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
    }
}
