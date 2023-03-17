namespace CSharpPlayersGuide.Levels
{
    internal static class Level21
    {
        public static void Notes()
        {
            Utilities.PrintInColor("Level 21 Notes:", 3);
            Console.WriteLine("");
            Console.WriteLine("Static things are owned by the type, rather than the instance.");
            Console.WriteLine("A class can be static -- all methods must then be static.");
            Console.WriteLine("");
            Console.WriteLine("Examples of static classes: Console, Math");
            Utilities.PrintInColor("new Console();", 6, true);
            Utilities.PrintInColor(" -> compiler error!", 1, true);
            Console.WriteLine("");
            Utilities.PrintInColor("new Math();", 6, true);
            Utilities.PrintInColor(" -> compiler error!", 1, true);
            //new Console();
            //new Math();
            Console.WriteLine("");
            Console.WriteLine("");
            Utilities.PrintInColor("The Car class has a static company year, and non-static model year", 4);
            Utilities.PrintInColor("var car1 = new Car();", 6);
            Utilities.PrintInColor("var car2 = new Car();", 6);
            Console.WriteLine("");
            Utilities.PrintInColor("car1.CarModelYear = 2005;", 6);
            Utilities.PrintInColor("Car.YearCarCompanyFounded = 1915;", 6);
            Utilities.PrintInColor("car2.CarModelYear = 2012;", 6);
            var car1 = new Car();
            var car2 = new Car();

            car1.CarModelYear = 2005;
            Car.YearCarCompanyFounded = 1915;
            car2.CarModelYear = 2012;

            Utilities.PrintInColor($"car1 model year: {car1.CarModelYear}, company founded: {car1.GetCompanyFoundedYear()}", 2);
            Utilities.PrintInColor($"car2 model year: {car2.CarModelYear}, company founded: {car2.GetCompanyFoundedYear()}", 2);
            Console.WriteLine("");
            Console.WriteLine("Public static fields on a class can be dangerous becuase they make something: global");
            Console.WriteLine("This is bad because one part of the code could change that field, and this could");
            Console.WriteLine("have unexpected results somewhere else in the code. Making static fields both");
            Console.WriteLine("private and readonly can address this issue.");
            Console.WriteLine("");
            Console.WriteLine("You can make a static method. This can be something useful that belongs");
            Console.WriteLine("more to the class than an instance.");
            Console.WriteLine("");
            Console.WriteLine("Constructors can be static. Static constructors cannot be called directly");
            Console.WriteLine("but rather are called implicitly the first time the class is used. This");
            Console.WriteLine("can be useful for initalizing values in the class. Static constructors");
            Console.WriteLine("cannot have access modifiers (public/private) or parameters.");
            Console.WriteLine("");
            Utilities.PrintInColor("-------------------------------------------", 10);
            Console.WriteLine("");
            Console.WriteLine("I think that one of the most interesting aspects of this chapter is:");
            Console.WriteLine("\t1: How static is used in the Program class");
            Console.WriteLine("\t2: How to use static to create a Singleton");
            Console.WriteLine("");
            Console.WriteLine("The Program class (I assume) is used in ASP.NET as a 'code by convention',");
            Console.WriteLine("meaning that ASP.NET expects for there to be a static Program class:");
            Utilities.PrintInColor("public static class Program", 6);
            Console.WriteLine("");
            Console.WriteLine("It further expects that the program class has a static method called Main:");
            Utilities.PrintInColor("static void Main(string[] args)", 6);
            Console.WriteLine("");
            Console.WriteLine("Finally, somewhere in ASP.NET, the Program.Main(args) method is called:");
            Utilities.PrintInColor("Somewhere in ASP.NET -> ", 2, true);
            Utilities.PrintInColor("Program.Main(args);", 6, true);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("This then acts as the entry point of your program.");
            Console.WriteLine("");
            Utilities.PrintInColor("-------------------------------------------", 10);
            Console.WriteLine("");
            Console.WriteLine("The 'static' keyword can be used to create a singleton:");
            Console.WriteLine("");
            Utilities.PrintInColor(
"""
void Main()
{
    var s1 = Singleton.Create();
    s1.Value = 5;
    var s2 = Singleton.Create();
    s2.Value = 10;
    var s3 = Singleton.Create();
    s3.Value = 15;

    s1.Dump();
    s2.Dump();
    s3.Dump();
}

internal class Singleton
{
    private static Singleton singleton;
    private static readonly object singletonLock = new object();

    // If the singleton works, an instance variable should be the same for all objects
    public int Value;

    public static Singleton Create()
    {
        if (singleton is null)
        {
            lock(singletonLock)
            {
                if (singleton is null)
                {
                	singleton = new Singleton();
                }
            }
        }

        return singleton;
    }

    private Singleton()
    {
        //
    }
}
""", 6);
        }

        // Interesting that a static class can have a non-static subclass
        // Also interesting that classes in C# can even have subclasses
        public class Car
        {
            public static int YearCarCompanyFounded;
            public int CarModelYear;

            public int GetCompanyFoundedYear()
            {
                return YearCarCompanyFounded;
            }
        }

        public class Test
        {
            private static int _value;
            public static int Value { get => _value; }

            static Test()
            {
                //
            }
        }

        public static void ArrowFactories()
        {
            Level18.VinFletchersArrows(level: 21);
        }
    }
}
