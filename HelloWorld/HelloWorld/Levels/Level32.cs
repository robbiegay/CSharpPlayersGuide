namespace CSharpPlayersGuide.Levels
{
    internal class Level32
    {
        internal static void Notes()
        {
            Utilities.PrintNotesTitle(32);
            Console.WriteLine("Some useful types:");
            Console.WriteLine("\t- Random: generates a sort of random series of numbers based on a seed");
            Console.WriteLine("\t- DateTime: .Now, .UtcNow, .Now.AddDays(1), new DateTime(<year>, <month>, <day>, <hours>, <minutes>, <seconds>) among other constructors, time.Month == 10");
            Console.WriteLine("\t- TimeSpan: 10 ticks = 1 microsecond, TimeSpan(...), TimeSpan.FromSeconds(3.5)");
            Console.WriteLine("\t- Guid: globally unique, Guid.NewGuid(), Tools > Create Guid");
            Console.WriteLine("\t- List<T>");
            Console.WriteLine("\t- IEnumerable<T>");
            Console.WriteLine("\t- Dictionary<TKey, TValue>");
            Console.WriteLine("\t- Nullable<T>");
            Console.WriteLine("\t- ValueTuple");
            Console.WriteLine("\t- StringBuilder");
            Console.WriteLine("");
            Console.WriteLine("Using the same seed (123) with Random:");

            var random = new Random(123);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i}: {random.Next()}");
            }

            Console.WriteLine("Round 2:");
            var random2 = new Random(123);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i}: {random2.Next()}");
            }

            Console.WriteLine("Random() = calls with an arbitrary seed that will always be unique");

            Utilities.PrintInColor("Challenge: The Robot Pilot -> did this already when making Level 14.", 2);

            Console.WriteLine("time.Hours -> will only show the hours less than 24 as anything greater is added to .Days. Instead .TotalMinutes can show all of the minutes remaining");
            var timeLeft = new TimeSpan(1, 30, 5);
            Console.WriteLine($"Time left: {timeLeft.Days} days. {timeLeft.Hours} hours, {timeLeft.Minutes} minutes");
            Console.WriteLine("DateTime - DateTime = TimeSpan (of the time between the 2 dates)");

            Utilities.PrintInColor("Challenge: Time in the Cavern -> Added a timer to level 31", 2);

            Utilities.PrintInColor("Challenge: Lists of Commands -> Added list of commands to level 27", 2);
        }
    }
}
