using System.Linq;

namespace CSharpPlayersGuide.Levels
{
    internal class Level42 : ILevel
    {
        public static void Notes()
        {
            List<GameObject> objects = new List<GameObject>(); 
            objects.Add(new Ship { ID = 1, X = 0, Y = 0, HP = 50, MaxHP = 100, PlayerID = 1 }); 
            objects.Add(new Ship { ID = 2, X = 4, Y = 2, HP = 75, MaxHP = 100, PlayerID = 1 }); 
            objects.Add(new Ship { ID = 3, X = 9, Y = 3, HP = 0, MaxHP = 100, PlayerID = 2 }); 
            
            List<Player> players = new List<Player>(); 
            players.Add(new Player(1, "Player 1", "Red")); 
            players.Add(new Player(2, "Player 2", "Blue"));

            IEnumerable<string> ids = from o in objects
                                      select $"The ID is {o.ID}.";

            var ids2 = objects.Select(o => $"The ID is {o.ID}."); // fluent api

            foreach (var item in ids)
            {
                Console.WriteLine(item);
            }

            foreach (var item in ids2)
            {
                Console.WriteLine(item);
            }

            object x = 1;
            if (x == x)
            {
                Console.WriteLine($"{x} is x");
            }
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
            var dict = new Dictionary<int, int>();
            dict.Where(d => d.Key == 1);
        }
    }
}
