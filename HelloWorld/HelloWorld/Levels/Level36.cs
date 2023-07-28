namespace CSharpPlayersGuide.Levels
{
    internal class Level36 : ILevel
    {
        public static void Notes()
        {
            Utilities.PrintNotesTitle(36);

            Console.WriteLine("Delegated allow you to pass a function around like a variable.");
            Console.WriteLine("This allows you to pass a function into another function and have that function execute that code.");
            Console.WriteLine("");
            Console.WriteLine("For example, imagine we have a few methods to change arrays:");
            Console.WriteLine("");
            Utilities.PrintCode(
"""
private static int[] AddOne(int[] arr)
{
    var output = new int[arr.Length];

    for (int i = 0; i < arr.Length; i++)
    {
        output[i] = arr[i] + 1;
    }

    return output;
}

private static int[] SubtractOne(int[] arr)
{
    var output = new int[arr.Length];

    for (int i = 0; i < arr.Length; i++)
    {
        output[i] = arr[i] - 1; // Only changing 1 token
    }

    return output;
}

private static int[] Double(int[] arr)
{
    var output = new int[arr.Length];

    for (int i = 0; i < arr.Length; i++)
    {
        output[i] = arr[i] * 2; // Only chaging 2 tokens
    }

    return output;
}
""");
            Console.WriteLine("");
            var arr = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine("For testing: var arr = new int[] { 1, 2, 3, 4, 5 };");
            Console.WriteLine("");
            Console.Write("AddOne: ");
            PrintArray(AddOne(arr));
            Console.WriteLine("");
            Console.Write("SubtractOne: ");
            PrintArray(SubtractOne(arr));
            Console.WriteLine("");
            Console.Write("Double: ");
            PrintArray(Double(arr));
            Console.WriteLine("");
            Console.WriteLine("The problem is that this is a lot of duplicated code!");
            Console.WriteLine("Now we create a simple delegate method that we pass into our array function:");
            Console.WriteLine("");
            Utilities.PrintCode(
"""
private delegate int MathOperation(int input);
private int AddMethod(int input) => input++;
private int SubtractMethod(int input) => input--;
private int DoubleMethod(int input) => input * 2;
private int BaseTwoMethod(int input) => Math.ILogB(input);

private static int[] ChangeArray(int[] arr, MathOperation operation)
{
    var output = new int[arr.Length];

    for (int i = 0; i < arr.Length; i++)
    {
        output[i] = operation(arr[i]);
    }

    return output;
}
""");
            Console.WriteLine("");
            Console.Write("Adding: ");
            PrintArray(ChangeArray(arr, AddMethod));
            Console.WriteLine("");
            Console.Write("Subtraction: ");
            PrintArray(ChangeArray(arr, SubtractMethod));
            Console.WriteLine("");
            Console.Write("Doubling: ");
            PrintArray(ChangeArray(arr, DoubleMethod));
            Console.WriteLine("");
            Console.Write("Base 2, whatever that means: ");
            PrintArray(ChangeArray(arr, BaseTwoMethod));
            Console.WriteLine("");
        }

        private static void PrintArray(int[] arr)
        {
            foreach (var a in arr)
            {
                Console.Write($"{a} ");
            }

            Console.Write("\n");
        }

        private static int[] AddOne(int[] arr)
        {
            var output = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                output[i] = arr[i] + 1;
            }

            return output;
        }

        private static int[] SubtractOne(int[] arr)
        {
            var output = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                output[i] = arr[i] - 1; // Only changing 1 token
            }

            return output;
        }

        private static int[] Double(int[] arr)
        {
            var output = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                output[i] = arr[i] * 2; // Only chaging 2 tokens
            }

            return output;
        }

        private delegate int MathOperation(int input);
        private static int AddMethod(int input) => ++input;
        private static int SubtractMethod(int input) => --input;
        private static int DoubleMethod(int input) => input * 2;
        private static int BaseTwoMethod(int input) => Math.ILogB(input);

        private static int[] ChangeArray(int[] arr, MathOperation operation)
        {
            var output = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                output[i] = operation(arr[i]);
            }

            return output;
        }

        public static void TheSieve()
        {

        }
    }
}
