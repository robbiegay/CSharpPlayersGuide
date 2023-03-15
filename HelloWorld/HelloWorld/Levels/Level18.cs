namespace CSharpPlayersGuide.Levels
{
    internal class Level18
    {
        public static void TellMeTheFiveObjectOrientedPrinciples()
        {
            Utilities.PrintObjectOrientedPrinciples();
        }

        public static void VinFletchersArrows(bool isLevel19 = false)
        {
            Utilities.PrintInColor("Create a custom arrow:\n", 0);

            Utilities.PrintInColor("Select an arrowhead:", 0);
            Utilities.PrintInColor("\t1 - Steel", 3);
            Utilities.PrintInColor("\t2 - Wood", 3);
            Utilities.PrintInColor("\t3 - Obsidian\n", 3);
            Utilities.PrintInColor("> ", 0, true);

            var arrowHeadSelection = Console.ReadKey().KeyChar;
            Utilities.PrintInColor("\n", 0);

            ArrowHead arrowHead = arrowHeadSelection switch
            {
                '1' => ArrowHead.Steel,
                '2' => ArrowHead.Wood,
                '3' => ArrowHead.Obsidian,
                _ => ArrowHead.Wood
            };

            Utilities.PrintInColor("Select an arrow length (60 - 100cm):", 0);
            Utilities.PrintInColor("> ", 0, true);

            var arrowLengthSelection = Console.ReadLine();

            int.TryParse(arrowLengthSelection, out var length);

            Utilities.PrintInColor("\nSelect an arrow fletching:", 0);
            Utilities.PrintInColor("\t1 - Plastic", 3);
            Utilities.PrintInColor("\t2 - Turkey Feathers", 3);
            Utilities.PrintInColor("\t3 - Goose Feathers\n", 3);
            Utilities.PrintInColor("> ", 0, true);

            var arrowFletchingSelection = Console.ReadKey().KeyChar;
            Utilities.PrintInColor("\n", 0);

            Fletching fletching = arrowFletchingSelection switch
            {
                '1' => Fletching.Plastic,
                '2' => Fletching.TurkeyFeathers,
                '3' => Fletching.GooseFeathers,
                _ => Fletching.Plastic
            };

            Utilities.PrintInColor("\nCreating your arrow...\n", 2);

            Utilities.PrintInColor($"Your arrow is done!", 2);

            if (isLevel19)
            {
                Level19.ImprovedArrow arrow = new(arrowHead, length, fletching);

                Utilities.PrintInColor($"\t- Arrow Head: {arrow.GetArrowHead()}\n\t- Length: {arrow.GetLength()}\n\t- Fletching: {arrow.GetFletching()}", 2);
                Utilities.PrintInColor($"Your arrow is done! It will cost you {arrow.GetCost()}!", 2);
            }
            else
            {
                Arrow arrow = new(arrowHead, length, fletching);

                Utilities.PrintInColor($"\t- Arrow Head: {arrow.arrowHead}\n\t- Length: {arrow.length}\n\t- Fletching: {arrow.fletching}", 2);
                Utilities.PrintInColor($"Your arrow is done! It will cost you {arrow.GetCost()}!", 2);
            }
        }

        internal class Arrow
        {
            public ArrowHead arrowHead;
            public int length;
            public Fletching fletching;

            private int minLength = 60;
            private int maxLength = 100;

            public Arrow() : this(ArrowHead.Wood, 80, Fletching.Plastic)
            {

            }

            public Arrow(ArrowHead arrowHead, int length, Fletching fletching)
            {
                if (length < minLength)
                    length= minLength;
                else if (length > maxLength)
                    length= maxLength;

                this.arrowHead = arrowHead;
                this.length = length;
                this.fletching = fletching;
            }

            public double GetCost()
            {
                var cost = 0.0;

                cost += arrowHead switch
                {
                    ArrowHead.Steel => 10,
                    ArrowHead.Wood => 3,
                    ArrowHead.Obsidian => 5,
                    _ => 0
                };

                cost += length * 0.05;

                cost += fletching switch
                {
                    Fletching.Plastic => 10,
                    Fletching.TurkeyFeathers => 5,
                    Fletching.GooseFeathers => 3,
                    _ => 0
                };

                return cost;
            }
        }

        internal enum ArrowHead
        {
            Steel,
            Wood,
            Obsidian
        }

        internal enum Fletching
        {
            Plastic,
            TurkeyFeathers,
            GooseFeathers
        }

        public static void Notes()
        {
            // Instances of a class are created via the 'new' keyword
            // Fields hold data - also known as instance variables

            var slide = 1;
            var length = 4;

            while (slide <= length) 
            {
                if (slide < 1) slide = 1;

                Utilities.PrintInColor($"Slide {slide}/{length}\n", 3);

                if (slide == 1)
                    Slide1();
                else if (slide == 2)
                    Slide2();
                else if (slide == 3)
                    Slide3();
                else if (slide == 4)
                    Slide4();

                Utilities.PrintInColor("Press:\n\t- Any key to contine to the next slide", 0);
                Utilities.PrintInColor("\t- 'b' to go back to the previous slide", 0);
                Utilities.PrintInColor("\t- 'e' to exit\n", 0);

                Utilities.PrintInColor("> ", 0, true);
                var response = Console.ReadKey().KeyChar;
                Console.Clear();

                if (response == 'b')
                    slide--;
                else if (response == 'e')
                    slide = length + 1;
                else
                    slide++;
            }

            Utilities.PrintInColor("\n\n\t~~ End of slide deck ~~\n\n", 5);
        }

        static void Slide1()
        {
            Utilities.PrintInColor("Name Hiding: If a local and higher level scope both share the same variable,", 2);
            Utilities.PrintInColor("then the local variable will prevent access to the higher level variable in a", 2);
            Utilities.PrintInColor("process known as name hiding.\n", 2);
            Utilities.PrintInColor("This can be seen in constructors:\n", 2);

            Utilities.PrintInColor("class Score", 7);
            Utilities.PrintInColor("{", 7);
            Utilities.PrintInColor("\tpublic string name;\n", 7);
            Utilities.PrintInColor("\tpublic Score(string name)", 7);
            Utilities.PrintInColor("\t{", 7);
            Utilities.PrintInColor("\t\tname = name;", 7);
            Utilities.PrintInColor("\t}", 7);
            Utilities.PrintInColor("}", 7);

            Utilities.PrintInColor("\nIn the constructor, 'name' is the local variable, and all that", 2);
            Utilities.PrintInColor("is being acomplished is setting name equal to itself.\n", 2);
        }

        static void Slide2()
        {
            Utilities.PrintInColor("Using the keyword 'this' is a popular solution to this problem.", 2);
            Utilities.PrintInColor("The 'this' keyword acts like a special variable with a reference", 2);
            Utilities.PrintInColor("to the object you are currently in.\n", 2);

            Utilities.PrintInColor("class Score", 7);
            Utilities.PrintInColor("{", 7);
            Utilities.PrintInColor("\tpublic string name;\n", 7);
            Utilities.PrintInColor("\tpublic Score(string name)", 7);
            Utilities.PrintInColor("\t{", 7);
            Utilities.PrintInColor("\t\tthis.name = name;", 7);
            Utilities.PrintInColor("\t}", 7);
            Utilities.PrintInColor("}", 7);

            Utilities.PrintInColor("\nThe local 'name' variable's value is now being assigned", 2);
            Utilities.PrintInColor("to the Score object's name variable.\n", 2);
        }

        static void Slide3()
        {
            Utilities.PrintInColor("The 'this' keyword can also be used to call another constuctor in the class.", 2);
            Utilities.PrintInColor("This allows you to reduce code duplication.\n", 2);
            Utilities.PrintInColor("For example, if you have a parameterless constructor for setting", 2);
            Utilities.PrintInColor("default values and parameterized constuctor for allowing the user to set their own", 2);
            Utilities.PrintInColor("default values, then you can call the parameterized constructor from the parameterless one:\n", 2);

            Utilities.PrintInColor("class Score", 7);
            Utilities.PrintInColor("{", 7);
            Utilities.PrintInColor("\tpublic string name;\n", 7);
            Utilities.PrintInColor("\tpublic Score() : this(\"unknown\")", 7);
            Utilities.PrintInColor("\t{", 7);
            Utilities.PrintInColor("\t}\n", 7);
            Utilities.PrintInColor("\tpublic Score(string name)", 7);
            Utilities.PrintInColor("\t{", 7);
            Utilities.PrintInColor("\t\tthis.name = name;", 7);
            Utilities.PrintInColor("\t}", 7);
            Utilities.PrintInColor("}", 7);

            Utilities.PrintInColor("\nAdding ': this(...)' allows you to call another constructor controlled by the object.\n", 2);
        }

        static void Slide4()
        {
            Utilities.PrintInColor("When creating new instances, you can leave out the name of the class when", 2);
            Utilities.PrintInColor("the compiler has enough information to infer the type:\n", 2);

            Utilities.PrintInColor("Score myScore = new(\"Rob\");", 7);

            Score myScore = new("Rob", 0, 1);

            Utilities.PrintInColor("This is like using 'var' but on the other side of the '=' keyword.", 2);
        }
    }

    public class Score
    {
        public string name;
        public int score = 0;
        public int level;

        // no return type for constructor
        public Score() : this("unknown", 0, 1) // : this(...) -> allows access to other constructors belonging to the object
        {
        }

        // Name hiding: if a more local scope has a variable with the same name
        // you will lose access to the higher scope variable because the local scope hides it.
        // This: can use the 'this' keyword to directly access the object you are currently in
        public Score(string name, int score, int level)
        {
            this.name = name;
            this.score = score;
            this.level = level;
        }
    }
}
