using System.Dynamic;

namespace CSharpPlayersGuide.Levels
{
    internal class Level45 : ILevel
    {
        public static void Notes()
        {
            Console.WriteLine("Dynamic objects instruct the compiler not to check types during compile.");
            Console.WriteLine("Should be avoided unless the provide a clear benifit.");
            Console.WriteLine("ExpandoObject is best for simple, expandable types.");
            Console.WriteLine("Extending DynamicObject gives you more control.");
            Console.WriteLine("");
            Console.WriteLine("Generally speaking, C# is a statically typed lang, and the compiler does static type checking.");
            Console.WriteLine("This means that the compiler ensures that types have the methods and properties that they claim to have, or the program wont build.");
            Console.WriteLine("C# can support dynamic types or dynamic objects (objects that have no set types).");
            Console.WriteLine(
"""
The following will compile but throw errors at runtime:

dynamic myString = "Hello";
myString += Math.PI;
myString *= 10;
Console.WriteLine(myString.SomethingMadeUp());

Meanwhile, the following will run:

dynamic mystery = "Hello!";
Console.WriteLine(mystery.Length);
mystery = 2;
mystery += Math.PI;
mystery *= 10;
Console.WriteLine(mystery);

The dynamic object is able to chage types!
""");
            dynamic mystery = "Hello!";
            Console.WriteLine(mystery.Length);
            mystery = 2;
            mystery += Math.PI;
            mystery *= 10;
            Console.WriteLine(mystery);
            Console.WriteLine("");
            Console.WriteLine("The ExpandoObject create a dynamic object that you can add properties and methods to!");
            Console.WriteLine(
"""
dynamic expando = new ExpandoObject();
expando.Name = "Bill";
expando.Age = 42;
expando.HaveABirthday = new Action(() => expando.Age++);
""");
            Console.WriteLine("");

            dynamic expando = new ExpandoObject();
            expando.Name = "Bill";
            expando.Age = 42;
            expando.HaveABirthday = new Action(() => expando.Age++);

            Console.WriteLine($"Age: {expando.Age}");
            Console.WriteLine("Have a birthday!");
            expando.HaveABirthday();
            Console.WriteLine($"Age: {expando.Age}");
            Console.WriteLine("Have a birthday!");
            expando.HaveABirthday();
            Console.WriteLine($"Age: {expando.Age}");
        }

        public static void UniterOfAdds()
        {
            Console.WriteLine("Static Adds:");
            Console.WriteLine(Adds.Add(1, 2));
            Console.WriteLine(Adds.Add(1.5, 0.75));
            Console.WriteLine(Adds.Add("--> ", "<--"));
            Console.WriteLine(Adds.Add(DateTime.Now, TimeSpan.FromHours(1.5)));
            Console.WriteLine("Dynamic Adds:");
            Console.WriteLine(AddsUnited.Add(1, 2));
            Console.WriteLine(AddsUnited.Add(1.5, 0.75));
            Console.WriteLine(AddsUnited.Add("--> ", "<--"));
            Console.WriteLine(AddsUnited.Add(DateTime.Now, TimeSpan.FromHours(1.5)));
            Console.WriteLine(
"""
The downside of dynamic adds is that you no longer have compile time checking, so you can pass in invalid params:

// Will fail at compile time:
Console.WriteLine(Adds.Add(DateTime.Now, 1.345));
// Will throw an error at runtime:
Console.WriteLine(AddsUnited.Add(DateTime.Now, 1.345));
""");
            //Console.WriteLine(Adds.Add(DateTime.Now, 1.345));
            //Console.WriteLine(AddsUnited.Add(DateTime.Now, 1.345));
        }

        private static class AddsUnited
        {
            public static dynamic Add(dynamic a, dynamic b) => a + b;
        }

        private static class Adds
        {
            public static int Add(int a, int b) => a + b;
            public static double Add(double a, double b) => a + b;
            public static string Add(string a, string b) => a + b;
            public static DateTime Add(DateTime a, TimeSpan b) => a + b;
        }


        public static void TheRobotFactory()
        {
            var id = 1;

            while (true)
            {
                Utilities.PrintInColor("Do you want to exit? (y/n)", 5);
                var shouldExit = Console.ReadLine();
                if (shouldExit == "y") break;

                dynamic robot = new ExpandoObject();
                robot.Id = id++;

                Utilities.PrintInColor("Do you want to name this robot? (y/n)", 7);
                var shouldName = Console.ReadLine();
                if (shouldName == "y")
                {
                    Utilities.PrintInColor("What is its name?", 3);
                    robot.Name = Console.ReadLine();
                }

                Utilities.PrintInColor("Does this robot have a specific size? (y/n)", 7);
                var shouldHaveSize = Console.ReadLine();
                if (shouldHaveSize == "y")
                {
                    Utilities.PrintInColor("What is its height?", 3);
                    robot.Height = Console.ReadLine();

                    Utilities.PrintInColor("What is its width?", 3);
                    robot.Width = Console.ReadLine();
                }

                Utilities.PrintInColor("Does this robot need to be a specific color? (y/n)", 7);
                var shouldHaveColor = Console.ReadLine();
                if (shouldHaveColor == "y")
                {
                    Utilities.PrintInColor("What color?", 3);
                    robot.Color = Console.ReadLine();
                }

                foreach (KeyValuePair<string, object> property in (IDictionary<string, object>)robot)
                {
                    Utilities.PrintInColor($"{property.Key}: {property.Value}", 4);
                }
            }
        }
    }
}
