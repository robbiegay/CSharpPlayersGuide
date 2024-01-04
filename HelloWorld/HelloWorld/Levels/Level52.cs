namespace CSharpPlayersGuide.Levels
{
    internal class Level52
    {
        public static void BookSummary()
        {
            Console.WriteLine("""
                Notes: The level covers the final boss battle. I think this would be pretty
                time consuming, and I think a better use of my time would be to review my 
                notes from the previous levels and produce a sort of cheat sheet.

                [Cheat sheet in pending me ever getting around to doing it]

                On thing I always forgot was how to use switch expressions:

                var y = 5;
                var x = y switch
                {
                    1 => "its a one",
                    2 => "its a two",
                    _ => "it is not one or two..."
                };
                Console.WriteLine(x); // will print out after all the notes
                """);

            var y = 5;
            var x = y switch
            {
                1 => "its a one",
                2 => "its a two",
                _ => "it is not one or two..."
            };
            Console.WriteLine(x);
        }
    }
}
