using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpPlayersGuide.Levels
{
    internal class Level38 : ILevel
    {
        public static void Notes()
        {
            Utilities.PrintNotesTitle(38);
            Console.WriteLine("Lambdas provide a simplified syntax for creating brief, single use functions.");
            Func<int, bool> myFunc;
            myFunc = x => x % 2 == 0;
            Utilities.PrintCode(
$"""
Func<int, bool> myFunc;
myFunc = x => x % 2 == 0;
myFunc(3); -> {myFunc(3)}
myFunc(4); -> {myFunc(4)}
myFunc(5); -> {myFunc(5)}
""");

            Console.WriteLine("");
            Console.WriteLine("Lambdas can have some optional things:");

            Console.Write("\t- For 0 or > 1 parameters, use (): ");
            Utilities.PrintCode("() => DoSomething; OR (x, y) => x < y;\n", true);
            Console.Write("\t- If the compiler cannot infer types, you can add them: ");
            Utilities.PrintCode("(int x) => x % 2 == 0;\n", true);
            Console.Write("\t- Multiple Statements (although, this starts to point to making a private function instead): ");
            Utilities.PrintCode("() => { DoSomething; return SomethingElse; }\n", true);
            Console.Write("\t- Discards: ");
            Utilities.PrintCode("(_, x) => Dosomething;\n", true);
            Console.Write("\t- Return Types: ");
            Utilities.PrintCode("bool (x) => DoSomething;\n", true);
            Console.WriteLine("");
            Console.WriteLine("Lambdas can do something that normal functions cannot: Closures");
            Console.WriteLine("Closures are where a function can capture variables that are in the scope that it is defined in but that ARE NOT actually being passed in.");
            Console.WriteLine("A 'gotcha' of closues is that they don't pass by value like you noramlly expect when passing into a method.");
            Console.WriteLine("Instead, they just hold onto the variable which can cause unexpected results if the variable continues to change.");
            Utilities.PrintCode(
"""
for (int i = 0; i < 10; i++)
{
    myActions[i] = () => Utilities.PrintInColor($"i", 7); // Clousre of the i variable
    // Will print 10 each time intead of 0...10 because the i variable ended with a value of 10
}
""");
            Action[] myActions = new Action[10];
            for (int i = 0; i < 10; i++)
            {
                myActions[i] = () => Utilities.PrintInColor($"{i}", 12); // Clousre of the i variable
                // Will print 10 each time intead of 0...10 because the i variable ended with a value of 10
            }
            for (int i = 0; i < 10; i++)
            {
                myActions[i]();
            }
            Console.WriteLine("");
            Console.WriteLine(
"""
Quiz:
1. True: a simplified, single use method
2. False: lambda's are single use and dont need names
3. x => x < 0;
4. False: they can have 0...many. You must use () with 0 or more than 1.
""");
        }

        public static void TheLambdaSieve()
        {
            Console.WriteLine("Select the sieve condition:");
            Console.WriteLine("\t1 - Even numbers");
            Console.WriteLine("\t2 - Positive numbers");
            Console.WriteLine("\t3 - Multiples of 10");
            var input = Console.ReadLine();

            Func<int, bool> condition = null;
            if (input == "1")
                condition = x => x % 2 == 0;
            else if (input == "2")
                condition = x => x >= 0;
            else if (input == "3")
                condition = x => x % 10 == 0; ;

            var sieve = new Sieve(condition);

            while (true)
            {
                Console.WriteLine("Enter a number to test ('e' to exit):");
                var numberInput = Console.ReadLine();
                if (numberInput == "e") break;
                int.TryParse(numberInput, out var number);
                Console.WriteLine($"Sieve result: {sieve.IsGood(number)}");
            }

            Console.WriteLine("Quiz:");
            Console.WriteLine("Answer to question: Does this change make the program shorter or longer?");
            Console.WriteLine("A little bit shorter.");
            Console.WriteLine("Answer to question: Does this change make the program easier to read or harder?");
            Console.WriteLine("Easier to read.");
        }


        public class Sieve
        {
            private readonly Func<int, bool> _condition;

            public Sieve(Func<int, bool> condition)
            {
                _condition = condition;
            }

            public bool IsGood(int number)
            {
                return _condition(number);
            }
        }
    }
}
