using System.Collections;

namespace CSharpPlayersGuide.Levels
{
    internal class Level32
    {
        internal static void Notes()
        {
            Utilities.PrintNotesTitle(32);
            Console.WriteLine("Some useful types:");
            Console.WriteLine("\t- Random: generates a semi-random series of numbers based on a seed");
            Console.WriteLine("\t- DateTime: .Now, .UtcNow, .Now.AddDays(1), new DateTime(<year>, <month>, <day>, <hours>, <minutes>, <seconds>) among other ctors, myTime.Month == 10");
            Console.WriteLine("\t- TimeSpan: 10 ticks = 1 microsecond, TimeSpan(...), TimeSpan.FromSeconds(3.5)");
            Console.WriteLine("\t- Guid: globally unique, Guid.NewGuid(), VS > Tools > Create Guid");
            Console.WriteLine("\t- List<T>");
            Console.WriteLine("\t- IEnumerable<T>: anything that uses foreach");
            Console.WriteLine("\t- Dictionary<TKey, TValue>: .ContainsKey(\"x\"), .GetValueOrDefault(\"x\", \"fallback value\"), .Remove(\"x\")");
            Console.WriteLine("\t- Nullable<T>: used when you call int?, etc.");
            Console.WriteLine("\t- ValueTuple: what tuples use under the hood.");
            Console.WriteLine("\t- StringBuilder: use this if you are modifying lots of strings");
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

            Console.WriteLine("");
            Console.WriteLine("The values repeted when the same seed was used.");
            Console.WriteLine("");
            Console.WriteLine("Random() = calls with an arbitrary seed that will always be unique");
            Console.WriteLine("");

            Utilities.PrintInColor("Challenge: The Robot Pilot -> did this already when making Level 14.", 2);

            Console.WriteLine("myTime.Hours -> will only show the hours less than 24 as anything greater is added to .Days. Instead .TotalMinutes can show all of the minutes remaining");
            var timeLeft = new TimeSpan(1, 30, 5);
            Console.WriteLine($"Time left: {timeLeft.Days} days. {timeLeft.Hours} hours, {timeLeft.Minutes} minutes");
            Console.WriteLine("DateTime - DateTime = TimeSpan (of the time between the 2 dates)");

            Utilities.PrintInColor("Challenge: Time in the Cavern -> Added a timer to level 31", 2);

            Utilities.PrintInColor("Challenge: Lists of Commands -> Added list of commands to level 27", 2);

            Console.WriteLine("Using int? converts it to a Nullable type and give you access to things like: x.HasValue and x.Value");
            int x = 5;
            //x = null; // compiler error
            //x.HasValue // compiler error, x is not of type Nullable
            
            int? y = 5;
            y = null;
            if (y.HasValue)
                Console.WriteLine("y.Value: " + y.Value);
        }

        private class MyEnumerable<T> : IEnumerable<T>
        {
            public IEnumerator<T> GetEnumerator()
            {
                return new MyEnumerator<T>();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return new MyEnumerator<T>();
            }
        }

        private class MyEnumerator<T> : IEnumerator<T>
        {
            public T Current => throw new NotImplementedException();

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
