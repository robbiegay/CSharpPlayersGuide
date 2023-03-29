namespace CSharpPlayersGuide.Levels
{
    internal static class Level23
    {
        public static void Notes()
        {
            Utilities.PrintNotesTitle(23);

            Console.WriteLine("");
            Console.WriteLine("Object oriented design is about deciding:\n\t- What objects belong to what classes.");
            Console.WriteLine("\t- What classes you need for your program.\n\t- The functionality needed in those classes.");
            Console.WriteLine("");
            Console.WriteLine("Object oriented design is hard, and takes many years to master. You will get it ");
            Console.WriteLine("wrong -- luckily software is soft (mailiable) and you will have the chance to change things.");
            Console.WriteLine("");
            Utilities.PrintInColor("Step 1: Gather the requirements", 2);
            Console.WriteLine("This is often a sentence or two about each feature.");
            Console.WriteLine("Draw an illistration if that helps. A specific example is also useful.");
            Console.WriteLine("Requirements will change as the progress continues and you learn more.");
            Console.WriteLine("");
            Utilities.PrintInColor("Step 2: Design the software", 2);
            Console.WriteLine("Noun extraction:\nConcepts that appear in your requirements lead to classes,");
            Console.WriteLine("jobs that appear in your requirements lead to jobs responsabilities that your");
            Console.WriteLine("software must do. We start this process by highlighting nouns and verbs.");
            Console.WriteLine("Example from the book:");
            Console.WriteLine("\"Asteroids drift through space at some specific velocity. The nouns 'asteroid',");
            Console.WriteLine("'space', and 'velocity' are all potential concepts that we may or may not make classes around,");
            Console.WriteLine("and the verb 'drift' is a job that some object (or several objects) in our system will");
            Console.WriteLine("need  to  do.\"");
            Console.WriteLine("");
            Console.WriteLine("It is important to note that this is only the beginning of the design process.");
            Console.WriteLine("Only finished code that does what it is meant to do can be considered a complete");
            Console.WriteLine("design. That said, pen and paper or a whiteboard -- where changes are ");
            Console.WriteLine("trivial -- is where more developers like to start.");
            Console.WriteLine("");
            Console.WriteLine("UML: Unified Modeling Language");
            Console.WriteLine("UML is a more formal design method than the CRC cards used in this book.");
            Console.WriteLine("You should be aware of UML as many developers use it.");
            Console.WriteLine("");
            Console.WriteLine("CRC Cards: Class, Responsibility, Collaborators");
            Console.WriteLine("3x5 index cards with the class name written at the top.");
            Console.WriteLine("On the left, the class's responsibilities: a thing to know or a thing to do.");
            Console.WriteLine("On the right, the class's collaborators. I.e. objects that help it fulfill its responsibilities.");
            Console.WriteLine("");
            Utilities.PrintInColor("Step 3: Evaluate the design", 2);
            Console.WriteLine("Rule 1: It has to work");
            Console.WriteLine("Rule 2: Perfer designs that convey meaning and intent: You will spend more time reading code than");
            Console.WriteLine("writing it -- will your design make sense to others?");
            Console.WriteLine("Rule 3: Designs should not contain duplication");
            Console.WriteLine("Rule 4: Designs should not have unused elements: YAGNI (you ain't gonna need it)");
        }
    }
}
