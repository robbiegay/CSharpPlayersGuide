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
