namespace CSharpPlayersGuide.Levels
{
    internal static class Level28
    {
        public static void Notes()
        {
            Utilities.PrintNotesTitle(28);
            Console.WriteLine("Structs are like classes except they are value types.");
            Console.WriteLine("They can have properties and methods, but cannot use inheritance.");
            Console.WriteLine("Best practice: Make structs small, immutable, and give them a default value.");
            Console.WriteLine("Value types like 'int' are structs.");
            Console.WriteLine("");
            Console.WriteLine("Create new ref types = classes; Create new value types = structs");
            Console.WriteLine("struct is short for 'data structure'");
            Console.WriteLine("");
            Console.WriteLine("Structs can have some gotchas around constructors");
            Console.WriteLine("");
            Console.WriteLine("Equality: checks that all members have same values.");
            Console.WriteLine("Inherits from ValueType : object");
            Console.WriteLine("Can inheriet from interfaces");
            Console.WriteLine("");
            Console.WriteLine("Choose structs for: value types, for data");
            Console.WriteLine("A struct can have methods but those are ussually data related");
            Console.WriteLine("");
            Console.WriteLine("Ref vs value types can be better in certain situations:");
            Console.WriteLine("\t- As a parameter, you make a copy each time, so if you had to pass something in 1000s of times, not very efficent.");
            Console.WriteLine("\t- If you instantiate a value type repeatedly, it can reuse the memory location. Ref types require garbage collection.");
            Console.WriteLine("");
            Console.WriteLine("Rules to follow:");
            Console.WriteLine("\t- Keep them small: copying large data structs adds up.");
            Console.WriteLine("\t- Make its values immutabe: readonly");
            Console.WriteLine("\t- Make the default values valid for the data model");
            Console.WriteLine("");
            Console.WriteLine("Boxing: taking a value type and putting it into ref");
            Console.WriteLine("Unboxing: the reverse, requires explicit case");
            Console.WriteLine("");
            Console.WriteLine("Keywords:");
            Console.WriteLine("ref: can change a value from outside the method. Must be initalized");
            Utilities.PrintCode("int x = 5;\nMyMethod(ref x);");
            Console.WriteLine("out: same thing but has to be instantiated");
            Utilities.PrintCode("MyMethod(out int x); // instantiate the variable IN the method call");
        }

        public static void RoomCoordinates()
        {
            var coords = new List<Coordinate>();

            for (int i = 0; i < 5; i++) 
            {
                for (int j = 0; j < 5; j++)
                {
                    coords.Add(new Coordinate(i, j));
                }
            }

            foreach (var c in coords)
            {
                Console.WriteLine($"Row: {c.Row}, Column: {c.Column}");
                Console.WriteLine("Is it adjacent to: Row: 2, Col: 3?");
                Console.WriteLine(c.isAdjacent(new Coordinate(2, 3)));
                Console.WriteLine("");
            }
        }

        private struct Coordinate
        {
            public readonly int Row;
            public readonly int Column;

            public Coordinate(int r, int c)
            {
                Row = r;
                Column = c;
            }

            public bool isAdjacent(Coordinate coord) 
            {
                if ((Row == coord.Row + 1 && Column == coord.Column) || (Row == coord.Row - 1 && Column == coord.Column))
                    return true;
                if ((Row == coord.Row && Column == coord.Column + 1) || (Row == coord.Row && Column == coord.Column - 1))
                    return true;

                return false;
            }
        }
    }
}
