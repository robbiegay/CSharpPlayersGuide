namespace CSharpPlayersGuide.Levels
{
    internal static class Level23
    {
        public static void Notes()
        {
            Utilities.PrintNotesTitle(23);

            Console.WriteLine("");
            Console.WriteLine("Object oriented design is about deciding what: objects belong to what classes,");
            Console.WriteLine("what classes you need for your program, and the functionality needed in those classes.");
            Console.WriteLine("");
            Console.WriteLine("Object oriented design is hard, and takes many years to master. You will get it ");
            Console.WriteLine("wrong -- luckily software is mailiable and you will have the chance to change things.");
            Console.WriteLine("");
            Utilities.PrintInColor("Step 1: Gather the requirements", 2);
            Console.WriteLine("This is often a sentence or two about each feature.");
            Console.WriteLine("Draw an illistration if that helps. An specific example is also useful.");
            Console.WriteLine("Requirements will change as the progress continues and you learn more.");
            Console.WriteLine("");
            Utilities.PrintInColor("Step 2: Design the software", 2);
            Console.WriteLine("Noun extraction: Concepts that appear in your requirements lead to classes,");
            Console.WriteLine("jobs that appear in your requirements lead to jobs responsabilities that your");
            Console.WriteLine("software must do. We start this process by highlighting nouns and verbs.");
            Console.WriteLine("Example from the book:");
            Console.WriteLine("\"Asteroids drift through space at some specific velocity.The nouns asteroid,");
            Console.WriteLine("space, and velocity are all potential concepts that we may or may not make classes around,");
            Console.WriteLine("and the verb drift is a job that some object (or several objects) in our system will");
            Console.WriteLine("need  to  do.\"");
            Console.WriteLine("");
        }
    }
}
