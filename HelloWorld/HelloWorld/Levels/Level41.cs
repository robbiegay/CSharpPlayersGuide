using System.Numerics;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;

namespace CSharpPlayersGuide.Levels
{
    internal class Level41 : ILevel
    {
        public static void Notes()
        {
            Utilities.PrintNotesTitle(41);
            Console.WriteLine("You can overload common C# operators, create indexers, and create implicit and explicit conversions.");
            Console.WriteLine("");
            Console.WriteLine("Operators that you can overload include:");
            Console.WriteLine("\t- Math: +, - /, *, %");
            Console.WriteLine("\t- Unary: -, !, ++, -- (cant implement += or -= but you get them for free with ++ and --)");
            Console.WriteLine("\t- Comparison (must implement in pairs): == and !=, < and >, <= and >=");
            Console.WriteLine("");
            Console.WriteLine("When you implement non-unary operators, impplement them both ways: ie A, B and B, A -> but you can call one from the other to avoid having to duplicate code.");
            Console.WriteLine("Operator overloads must be: public static [object] operator +([object] A, [object] B) { return [object]; }");
            Console.WriteLine("");
            Console.WriteLine("Indexers: similar in style to getters and setters.");
            Console.WriteLine("");
            Console.WriteLine("Casting:");
            Console.WriteLine("\t- Implicit: No data loss. Looks like: public static implicit operator [object]([other object] A)");
            Console.WriteLine("\t- Explicit: Possible data loss. Same as implicit but with 'explicit' keyword.");
            Console.WriteLine("");
            Console.WriteLine("It is often better to use a method like ToPoint() than to add casting. Implicit casting can be really conterintuitive if you don't expect it.");
            Console.WriteLine("Imagine that a method takes Point(Shape A) and you pass in ShapeB but it is implicitly cast. You might not know you did this and then have to really dig around to see why you are getting unexpected results.");
            Console.WriteLine("");
            Console.WriteLine("Below, I made a Persoon class and overloaded some operators:");
            var king = new Person("Isaac", Title.King);
            var duke = new Person("Charlie", Title.Duke);
            Console.WriteLine($"Is king {king.Name} > duke {duke.Name}? {king > duke}");
            var child1 = king + duke;
            Console.WriteLine($"The king has had a child with the duke! {child1.Name}");
            var child2 = child1 + new Person("Nick", Title.Civilian);
            Console.WriteLine($"The child has had a child with someone random! {child2.Name}");
            var child3 = child2 + new Person("Tao", Title.Knight);
            Console.WriteLine($"The child's child has had a child with someone else random! {child3.Name}");
            Console.WriteLine("");
            Console.WriteLine("Quiz:");
            Console.WriteLine("1. False: you cannot define new operators, only overload astablished ones like + or ==/");
            Console.WriteLine("2. False: most, but not all, operators can be overloaded.");
            Console.WriteLine("3. True: operator overloads must be public and static.");
        }

        public static void NavigatingOperandCity()
        {
            var position = new BlockCoordinate(0, 0);

            while (true)
            {
                Utilities.PrintInColor("Current position:", 3);
                Utilities.PrintInColor($"Row: {position.Row}, Column: {position.Column}", 7);

                Console.WriteLine();
                Console.WriteLine("Enter a command:");
                Utilities.PrintInColor("\t- 1. Move: North", 2);
                Utilities.PrintInColor("\t- 2. Move: East", 2);
                Utilities.PrintInColor("\t- 3. Move: South", 2);
                Utilities.PrintInColor("\t- 4. Move: West", 2);
                Utilities.PrintInColor("\t- 5. Input block offset", 2);
                Utilities.PrintInColor("\t- e: Exit", 2);
                Console.WriteLine();

                var input = Console.ReadLine();

                if (input == "e")
                    return;

                _ = input switch
                {
                    "1" => position += Direction.North,
                    "2" => position += Direction.East,
                    "3" => position += Direction.South,
                    "4" => position += Direction.West,
                    _ => null
                };

                if (input == "5")
                {
                    Console.WriteLine("Enter row offset:");
                    int.TryParse(Console.ReadLine(), out int row);
                    Console.WriteLine("Enter column offset:");
                    int.TryParse(Console.ReadLine(), out int column);

                    position += new BlockOffset(row, column);
                }

                Console.Clear();
            }
        }

        private record BlockCoordinate(int Row, int Column)
        {
            public static BlockCoordinate operator +(BlockCoordinate Start, BlockOffset Move) => new(Start.Row + Move.RowOffset, Start.Column + Move.ColumnOffset);

            public static BlockCoordinate operator +(BlockOffset Move, BlockCoordinate Start) => Start + Move;

            public static BlockCoordinate operator +(BlockCoordinate Start, Direction Move)
            {
                return Move switch
                {
                    Direction.North => new(Start.Row - 1, Start.Column),
                    Direction.East => new(Start.Row, Start.Column + 1),
                    Direction.South => new(Start.Row + 1, Start.Column),
                    Direction.West => new(Start.Row, Start.Column - 1)
                };
            }

            public static BlockCoordinate operator +(Direction Move, BlockCoordinate Start) =>  Start + Move;
        }

        private record BlockOffset(int RowOffset, int ColumnOffset); 
        private enum Direction { North, East, South, West }

        public static void IndexingOperandCity()
        {
            throw new NotImplementedException();
        }

        public static void ConvertingDirectionsToOffsets()
        {
            throw new NotImplementedException();
        }

        private record Person(string Name, Title Position)
        {
            // Reversed the <, >, etc because the highest position is zero in my Title enum
            public static bool operator >(Person A, Person B)
            {
                return A.Position < B.Position;
            }

            public static bool operator <=(Person A, Person B)
            {
                return A.Position >= B.Position;
            }

            public static bool operator >=(Person A, Person B)
            {
                return A.Position <= B.Position;
            }

            public static bool operator <(Person A, Person B)
            {
                return A.Position > B.Position;
            }

            public static Person operator +(Person A, Person B)
            {
                if (!A.Name.Contains("Jr") && !A.Name.EndsWith("I"))
                {
                    return new Person($"{A.Name} Jr", A.Position > B.Position ? A.Position : B.Position);
                }
                else
                {
                    var name = A.Name;

                    if (A.Name.Contains("Jr"))
                    {
                        name = name.Remove(A.Name.Length - 3);
                        name += " III";
                    }
                    else
                    {
                        name += "I";
                    }

                    return new Person(name, A.Position > B.Position ? A.Position : B.Position);
                }
            }
        };
        private enum Title
        {
            King,
            Heir,
            Duke,
            Knight,
            Mayor,
            Civilian
        }
    }
}
