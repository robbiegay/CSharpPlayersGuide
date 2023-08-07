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

            Console.WriteLine("Action and Func delegetes mean that you don't often have to define your own.");
            Console.WriteLine("Action = void return type");
            Console.WriteLine("Func = has a return type");
            Console.WriteLine("Each can have up to 16 parameters");
            Console.WriteLine("Action = void MyFunc()");
            Console.WriteLine("Action<int> = void MyFunc(int x)");
            Console.WriteLine("Action<int, string> = void MyFunc(int x, string a)");
            Console.WriteLine("Func<string> = string MyFunc()");
            Console.WriteLine("Func<int, string> = string MyFunc(int x)");
            Console.WriteLine("Func<int, bool, string> = string MyFunc(int x, bool isValid)");
            Console.WriteLine("");
            Console.WriteLine("There is also the Predicate type.");
            Console.WriteLine("Predicates are used in math to see if something belongs in a set.");
            Console.WriteLine("Predicate<int, int> = bool MyFunc(int x, int y)");
            Console.WriteLine();
            Console.WriteLine("Some Action and Predicate test results:");
            PrintMessage(message: SayHi);
            PrintMessage(messageName: SayHiToSomeone, name: "Rob");
            PrintMessage(messageAge: SayHiToSomeoneWhoIsAge, name: "Tim", age: 25);
            Console.WriteLine($"Expected: true, Result: {NumberTest(IsEven, -2)}");
            Console.WriteLine($"Expected: false, Result: {NumberTest(IsEven, -1)}");
            Console.WriteLine($"Expected: true, Result: {NumberTest(IsEven, 0)}");
            Console.WriteLine($"Expected: false, Result: {NumberTest(IsEven, 1)}");
            Console.WriteLine($"Expected: true, Result: {NumberTest(IsEven, 2)}");
            Console.WriteLine($"Expected: false, Result: {NumberTest(IsGreaterThanZero, -2)}");
            Console.WriteLine($"Expected: false, Result: {NumberTest(IsGreaterThanZero, -1)}");
            Console.WriteLine($"Expected: false, Result: {NumberTest(IsGreaterThanZero, 0)}");
            Console.WriteLine($"Expected: true, Result: {NumberTest(IsGreaterThanZero, 1)}");
            Console.WriteLine($"Expected: true, Result: {NumberTest(IsGreaterThanZero, 2)}");
            Console.WriteLine("");
            Console.WriteLine("You can chain multiple delegates together.");
            Console.WriteLine("When called, the method will be called on each in the order they were added.");
            Console.WriteLine("The return type is that of the last one called, so it is best if they are all: void");
            Console.WriteLine("Use + or += to add and - or -= to remove.");
            Console.WriteLine("");
            Console.WriteLine("Here I am adding Actions to a delegate and then running the delegate once:");
            Utilities.PrintCode(
"""
private static void Message1() => Console.WriteLine("Message 1!");
private static void Message2() => Console.WriteLine("Message 2!");
private static void Message3() => Console.WriteLine("Message 3!");
private static void Message4() => Console.WriteLine("Message 4!");

Action myAction = null;
myAction += Message1;
myAction += Message2;
myAction += Message3;
myAction += Message4;
myAction -= Message4;
myAction();
""");
            Action myAction = null;
            myAction += Message1;
            myAction += Message2;
            myAction += Message3;
            myAction += Message4;
            myAction -= Message4;
            myAction();
        }

        // Delegate Chaining:
        private static void Message1() => Console.WriteLine("Message 1!");
        private static void Message2() => Console.WriteLine("Message 2!");
        private static void Message3() => Console.WriteLine("Message 3!");
        private static void Message4() => Console.WriteLine("Message 4!");

        // Predicate Test:
        private static bool NumberTest(Predicate<int> condition, int x)
        {
            return condition(x);
        }

        private static bool IsEven(int x) => x % 2 == 0;
        private static bool IsGreaterThanZero(int x) => x > 0;

        // Action Test:
        private static void PrintMessage(Action message = null, Action<string> messageName = null, Action<string, int?> messageAge = null, string? name = null, int? age = null)
        {
            Console.WriteLine();
            Console.WriteLine("I'm going to print a message...");
            if (name is null && age is null)
                message();
            else if (age is null)
                messageName(name);
            else
                messageAge(name, age);
            Console.WriteLine("That was my message!");
            Console.WriteLine();
        }

        private static void SayHi()
        {
            Console.WriteLine("Hi!");
        }

        private static void SayHiToSomeone(string someone)
        {
            Console.WriteLine($"Hi, {someone}!");
        }

        private static void SayHiToSomeoneWhoIsAge(string someone, int? age)
        {
            Console.WriteLine($"Hi, {someone} -- a person of {age} years!");
        }

        // Notes Test:
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
