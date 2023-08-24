using System.Linq;

namespace CSharpPlayersGuide.Levels
{
    internal class Level42 : ILevel
    {
        public static void Notes()
        {
            Utilities.PrintNotesTitle(42);
            Console.WriteLine("When querying data, you can use LINQ expressions.");
            Console.WriteLine("There are two types: the kind that uses keywords and looks like sql");
            Console.WriteLine("and method calls.");
            Console.WriteLine("Method calls can do anything that keyword syntax can do (plus a bit more)");
            Console.WriteLine("");
            Console.WriteLine("LINQ is lazy, only evaluated when needed. This is good because it frees up memory.");
            Console.WriteLine("That said, if you need to use the data a lot, calling ToList will load it into memory.");

            List<GameObject> objects = new List<GameObject>(); 
            objects.Add(new Ship { ID = 1, X = 0, Y = 0, HP = 50, MaxHP = 100, PlayerID = 1 }); 
            objects.Add(new Ship { ID = 2, X = 4, Y = 2, HP = 75, MaxHP = 100, PlayerID = 1 }); 
            objects.Add(new Ship { ID = 3, X = 9, Y = 3, HP = 0, MaxHP = 100, PlayerID = 2 }); 
            
            List<Player> players = new List<Player>(); 
            players.Add(new Player(1, "Player 1", "Red")); 
            players.Add(new Player(2, "Player 2", "Blue"));

            IEnumerable<string> ids = from o in objects
                                      select $"The ID is {o.ID}.";

            var twoFroms =  from o in objects
                            from p in players
                            where o.ID == 1 || p.ID == 1
                            select (o, p);

            var ids2 = objects.Select(o => $"The ID is {o.ID}."); // fluent api

            Print(ids);
            Print(ids2);
            Print(twoFroms.Select(pair => ((object)pair.Item1, (object)pair.Item2))); // Had to cast to objects

            // Was just curious if you could compare something to itself
            //object x = 1;
            //if (x == x)
            //{
            //    Console.WriteLine($"{x} is x");
            //}

            // Trying to pass a delegate into a method call
            var ids3 = objects.Select(PrintShipIds);
            Print(ids3);

            Utilities.PrintInColor(
"""
Quiz:

1. What clause (keyword) starts a query expression? from
2. What clause filters data? where
3. True/False. You can order by multiple criteria in a single orderby clause. True -- 
from objects o
where ... 
where ...
select o.ID
4.   What clause combines two related sets of data? join
""");
        }

        private static string PrintShipIds(GameObject objects) => $"FROM METHOD: The ID is {objects.ID}.";


        private static void Print(IEnumerable<object> objects)
        {
            foreach (var o in objects)
            {
                Console.WriteLine(o);
            }

            Console.WriteLine($"\n{new string('-', 25)}\n");
        }

        // Overload
        private static void Print(IEnumerable<(object, object)> objects)
        {
            foreach (var o in objects)
            {
                Console.Write(o.Item1);
                Console.Write(", ");
                Console.Write(o.Item2);
                Console.WriteLine();
            }

            Console.WriteLine($"\n{new string('-', 25)}\n");
        }

        // Overload
        private static void Print(IEnumerable<int> objects)
        {
            foreach (var o in objects)
            {
                Console.WriteLine(o);
            }

            Console.WriteLine($"\n{new string('-', 25)}\n");
        }

        public class GameObject
        {
            public int ID { get; set; }
            public double X { get; set; }
            public double Y { get; set; }
            public int MaxHP { get; set; }
            public int HP { get; set; }
            public int PlayerID { get; set; }
        }
        public class Ship : GameObject { }
        public record Player(int ID, string UserName, string TeamColor);

        public static void TheThreeLenses()
        {
            var input = new int[] { 1, 9, 2, 8, 3, 7, 4, 6, 5 };

            // Filter out odd numbers
            // Order numbers
            // Double numbers
            // Return IEnumerable<int>

            // Procedural Method
            var result1 = ProceduralProcessiong(input);
            Print(result1);

            // Keyword Method
            var result2 = KeywordExpressions(input);
            Print(result2);

            // Method Call Based Query Expressions
            var result3 = MethodCalls(input);
            Print(result3);

            Console.WriteLine(
"""
Answer this question: Compare the size and understandability of these three approaches. Do any stand out as being particularly good or particularly bad?
Procedural is by far the most verbose. Keywords are more readable but method calls look more like 'code'. Both seem like much better was to query data.
Answer this question: Of the three approaches, which is your personal favorite, and why? Method calls because it seems more familiar. Keywords are nice too though.
""");
        }

        private static IEnumerable<int> ProceduralProcessiong(int[] input)
        {
            var results = new List<int>();

            // Filter
            foreach (var i in input)
            {
                if (i % 2 == 0)
                    results.Add(i);
            }

            // Sort
            results.Sort();

            // Double
            for (int i = 0; i < results.Count; i++)
            {
                results[i] = results[i] * 2;
            }

            return results;
        }

        private static IEnumerable<int> KeywordExpressions(int[] input)
        {
            return from i in input
                   where i % 2 == 0
                   orderby i
                   select i * 2;
        }

        private static IEnumerable<int> MethodCalls(int[] input)
        {
            return input.Where(i => i % 2 == 0).OrderBy(i => i).Select(i => i * 2);
        }
    }
}
