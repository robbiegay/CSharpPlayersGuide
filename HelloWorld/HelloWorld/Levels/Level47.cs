using System.Security.Cryptography.X509Certificates;

namespace CSharpPlayersGuide.Levels
{
    internal class Level47 : ILevel
    {
        public static void Notes()
        {
            Console.WriteLine(
"""
This chapter covers lot of topics that don't get their own chapters.


yield returns items in an enumerator one at a time, lazily.

const defines values that are constant. readonly is often a better
option because it allows for static/non-static while const is always static.

Attributes let you add metadata to code. You can mark a method as [Obsolete],
which can be the first step in removing it from your code. This will show compiler
warnings/errors when someone tries to use it:
[Obsolete("Don't use this method, my guy", false)] // a message, and false means treat it as a warning
You can create your own attributes.

Reflection lets you inspect code at runtime. This is mainly done with the Type class.
You can get constructors and methods for a Type.

Bit manipulation:
0b0000_0001 << 1; // shifts one to the left
>> // right
& logical and
| or
^ xor
~ not

Preprossesor directives
#error Your error message
#warning Your warning

#region
#endregion

Use IDisposable to call Dispose() to clean up things that aren't managed by GC.

Command line args can be accessed in top level statements as args[].
You can change return type to int, with convention being that 0 = success and all other are error codes.

You can define partial classes. This allows you to have to people 
(often a dev and auto gen code like a GUI designer) to make changes to the same
file without messing eachother up. You can define partial methods, where one class
defines the signature and another the body.

Goto: do not use. It lets you define a lable and jump to that label.

Checked and unchecked contexts: checked means that you throw an error when overflow 
occurs. Can do it like this checked(x + 1) or with brackets: checked { ... }
or turn it on for the whole project. Floating point does not apply, these just go to
infinity. Checked contexts slows things down, so only use it when you really need it.

volitile marks a field as something that the compiler cannot optimize by running
instructions out of order. This can cause issues in multi-threaded contexts. That 
said, there are other tools like lock that might be better.

Quiz:
1. False, readonly has more flexability.
2. System.Type
3. goto
4. partial
5. <<, >>, &, |, ~, ^
6. False
7. True
8. #IF DEBUG, #ENDIF
9. using
10. True
""");
            var max = int.MaxValue;
            Console.WriteLine(max + 1);
            //Console.WriteLine(checked(max + 1)); // throws an error

            var x = 0;
        Top:
            Console.WriteLine($"Looping: {x++}");
            if (x == 10) goto Bottom;
            goto Top;
        Bottom:
            Console.WriteLine("Went to the Bottom label via goto.");


            #region Preprossesor Directives
//#error An error is thrown here
#warning This is just a warning :)
            #endregion

            var i = 0;
            foreach (var item in GetPattern())
            {
                Console.WriteLine(item);
                i++;
                if (i >= 10) break;
            }

            foreach (var fizzy in Fizzbuzz())
            {
                Utilities.PrintInColor(fizzy, 3);
            }

            // Doesn't work:
            //var myType = typeof(MyClass);
            //var constructors = myType.GetConstructors();
            //foreach (var ctor in constructors)
            //{
            //    dynamic newInstance = 1; 

            //    if (ctor.GetParameters().Length == 0)
            //        newInstance = ctor.Invoke(new object[] { null });
            //    else if (ctor.GetParameters().Length == 1)
            //        newInstance = ctor.Invoke(new object[] { 10 });

            //    Console.WriteLine($"From reflection: {newInstance.DoubleAndReturn()}");
            //}
        }

        private class MyClass
        {
            public int Number { get; set; }

            public MyClass()
            {
                Number = 1;
            }

            public MyClass(int number)
            {
                Number = number;
            }

            public int DoubleAndReturn()
            {
                return Number * 2;
            }
        }

        [Obsolete("Don't use this method, my guy", false)]
        //[return: Tasty] // You can specify what the attribute applies to
        private static IEnumerable<int> GetPattern()
        {
            while (true)
            {
                yield return -1;
                yield return 1;
            }
        }

        private static IEnumerable<string> Fizzbuzz()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                    yield return "FizzBuzz";
                else if (i % 3 == 0)
                    yield return "Fizz";
                else if (i % 5 == 0)
                    yield return "Buzz";
                else
                    yield return $"{i}";
            }
        }
    }
}
