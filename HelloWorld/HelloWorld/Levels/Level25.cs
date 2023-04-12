using System.Text;

namespace CSharpPlayersGuide.Levels
{
    internal class Level25
    {
        public static void Notes()
        {
            Utilities.PrintNotesTitle(25);

            Console.WriteLine("");
            Console.WriteLine("Inheritance lets a class inherit everything from a parent class except its ctor's");
            Console.WriteLine("");
            Utilities.PrintCode("class Child : Parent { ... }");
            Console.WriteLine("");
            Console.WriteLine("All classes derive implicitly from the 'object' class.");
            Console.WriteLine("Constructors in the derived class must call the base class ctor (unless using a parameterless ctor):");
            Console.WriteLine("");
            Utilities.PrintCode("public Child(int x) : Parent(x) { ... }");
            Console.WriteLine("");
            Console.WriteLine("The 'protected' accessibility modifier makes things accessable only in the class and its derived classes.");
            Console.WriteLine("");
            Console.WriteLine("derived/child/subclass : Base/parent/superclass");
            Console.WriteLine("A child class is said to 'extend' a parent class.");
            Console.WriteLine("");
            var a = new object();
            var b = a;
            var c = new object();
            Console.WriteLine("All classes derive from object. object has some methods that all classes inherit:");
            Console.WriteLine("Equal -> defaults to checking for the same reference:\n");
            Utilities.PrintCode($"a.Equals(b) -> {a.Equals(b)} -- a = b");
            Utilities.PrintCode($"a.Equals(c) -> {a.Equals(c)} -- c = new object()");
            Utilities.PrintCode($"a.ToString() -> {a.ToString()}");
            Utilities.PrintCode($"a.GetType() -> {a.GetType()}");
            Utilities.PrintCode($"a.GetHashCode() -> {a.GetHashCode()}");
            Console.WriteLine("");
            Console.WriteLine("You can put any derived class into a parent class:\n");
            Utilities.PrintCode("object x = new Point();");
            Console.WriteLine("");
            Console.WriteLine("This means that the compiler can safely do things like: x.ToString();");
            Console.WriteLine("But cannot do something like call a method of the Point class: x.SomeMethod();");
            Console.WriteLine("The compiler can guarantee that x is an object, but CANNOT guarantee a class like Point.");
            Console.WriteLine("");
            Console.WriteLine("You can overwrite methods like ToString() and Equals() in derived classes.");
            Console.WriteLine("");
            Console.WriteLine("Inheritance only works one way:");
            object x = new string("abc");
            //string y = new object(); // compiler error
            Utilities.PrintCode("object x = new string(\"abc\");\n//string y = new object(); // compiler error");
            Console.WriteLine("");
            Console.WriteLine("Inheritance hierarchies can be as deep as you need: object > GameObject > Ship > XWing > ...");
            Console.WriteLine("");
            Console.WriteLine("You can only inherit from 1 class.");
            Console.WriteLine("");
            Console.WriteLine("When you inherit, you automatically call a parameterless constructor on the base class.");
            Console.WriteLine("If none exisits, you must call a parameterized ctor: MyClass() : base(x, y, z)");
            Console.WriteLine("");
            Console.WriteLine("You can use a downcast to get the compiler to allow you to use a child from parent:\n");
            object myObj = "test";
            //myObj.Contains("123"); // won't work
            ((string)myObj).Contains("123");
            Utilities.PrintCode(
"""
object myObj = "test";
//myObj.Contains("123"); // won't work
((string)myObj).Contains("123");
""");
            Console.WriteLine("");
            Console.WriteLine("A few ways to check types:");
            Console.WriteLine("");
            Console.WriteLine("For each type that you use, the C# runtime will create an instance of the Type class");
            Console.WriteLine("which holds metadata about your type. One way to check is:\n");
            object obj = "test";
            if (obj.GetType() == typeof(string))
            {
                //
            }
            Utilities.PrintCode(
"""
object obj = "test";

if (obj.GetType() == typeof(string))
{
    //
}
""");
            Console.WriteLine("");
            Console.WriteLine("The 'as' keyword will simultaneously do a type check and conversion:\n");
            string? myString = obj as string;
            Utilities.PrintCode("string? myString = obj as string;");
            Console.WriteLine("");
            Console.WriteLine("A 3rd way is via pattern matching and the 'is' keyword:\n");
            if (obj is string myString2)
            {
                myString2.Substring(0); // you can use the myString2 variable here
            }
            Utilities.PrintCode(
"""
if (obj is string myString2)
{
    myString2.Substring(0); // you can use the myString2 variable here
}
""");
            Console.WriteLine("");
            Console.WriteLine("The 'protected' access modifier allows only base and derived class access to something.");
            Console.WriteLine("");
            Console.WriteLine("The 'sealed' access modifier prevents classes from deriving from a class.");
            Console.WriteLine("Use cases for 'sealed' are rare but it can sometime provide a performance boost.");
            Console.WriteLine("");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Some random char notes:");
            Console.WriteLine("Null char (\\0): ->\0<-");
            Console.WriteLine("What is a ->\f<- form feed (\\f)? It acts similar to a newline (\\n)");
            Console.WriteLine("What about a carriage ->\r<- return (\\r)? returned to the begining of the line a overwrote the first few chars");
            Console.WriteLine("\vVertical tab (\\v): just added an extra line space");
            Console.WriteLine("\U0001F47D -> unicode is displayed as ?? as console cannot display it");
            Console.WriteLine("");
            Console.WriteLine("Demo of a 'typewriter effect' utility that I wrote:");
            Console.WriteLine("");
            Utilities.TypewriterType("This is a message", 100, 2000, true, false);
            Utilities.TypewriterType("And I am writing this next", 100, 2000, false, true);
            Console.WriteLine("----------------------------------");
        }

        public static void PackingInventory()
        {
            Console.WriteLine("Create a new pack!\n\nEnter a max item count (int):");
            int maxCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a max weight count (double):");
            double maxWeight = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter a max volume count (double):");
            double maxVolume = double.Parse(Console.ReadLine());

            var pack = new Pack(maxCount, maxWeight, maxVolume);

            var keepRunning = true;

            while (keepRunning) 
            {
                pack.Print();

                Console.WriteLine("Select an item to add to your pack:");
                Console.WriteLine("\t\te - exit");
                Console.WriteLine("\t\t1 - arrow");
                Console.WriteLine("\t\t2 - bow");
                Console.WriteLine("\t\t3 - rope");
                Console.WriteLine("\t\t4 - water");
                Console.WriteLine("\t\t5 - food");
                Console.WriteLine("\t\t6 - sword");

                var input = Console.ReadKey(true).KeyChar;

                if (input == 'e')
                {
                    keepRunning = false;
                }

                InventoryItem itemToAdd = input switch
                {
                    '1' => new Arrow(),
                    '2' => new Bow(),
                    '3' => new Rope(),
                    '4' => new Water(),
                    '5' => new Food(),
                    '6' => new Sword(),
                    _ => new Arrow() // default case
                };

                pack.AddItem(itemToAdd);
            }
        }

        private class Pack
        {
            public List<InventoryItem> Items { get; set; }
            public int MaxItemCount { get; init; }
            public double MaxWeight { get; init; }
            public double MaxVolume { get; init; }
            public int ItemCount 
            {
                get => Items.Count;
            }
            public double CurrentWeight 
            { 
                get
                {
                    var total = 0.0;

                    foreach (var item in Items)
                    {
                        total += item.Weight;
                    }

                    return total;
                }
            }

            public double CurrentVolume
            {
                get
                {
                    var total = 0.0;

                    foreach (var item in Items)
                    {
                        total += item.Volume;
                    }

                    return total;
                }
            }

            public Pack(int maxCount, double maxWeight, double maxVolume)
            {
                Items = new List<InventoryItem>();

                MaxItemCount = maxCount;
                MaxWeight = maxWeight;
                MaxVolume = maxVolume;
            }

            public bool AddItem(InventoryItem item)
            {
                var result = true;

                if (CurrentWeight + item.Weight > MaxWeight)
                {
                    Utilities.PrintInColor("Item weighs too much...", 1);
                    result = false;
                }
                if (CurrentVolume + item.Volume > MaxVolume)
                {
                    Utilities.PrintInColor("Item has too much volume...", 1);
                    result= false;
                }
                if (ItemCount + 1 > MaxItemCount)
                {
                    Utilities.PrintInColor("Item count is too high...", 1);
                    result = false;
                }

                if (result == true)
                {
                    Items.Add(item);
                    Utilities.PrintInColor($"{nameof(item)} added!", 7);
                }

                return result;
            }

            public void Print()
            {
                Utilities.PrintInColor("\n---------------------------------------------\n", 14);
                Utilities.PrintInColor("Your pack contains the following:", 3);

                Utilities.PrintInColor("\n---------------------------------------------\n", 9);
                if (this.ItemCount == 0)
                    Utilities.PrintInColor("[Empty]", 5);

                foreach (var item in Items)
                {
                    Utilities.PrintInColor($"\t- {item.GetType().Name}: {item.Weight} weight, {item.Volume} volume", 2);
                }
                Utilities.PrintInColor("\n---------------------------------------------\n", 9);

                Utilities.PrintInColor($"Total pack count: ", 2, true);
                Utilities.PrintInColor($"{this.ItemCount}", 7, true);
                Utilities.PrintInColor($" / ", 2, true);
                Utilities.PrintInColor($"{this.MaxItemCount}", 1, true);
                Console.WriteLine("");

                Utilities.PrintInColor($"Total pack weight: ", 2, true);
                Utilities.PrintInColor($"{this.CurrentWeight}", 7, true);
                Utilities.PrintInColor($" / ", 2, true);
                Utilities.PrintInColor($"{this.MaxWeight}", 1, true);
                Console.WriteLine("");

                Utilities.PrintInColor($"Total pack volume: ", 2, true);
                Utilities.PrintInColor($"{this.CurrentVolume}", 7, true);
                Utilities.PrintInColor($" / ", 2, true);
                Utilities.PrintInColor($"{this.MaxVolume}", 1, true);
                Console.WriteLine("");

                Utilities.PrintInColor("\n---------------------------------------------\n", 14);
            }
        }

        private class Arrow : InventoryItem
        {
            public Arrow() : base(0.1, 0.05)
            {
                //
            }
        }

        private class Bow : InventoryItem
        {
            public Bow() : base(1, 4)
            {
                //
            }
        }

        private class Rope : InventoryItem
        {
            public Rope() : base(1, 1.5)
            {
                //
            }
        }

        private class Water : InventoryItem
        {
            public Water() : base(2, 3)
            {
                //
            }
        }

        private class Food : InventoryItem
        {
            public Food() : base(1, 0.5)
            {
                //
            }
        }

        private class Sword : InventoryItem
        {
            public Sword() : base(5, 3)
            {
                //
            }
        }

        private class InventoryItem
        {
            public double Weight { get; init; }
            public double Volume { get; init; }

            public InventoryItem(double weight, double volume)
            {
                Weight = weight;
                Volume = volume;
            }
        }
    }
}
