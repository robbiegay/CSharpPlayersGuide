using static System.Formats.Asn1.AsnWriter;

namespace CSharpPlayersGuide.Levels
{
    internal class Level39 : ILevel
    {
        public static void Notes()
        {
            Utilities.PrintNotesTitle(39);
            Console.WriteLine("The File class is static, and lets you manipulate files.");
            Console.WriteLine("A file path can be absolute (\"C:/Users/.../file.txt\") or relative to the");
            Console.WriteLine("working directory (\"file.txt\" -- this file now lives somewhere like: bin/debug/...)");
            Console.WriteLine("Directory does for folders what File does for files.");
            Console.WriteLine("You can copy, move, or delete files/directories");
            Console.WriteLine("Directories need to be empty before you delete them unless you specifiy");
            Console.WriteLine("recurion. WARNING: you can delete a whole file system like this.");
            Console.WriteLine("Path lets you do things like: get relative and absolute paths, combine strings into a path, get filename (full names, name without extension, and just file extension).");
            Console.WriteLine("StreamReaders and Writers read from files line-by-line.");
            Console.WriteLine("This is a better approach when reading or writing large files.");
            Console.WriteLine("The drawback is added complexity: risks like leaving a file open");
            Console.WriteLine("too long or closing it too soon.");
            Console.WriteLine("Streams can work with strings, bytes, and some even work with network calls.");
        }

        public static void MessageInABottle()
        {
            var path = "message.txt";
            if (File.Exists(path))
            {
                Utilities.PrintInColor($"Last time you said: {File.ReadAllText(path)}\n", 7);
            }

            Console.WriteLine("What message do you want to leave this time?");
            var message = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(message))
            {
                File.Delete(path);
                Utilities.PrintInColor($"Deleting message file at path: {Path.GetFullPath(path)}", 1);
            }
            else
            {
                File.WriteAllText(path, message);
            }
        }

        public static void HighScores()
        {
            var path = "highscores.csv";

            // Create a default list of scores if one does not exisit
            if (!File.Exists(path))
            {
                var scores = CreateScores();
                var sl = new List<string>();

                foreach (var score in scores)
                {
                    sl.Add(string.Join(",", score.Name, score.Points, score.Level));
                }

                File.WriteAllLines(path, sl);
            }

            // Parse current scores
            var highScoresFile = File.ReadLines(path);
            var highScores = new List<Score>();
            foreach (var hs in highScoresFile)
            {
                var sc = hs.Split(',');
                highScores.Add(new Score(sc[0], int.Parse(sc[1]), int.Parse(sc[2])));
            }

            highScores = highScores.OrderByDescending(hs => hs.Points).ToList();

            // Print scores
            Utilities.PrintInColor("HIGHSCORES".PadLeft(23), 10);
            Utilities.PrintInColor(new string('-', 40), 2);
            Utilities.PrintInColor($"{"Name".PadRight(10)} | {"Points".PadRight(10)} | Level", 12);
            Utilities.PrintInColor(new string('-', 40), 2);

            foreach (var s in highScores)
            {
                Utilities.PrintInColor($"{s.Name}".PadRight(10), 2, true);
                Utilities.PrintInColor(" | ", 5, true); 
                Utilities.PrintInColor($"{s.Points}".PadRight(10), 2, true);
                Utilities.PrintInColor(" | ", 5, true);
                Utilities.PrintInColor($"{s.Level}", 2, true);
                Console.WriteLine();
            }
            Console.WriteLine();

            // Add a new score
            Utilities.PrintInColor("Add a new high score:", 7);
            Utilities.PrintInColor("Name:", 3);
            var name = Console.ReadLine();
            Utilities.PrintInColor("Points:", 3);
            var p = Console.ReadLine();
            int points = -1;
            int.TryParse(p, out points);
            Utilities.PrintInColor("Level:", 3);
            var l = Console.ReadLine();
            int level = -1;
            int.TryParse(l, out level);

            if (string.IsNullOrWhiteSpace(name))
            {
                Utilities.PrintInColor("Deleting high scores file...", 1);
                File.Delete(path);
                return;
            }
            var newScore = new Score(name ?? "invalid name", points, level);
            highScores.Add(newScore);

            // Write out list of scores
            var scoreList = new List<string>();
            foreach (var score in highScores)
            {
                scoreList.Add(string.Join(",", score.Name, score.Points, score.Level));
            }

            File.WriteAllLines(path, scoreList);
        }

        private record Score(string Name, int Points, int Level);
        private static List<Score> CreateScores()
        {
            return new List<Score>() 
            {
                new Score("Charlie", 1_000, 21),
                new Score("Nick", 523, 9),
                new Score("Tau", 109, 3)
            };
        }

        public static void TheLongGame()
        {
            Utilities.PrintInColor("Enter your name:", 3);
            var name = Console.ReadLine();

            var path = $"Score/{name}.txt";
            var score = 0;

            if (File.Exists(path))
            {
                var s = File.ReadAllText(path);
                score = int.Parse(s);
                Utilities.PrintInColor($"Found previous score of {score}.\n", 9);
            }

            while (true)
            {
                Utilities.PrintInColor($"Name: {name} | Score: {score}", 12);

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.Enter) 
                {
                    break;
                }
                else
                {
                    score++;
                }

                Console.Clear();
            }

            // Save score to file
            var dirName = Path.GetDirectoryName(path);
            if (!Path.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            File.WriteAllText(path, $"{score}");
        }
    }
}
