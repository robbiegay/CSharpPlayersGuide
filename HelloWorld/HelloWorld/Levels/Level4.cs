namespace CSharpPlayersGuide.Levels
{
    internal class Level4
    {
        public static void TheThingNamer3000()
        {
            Console.WriteLine("What kind of thing are we talking about?");
            string item = Console.ReadLine() ?? ""; // item
            Console.WriteLine("How would you describe it? Big? Azure? Tattered?");
            string adj = Console.ReadLine() ?? ""; /* adjective */
            string ofDoom = "of Doom";
            string version = "3000";
            Console.WriteLine($"The {adj} {item} of {ofDoom} {version}!");
        }
    }
}
