namespace CSharpPlayersGuide.Levels
{
    internal class Level29
    {
        public static void Notes()
        {
            Utilities.PrintNotesTitle(29);
            Console.WriteLine("A record can be defined as a class (default) or struct (private record struct Point)");
            Console.WriteLine("Records are for data types. They can:");
            Console.WriteLine("\t- Create properties (readonly)");
            Console.WriteLine("\t- Add a default constructor");
            Console.WriteLine("\t- Add an override of the ToString method to actually show the data (so cool!)");
            Console.WriteLine("\t- Come with value semantics");
            Console.WriteLine("\t- Free deconstruction: can pull apart into a tuple");
            Console.WriteLine("\t- Can copy a record and modify just part using: with -- this is record only functionality");
            var p1 = new Point(1, 2);
            var p2 = new Point(1, 2);
            (int myX, int myY) = p1;
            var p3 = p1 with { Y = 10 };
            var x = $"x = {{x}}";
            Utilities.PrintCode(
$$"""

private record Point(int X, int Y);

var p1 = new Point(1, 2); // Default ctor
var p2 = new Point(1, 2);

p1.ToString(); // {{p1.ToString()}}
//p1.X = 5; // init only!
var compare = p1 == p2; // Value semantics -> {{p1 == p2}}
(int myX, int myY) = p1; // Deconstruction -> myX: {{myX}}, myY: {{myY}} 
var p3 = p1 with { Y = 10 }; // p3.X: {{p3.X}}, p3.Y: {{p3.Y}}
"""); // $$ = combines raw string with { }
            var r = new Rectangle(4, 5);
            var area = r.Area;
            var zero = r.Zero();
        }

        private record Point(int X, int Y);
        private record Rectangle(int length, int width)
        {
            public int Area => length * width; // records can have properties (beyond the ctor)
            public int Zero() => 0; // records can have methods
        }

        public static void WarPreparations()
        {
            var basicSword = new Sword(Material.Iron, Gemstone.None, 50, 8);
            var rareSword = basicSword with { Material = Material.Binarium, Gemstone = Gemstone.Bitstone };
            var bigSword = basicSword with { Length = 150, CrossgaurdWidth = 15 };

            var swords = new List<Sword>() { basicSword, rareSword, bigSword };

            Utilities.PrintInColor("Create some swords!", 2);
            Utilities.PrintCode(
"""

private record Sword(Material Material, Gemstone Gemstone, int Length, int CrossgaurdWidth);

var basicSword = new Sword(Material.Iron, Gemstone.None, 50, 8);
var rareSword = basicSword with { Material = Material.Binarium, Gemstone = Gemstone.Bitstone };
var bigSword = basicSword with { Length = 150, CrossgaurdWidth = 15 };

""");
            
            for (int i = 0; i < swords.Count; i++)
            {
                var sword = swords[i];
                var name = i == 0 ? nameof(basicSword) : (i == 1 ? nameof(rareSword) : nameof(bigSword));

                Utilities.PrintInColor($"{name}:\t\t{sword}", 2);
            }
        }

        private record Sword(Material Material, Gemstone Gemstone, int Length, int CrossgaurdWidth);

        private enum Material
        {
            Wood,
            Bronze,
            Iron,
            Steel, 
            Binarium
        }

        private enum Gemstone
        {
            None,
            Emerald,
            Amber,
            Sapphire,
            Diamond,
            Bitstone
        }
    }
}
