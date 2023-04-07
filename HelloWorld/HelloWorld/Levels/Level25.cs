namespace CSharpPlayersGuide.Levels
{
    internal class Level25
    {
        public static void Notes()
        {
            Utilities.PrintNotesTitle(25);

            Console.WriteLine("");
            Console.WriteLine("Inheritance lets a class inherit everything from a parent class except its ctor's");
            Console.WriteLine("");
            Utilities.PrintCode("class Child : Parent { ... }");
            Console.WriteLine("");
            Console.WriteLine("All classes derive implicitly from the 'object' class.");
            Console.WriteLine("Constructors in the derived class must call the base class ctor (unless using a parameterless ctor):");
            Console.WriteLine("");
            Utilities.PrintCode("public Child(int x) : Parent(x) { ... }");
            Console.WriteLine("");
            Console.WriteLine("The 'protected' accessibility modifier makes things accessable only in the class and its derived classes.");
            Console.WriteLine("");
            Console.WriteLine("Null char: ->\0<-");
            Console.Write("Typing...");
            Console.Write("\b\b\b");
            Console.Write("backspace"); // Backspace deleted the three '.'s
            Console.WriteLine("");
            Console.WriteLine("What is a ->\f<- form feed?"); // form feed seems to act similar to newline
            Console.WriteLine("");
            Console.WriteLine("What about a carriage ->\r<- return?"); // \r returned to the begining of the line a overwrote the first few chars
            Console.WriteLine("");
            Console.WriteLine("\vVertical tab"); // just added an extra line space
            Console.WriteLine("");
            Console.WriteLine("\U0001F47D"); // displays ?? in console window

            Console.WriteLine("");
            Utilities.TypewriterType("This is a message", 100, 2000, true, false);
            Utilities.TypewriterType("And I am writing this next", 100, 2000, true, false);
        }

        public static void PackingInventory()
        {

        }
    }
}
