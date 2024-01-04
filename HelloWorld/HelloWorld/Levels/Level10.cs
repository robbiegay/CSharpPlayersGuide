namespace CSharpPlayersGuide.Levels
{
    internal class Level10
    {
        public static void BuyingInventory()
        {
            Console.WriteLine("The following items are available:");
            var items = new List<(string, int)>() { ("Rope", 10), ("Torches", 15), ("Climbing Equipment", 25), ("Clean Water", 1), ("Machete", 20), ("Canoe", 200), ("Food Supplies", 1), ("I'm not sure I want to sell that unknown item... it will", 1000000) };

            for (int i = 0; i < items.Count; i++)
                Console.WriteLine($"{i + 1} - {items[i].Item1}");

            Console.Write("What number do you want to see the price of? ");
            var input = Console.ReadLine();
            Console.WriteLine();

            (string, int) selectedItem;
            selectedItem = input switch
            {
                "1" => items[0],
                "2" => items[1],
                "3" => items[2],
                "4" => items[3],
                "5" => items[4],
                "6" => items[5],
                "7" => items[6],
                _ => items[7]
            };

            Utilities.PrintInColor($"{selectedItem.Item1} cost {selectedItem.Item2} gold.", 4);
        }

        public static void DiscountedInventory()
        {
            Console.Write("Welcome to the shop. What is your name? ");
            var name = (Console.ReadLine() ?? "").ToLower();
            if (name == "")
                name = "I didn't quite catch your name";
            var isAFriend = (name == "robbie" || name == "rob") ? true : false;
            Console.WriteLine();

            var welcomeMessage = isAFriend ? $"Ahh my friend {name}... for you, a discounted rate." : $"Hmm... {name}... a stranger to these parts...";
            var discount = isAFriend ? 0.5 : 1;
            Utilities.PrintInColor(welcomeMessage + "\n", 4);

            Console.WriteLine("The following items are available:");
            var items = new List<(string, double)>() { ("Rope", 10), ("Torches", 15), ("Climbing Equipment", 25), ("Clean Water", 1), ("Machete", 20), ("Canoe", 200), ("Food Supplies", 1), ("I'm not sure I want to sell that unknown item... it will", 1000000) };

            for (int i = 0; i < items.Count - 1; i++)
                Console.WriteLine($"{i + 1} - {items[i].Item1}");

            Console.Write("What number do you want to see the price of? ");
            var input = Console.ReadLine();
            Console.WriteLine();

            (string, double) selectedItem;
            selectedItem = input switch
            {
                "1" => items[0],
                "2" => items[1],
                "3" => items[2],
                "4" => items[3],
                "5" => items[4],
                "6" => items[5],
                "7" => items[6],
                _ => items[7]
            };

            Utilities.PrintInColor($"{selectedItem.Item1} cost {selectedItem.Item2 * discount} gold.", 4);
        }
    }
}
