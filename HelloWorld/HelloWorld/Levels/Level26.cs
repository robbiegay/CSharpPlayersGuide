namespace CSharpPlayersGuide.Levels
{
    internal class Level26
    {
        public static void Notes()
        {
            Utilities.PrintNotesTitle(26);
            Console.WriteLine("");
            Console.WriteLine("Polymorphism: You can change the 'shape' of a class member in later classes.");
            Console.WriteLine("");
            Console.WriteLine("Define a base class. You use the 'virtual' keyword to allow a method to be overwritten.");
            Console.WriteLine("You can also have members that are not 'virtual'.");
            Console.WriteLine("");
            Utilities.PrintCode(
"""
private class MyBase
{
    public virtual int GetNumber()
    {
        return 1;
    }
}
""");
            Console.WriteLine("");
            Console.WriteLine("You can do several things:");
            Console.WriteLine("1. Don't change anything:");
            Console.WriteLine("");
            Utilities.PrintCode("private class DontOverride : MyBase { }");
            Utilities.PrintInColor($"new DontOverride().GetNumber() -> {new DontOverride().GetNumber()}", 2);
            Console.WriteLine("");
            Console.WriteLine("2. Override the functionality completely:");
            Console.WriteLine("");
            Utilities.PrintCode(
"""
private class Override : MyBase
{
    public override int GetNumber()
    {
        return 10;
    }
}
""");
            Utilities.PrintInColor($"new Override().GetNumber() -> {new Override().GetNumber()}", 2);
            Console.WriteLine("");
            Console.WriteLine("3. Override but use 'base' to incorporate and extend the base functionality:");
            Console.WriteLine("");
            Utilities.PrintCode(
"""
private class OverrideButAdd : MyBase
{
    public override int GetNumber()
    {
        var baseVal = base.GetNumber();

        return baseVal + 1;
    }
}
""");
            Utilities.PrintInColor($"new OverrideButAdd().GetNumber() -> {new OverrideButAdd().GetNumber()}", 2);
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("You can use 'abstract' to require that a member be overridden.");
            Console.WriteLine("If so, you must mark the class as 'abstract' and that class cannot be instantiated.");
            Console.WriteLine("You do not use 'override' to implement an abstract member in child classes.");
            Console.WriteLine("You can chose to have some members be non-abstract.");
            Console.WriteLine("");
            Utilities.PrintCode(
"""
private abstract class MyAbstract
{
    public abstract string GetName();

    public string SayHello()
    {
        return "Hello";
    }
}
""");
            Console.WriteLine("");
            Utilities.PrintCode(
"""
private class Tommy : MyAbstract
{
    public override string GetName()
    {
        return "Tommy";
    }
}
""");
            Console.WriteLine("");
            //var myAbstract = new MyAbstract(); // compiler error
            Utilities.PrintInColor("new MyAbstract() -> compiler error!", 1);
            Utilities.PrintInColor($"new Tommy().GetName() -> {new Tommy().GetName()}", 2);
            Utilities.PrintInColor($"new Tommy().SayHello() -> {new Tommy().SayHello()}", 2);
            Console.WriteLine("");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Optionally, you may want to hide a class member, rather than overriding it.");
            Console.WriteLine("To do so, reimplement the member, but use 'new' instead of 'overwrite' on a 'virtual' member.");
            Console.WriteLine("");
            Utilities.PrintCode(
"""
private class UseNew : MyBase
{
    public new int GetNumber()
    {
        return 0;
    }
}
""");
            Utilities.PrintInColor($"new UseNew().GetNumber() -> {new UseNew().GetNumber()}", 2);
        }

        private class MyBase
        {
            public virtual int GetNumber()
            {
                return 1;
            }
        }

        private class DontOverride : MyBase { }

        private class Override : MyBase
        {
            public override int GetNumber()
            {
                return 10;
            }
        }

        private class OverrideButAdd : MyBase
        {
            public override int GetNumber()
            {
                var baseVal = base.GetNumber();

                return baseVal + 1;
            }
        }

        private abstract class MyAbstract
        {
            public abstract string GetName();

            public string SayHello()
            {
                return "Hello";
            }
        }

        private class Tommy : MyAbstract
        {
            public override string GetName()
            {
                return "Tommy";
            }
        }

        private class UseNew : MyBase
        {
            public new int GetNumber()
            {
                return 0;
            }
        }

        public static void LabelingInventory()
        {
            Console.WriteLine("I modified the exercise a little bit to just add the functionality,");
            Console.WriteLine("but not actually redo anything from Level 25.");
            Console.WriteLine("");
            Console.WriteLine("Instead, I just overrode the ToString() methods, and you can now print an empty pack,");
            Console.WriteLine("and a pack with some items in it.");
            Console.WriteLine("");
            Console.WriteLine("Empty pack:");
            Utilities.PrintInColor(new Pack(isEmpty: true).ToString(), 2);
            Console.WriteLine("");
            Console.WriteLine("Pack with 3 items:");
            Utilities.PrintInColor(new Pack(isEmpty: false).ToString(), 2);

        }

        private class Pack
        {
            public List<InventoryItem> Items { get; set; }


            public Pack(bool isEmpty)
            {
                if (isEmpty)
                    Items = new List<InventoryItem>();
                else
                    Items = new List<InventoryItem>() { new Arrow(), new Bow(), new Rope() };
            }

            public override string ToString()
            {
                var result = "Pack containing ";
                if (Items.Count == 0)
                    return result + "no items...";

                foreach (var item in Items)
                {
                    result += item.ToString() + " ";
                }

                return result;
            }
        }

        private class Arrow : InventoryItem
        {
            public Arrow() : base(0.1, 0.05)
            {
                //
            }

            public override string ToString()
            {
                return "Arrow";
            }
        }

        private class Bow : InventoryItem
        {
            public Bow() : base(1, 4)
            {
                //
            }

            public override string ToString()
            {
                return "Bow";
            }
        }

        private class Rope : InventoryItem
        {
            public Rope() : base(1, 1.5)
            {
                //
            }

            public override string ToString()
            {
                return "Rope";
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


        public static void TheOldRobot()
        {
            var robot = new Robot();

            while(true)
            {
                Console.WriteLine("Enter a robot command:");
                Console.WriteLine("\tx - exit");
                Console.WriteLine("\t0 - power off");
                Console.WriteLine("\t1 - power on");
                Console.WriteLine("\tn - north");
                Console.WriteLine("\te - south");
                Console.WriteLine("\ts - east");
                Console.WriteLine("\tw - west");


                for (int i = 0; i < 3; i++)
                {
                    var input = Console.ReadKey().KeyChar;
                    Console.WriteLine("");

                    switch (input)
                    {
                        case 'x':
                            return;
                        case '0':
                            robot.Commands[i] = new OffCommand();
                            break;
                        case '1':
                            robot.Commands[i] = new OnCommand();
                            break;
                        case 'n':
                            robot.Commands[i] = new NorthCommand();
                            break;
                        case 'e':
                            robot.Commands[i] = new EastCommand();
                            break;
                        case 's':
                            robot.Commands[i] = new SouthCommand();
                            break;
                        case 'w':
                            robot.Commands[i] = new WestCommand();
                            break;
                    }
                }

                robot.Run();
            }
        }

        private class Robot
        { 
            public int X { get; set; } 
            public int Y { get; set; } 
            public bool IsPowered { get; set; } 
            public RobotCommand?[] Commands { get; } = new RobotCommand?[3]; 
            public void Run() 
            { 
                foreach (RobotCommand? command in Commands) 
                {
                    command?.Run(this);
                    Console.WriteLine($"[{X} {Y} {IsPowered}]"); 
                }
            }
        }

        private abstract class RobotCommand
        {
            public abstract void Run(Robot robot);
        }

        private class OnCommand : RobotCommand
        {
            public override void Run(Robot robot)
            {
                robot.IsPowered = true;
            }
        }

        private class OffCommand : RobotCommand
        {
            public override void Run(Robot robot)
            {
                robot.IsPowered = false;
            }
        }

        private class NorthCommand : RobotCommand
        {
            public override void Run(Robot robot)
            {
                if (robot.IsPowered) 
                    robot.Y++;
            }
        }

        private class EastCommand : RobotCommand
        {
            public override void Run(Robot robot)
            {
                if (robot.IsPowered) 
                    robot.X++;
            }
        }

        private class SouthCommand : RobotCommand
        {
            public override void Run(Robot robot)
            {
                if (robot.IsPowered)
                    robot.Y--;
            }
        }

        private class WestCommand : RobotCommand
        {
            public override void Run(Robot robot)
            {
                if (robot.IsPowered)
                    robot.X--;
            }
        }
    }
}
