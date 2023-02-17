namespace CSharpPlayersGuide.Levels
{
    internal class Level7
    {
        public static void TheTriangleFarmer()
        {
            // Compute area of triangle
            Console.WriteLine("Calculate the area of a triange...");
            Console.WriteLine("Enter a base length:");
            double baseValue;
            double.TryParse(Console.ReadLine(), out baseValue);
            double height;
            Console.WriteLine("Enter a height:");
            double.TryParse(Console.ReadLine(), out height);
            double area = baseValue * height / 2.0;

            Utilities.PrintInColor($"\n{area} = {baseValue} * {height} / 2", 4);
        }

        // Notes:
        /*
        int testInt = short.MinValue;
        Console.WriteLine(testInt);
        Console.WriteLine(double.NegativeInfinity);
        Console.WriteLine(double.NaN);
        Console.WriteLine(8.0 / 0); // floating point division by zero assumes that you are actually dividing by an incredibly small (infinitesmal) but non-zero number
        Console.WriteLine(-8.0 / 0);
        Console.WriteLine(0.0 / 0); // 0.0 / 0.0 = NaN

        // Inverting numbers using negation sign (-)
        int aaa = -1;
        Console.WriteLine(+aaa);
        aaa = -aaa;
        Console.WriteLine(aaa);
        aaa = -aaa;
        Console.WriteLine(aaa);
        */

        public static void TheFourSistersAndTheDuckbear()
        {
            Console.WriteLine("Enter the number of chocolate eggs laid today:");
            int eggs;
            int.TryParse(Console.ReadLine(), out eggs);
            Utilities.PrintInColor($"\nTotal eggs: {eggs}", 4);
            
            var sisterEggs = eggs / 4;
            Utilities.PrintInColor($"Each of the 4 sisters will recieve {sisterEggs} {(sisterEggs == 1 ? "egg" : "eggs")}", 4);

            var duckbearEggs = eggs % 4;
            Utilities.PrintInColor($"Duckbear will recieve {duckbearEggs} {(duckbearEggs == 1 ? "egg" : "eggs")}", 4);
        }

        public static void TheDominionOfKings()
        {
            var kings = new string[3] { "Melik", "Casik", "Balik" };
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Enter the number of estates for {kings[i]}:");
                int estates;
                int.TryParse(Console.ReadLine(), out estates);
                Console.WriteLine($"Enter the number of duchies for {kings[i]}:");
                int duchies;
                int.TryParse(Console.ReadLine(), out duchies);
                Console.WriteLine($"Enter the number of provinces for {kings[i]}:");
                int provinces;
                int.TryParse(Console.ReadLine(), out provinces);

                Utilities.PrintInColor($"\n{kings[i]} has the following points:", 4);
                Utilities.PrintInColor($"estates: {estates} x 1 point = {estates *= 1}", 4);
                Utilities.PrintInColor($"duchies: {duchies} x 3 points = {duchies *= 3}", 4);
                Utilities.PrintInColor($"provinces: {provinces} x 6 points = {provinces *= 6}", 4);
                Utilities.PrintInColor($"Total = {estates + duchies + provinces}\n", 4);
            }
        }

        // Notes:
        /*
        byte a = byte.MaxValue;
        byte b = 4;
        byte result = (byte)(a + b); // no addition defined for shorts so there is implicit casting to int, so you have to do an explicit cast back to int
        Console.WriteLine(result);

        Console.WriteLine(Math.Clamp(50, 0, 100)); // keeps a value in a range
        */
    }
}
