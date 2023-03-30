namespace CSharpPlayersGuide.Levels
{
    internal static class Level22
    {
        public static void Notes()
        {
            Utilities.PrintNotesTitle(22);
            Console.WriteLine("You can check for null via:");
            Utilities.PrintCode(
"""
x == null

// The 'is' keyword ignores operator overloads which could cause x == null to be false even if x does equal null
x is null 
x is not null

x?.Length // Only checks Length if x != null

x ?? y // if x == null, use y

// using the discard operator -> _
_ = x ?? throw new NullReferenceException(); 
""");
            string x = null;
            if (x == null) { }
            if (x is null) { }
            //_ = x ?? throw new NullReferenceException();

            var y = x?.Length;
            var z = x ?? "x was null";

            Console.WriteLine("");
            Console.WriteLine("Since C# 9, you can make nullable reference types:");
            Utilities.PrintCode("string? x;");
            Console.WriteLine("");
            Console.WriteLine("Without '?', the compiler will give you helpful warnings if there");
            Console.WriteLine("is a chance that your variable will be set to null. You can add the");
            Console.WriteLine("nullable operator if your variable can legitimately be set to null.");
            Console.WriteLine("");
            Console.WriteLine("This sets up 2 null check situations:");
            Console.WriteLine("\t1. Nullable types:     Check that the variable is NOT null BEFORE using it.");
            Console.WriteLine("\t2. Non-nullable types: Check that anything you assign to the variable is not null.");
            Console.WriteLine("");
            Console.WriteLine("Once compiled, a nullable and non-nullable string are the same thing.");
            Console.WriteLine("The nullable operator just gives you helpful warnings while coding.");
            Utilities.PrintInColor("-> This is interesting: how much of c# code is just tossed when compiled?", 2);
            Console.WriteLine("");
            Console.WriteLine("Null compound assignment operator:");
            Utilities.PrintCode("x ??= y // if x is null, then set x to y");
            Console.WriteLine("");
            Console.WriteLine("Null forgiving operator:");
            Console.WriteLine("Sometimes, the compiler cannot tell that a value is guaranteed NOT to return null.");
            Console.WriteLine("You can use the null forgiving operator, that basically says:");
            var promiseColor = 15;
            Utilities.PrintInColor("\"Hey, I know you think we will be null here, but", promiseColor);
            Utilities.PrintInColor("I -- the programmer -- will PROMISE that this value will NEVER be null.\"", promiseColor);
            Console.WriteLine("");
            Console.WriteLine("To be honest, it is probably better to rewrite your code, as that kind of");
            Console.WriteLine("promise is hard to keep");
            Console.WriteLine("");
            Utilities.PrintCode("var b = myValue!.Length; // ! == null forgiving operator");
            string myValue = null;

            var a = 3;
            if (a == 3) // The compiler cannot tell that this will set myValue to a non-null value
                myValue = "hi";

            var b =myValue!.Length;// Compiler warning without the ! operator


            Console.WriteLine("");
        }
    }
}
