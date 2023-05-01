namespace CSharpPlayersGuide.Levels
{
    internal class Level27
    {
        public static void Notes()
        {
            Utilities.PrintNotesTitle(27);
            Console.WriteLine("Interfaces are implicitly public and abstract.");
            Console.WriteLine("");
            Console.WriteLine("A new feature of C#: Interfaces can have default implementations.");
            Console.WriteLine("You just give an interface method a body. Classes implementing that interface");
            Console.WriteLine("no longer have to implement that member -- but they can if they want.");
            Console.WriteLine("");
            Console.WriteLine("A class can inherit from ONE base class, and multiple interfaces (though too many might be a code smell:");
            Console.WriteLine("");
            Utilities.PrintCode("public class MyClass : MyBaseClass, IMyInterfaceOne, IMyInterfaceTwo { ... }");
            Console.WriteLine("");
            Console.WriteLine("An interface can inherit from another interface -- classes implementing that interface will also have to implement the parent interface.");
            Console.WriteLine("");
            Console.WriteLine("Interfaces can have: static members, public properties, and private instance variables IF those variables are static.");
        }

        public static void RoboticInterface()
        {
            var robot = new Robot();

            while (true)
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
            public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];
            public void Run()
            {
                foreach (IRobotCommand? command in Commands)
                {
                    command?.Run(this);
                    Console.WriteLine($"[{X} {Y} {IsPowered}]");
                }
            }
        }

        interface IRobotCommand
        {
            void Run(Robot robot);
        }

        private class OnCommand : IRobotCommand
        {
            public void Run(Robot robot)
            {
                robot.IsPowered = true;
            }
        }

        private class OffCommand : IRobotCommand
        {
            public void Run(Robot robot)
            {
                robot.IsPowered = false;
            }
        }

        private class NorthCommand : IRobotCommand
        {
            public void Run(Robot robot)
            {
                if (robot.IsPowered)
                    robot.Y++;
            }
        }

        private class EastCommand : IRobotCommand
        {
            public void Run(Robot robot)
            {
                if (robot.IsPowered)
                    robot.X++;
            }
        }

        private class SouthCommand : IRobotCommand
        {
            public void Run(Robot robot)
            {
                if (robot.IsPowered)
                    robot.Y--;
            }
        }

        private class WestCommand : IRobotCommand
        {
            public void Run(Robot robot)
            {
                if (robot.IsPowered)
                    robot.X--;
            }
        }

        // ----------------------- Interface Experiments -----------------------

        public class MyClass : BaseClass, /*MyOtherBaseClass,*/ IBroaderInterface // Can only have ONE base class
        {
            public int MyProperty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public override void DoSomething()
            {
                throw new NotImplementedException();
            }

            // Because 'Play' has a default implementation, I don't need to implement it
            //public void Play() // Must implement the 'narrower' interface as well
            //{
            //    throw new NotImplementedException();
            //}

            public void Stop()
            {
                throw new NotImplementedException();
            }
        }

        // An interface can also implement another interface
        interface IBroaderInterface : INarrowerInterface
        {
            void Stop();
        }

        interface INarrowerInterface
        {
            void Play()
            {
                DoAThing();
                Console.WriteLine("This is a default implementation");
            }

            private void DoAThing()
            {
                // A private method to support my default implementation
            }

            static void StaticThing()
            {

            }

            // Interfaces can contain properties but not private instance variables, unless they are static
            public int MyProperty { get; set; }
            //private int MyPrivateInt;
            private static int X;
        }

        public abstract class BaseClass
        {
            public abstract void DoSomething();
        }

        public abstract class MyOtherBaseClass
        {
            public abstract void DoSomethingElse();
        }
    }
}





