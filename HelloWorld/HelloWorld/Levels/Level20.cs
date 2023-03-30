using static CSharpPlayersGuide.Levels.Level18;

namespace CSharpPlayersGuide.Levels
{
    internal class Level20
    {
        private float _width; // backing field

        public float Width
        {
            get => _width; // Can use an expression body
            private set
            {
                // value = a special variable provided by the setter
                _width = value; // or block body
            }
        }

        public string X { get; set; } = "Default value";

        public static void Notes()
        {
            Utilities.PrintInColor("Level 20 Notes:", 3);
            Console.WriteLine("");
            Console.WriteLine("You can replace dedicated Get...() and Set...() methods with properties:");
            Console.WriteLine("");
            Utilities.PrintInColor("private float _width;", 7);
            Console.WriteLine("");
            Utilities.PrintInColor("public float Width", 7);
            Utilities.PrintInColor("{", 7);
            Utilities.PrintInColor("\tget => _width;", 7);
            Utilities.PrintInColor("\tprivate set", 7);
            Utilities.PrintInColor("\t{", 7);
            Utilities.PrintInColor("\t\t_width = value;", 7);
            Utilities.PrintInColor("\t}", 7);
            Utilities.PrintInColor("}", 7);
            Console.WriteLine("");
            Console.WriteLine("The private fields that the property gets and sets are called");
            Console.WriteLine("'backing fields', and are often the same name as the property (ex. Name)");
            Console.WriteLine("but with: _name");
            Console.WriteLine("");
            Console.WriteLine("Getters and setters can have different accessability levels:");
            Console.WriteLine("ex. a setter could be private");
            Console.WriteLine("");
            Console.WriteLine("Properties can use expression (get => _x) or block (get { return _x; }) bodies.");
            Console.WriteLine("");
            Console.WriteLine("Setters have access to a special variable called 'value'");
            Utilities.PrintInColor("set => _x = value;", 7);
            Console.WriteLine("");
            Console.Write("There is even a VS snippet: ");
            Utilities.PrintInColor("prop", 7, true);
            Console.Write(" (then press tab 2x)\n");
            Console.WriteLine("");
            Console.WriteLine("If the property has getters and setters that just return a backing");
            Console.WriteLine("field with no special logic, you can use a 'auto-implemented property':");
            Console.WriteLine("");

            Utilities.PrintInColor("public string X { get; set; } = \"Default value\";", 7);
            Console.WriteLine("");
            Console.WriteLine("There is now no need to have a backing field, it is all done behind the scenes.");
            Console.WriteLine("These can be get-only, but not set-only, as there would be no way to");
            Console.WriteLine("access the property data.");
            Console.WriteLine("");
            Console.WriteLine("You can also make fields get-only:");
            Console.WriteLine("");
            Utilities.PrintInColor("private readonly string _name;", 7);
            Console.WriteLine("");
            Console.WriteLine("Object initializer syntax: runs right after the constructor");
            Utilities.PrintInColor("var X = new Thing() { Size = 5 };", 7);
            Console.WriteLine("");
            Console.WriteLine("If the constructor is parameterless, you can even leave out: ()");
            Utilities.PrintInColor("var X = new Thing { Size = 5 };", 7);
            Console.WriteLine("");
            Console.WriteLine("But if Thing's Size property is get-only, this will not work");
            Console.WriteLine("as the object initializer syntax runs AFTER the constructor.");
            Console.WriteLine("");
            Console.WriteLine("To mitigate this, we can use the 'init' keyword:");
            Console.WriteLine("");
            Utilities.PrintInColor("public class Thing", 7);
            Utilities.PrintInColor("{", 7);
            Utilities.PrintInColor("\tpublic int Size { get; init; }", 7);
            Utilities.PrintInColor("}", 7);
            Console.WriteLine("");
            Console.WriteLine("Now Size can be set via: object initializer, in its constructor,");
            Console.WriteLine("or to a default value, but not afterwards.");
            Console.WriteLine("");
            Console.WriteLine("You can also create anonymous types but their use is limits:");
            Utilities.PrintInColor("var anon = new { Name = \"Bill\", Age = 25 };", 7);
            Console.WriteLine("");
            Console.WriteLine("Name and Age are created as get-only properties.");
            Console.WriteLine("An anonymous type can only be used in a single method");
            Console.WriteLine("(cannot be returned or used as a parameter in another method).");

            var thing = new Thing { Size = 5 };
            // thing.Size = 7; // Will not compile

            var anon = new { Name = "Bill", Age = 25 };
        }

        private class Thing
        {
            public int Size { get; init; } = 0;

            public Thing()
            {
                Size = 1;
            }
        }

        public static void ThePropertiesOfArrows()
        {
            Level18.VinFletchersArrows(level: 20);
        }

        internal class ImprovedArrowV2
        {
            public ArrowHead ArrowHead { get; }
            public int Length { get; }
            public Fletching Fletching { get; }

            private int minLength = 60;
            private int maxLength = 100;

            // Creates a default values for an empty constructor
            public ImprovedArrowV2() : this(ArrowHead.Wood, 80, Fletching.Plastic)
            {

            }

            public ImprovedArrowV2(ArrowHead arrowHead, int length, Fletching fletching)
            {
                if (length < minLength)
                    length = minLength;
                else if (length > maxLength)
                    length = maxLength;

                ArrowHead = arrowHead;
                Length = length;
                Fletching = fletching;
            }

            public double Cost 
            { 
                get
                {
                    var cost = 0.0;

                    cost += ArrowHead switch
                    {
                        ArrowHead.Steel => 10,
                        ArrowHead.Wood => 3,
                        ArrowHead.Obsidian => 5,
                        _ => 0
                    };

                    cost += Length * 0.05;

                    cost += Fletching switch
                    {
                        Fletching.Plastic => 10,
                        Fletching.TurkeyFeathers => 5,
                        Fletching.GooseFeathers => 3,
                        _ => 0
                    };

                    return cost;
                }
            }
        }
    }
}
