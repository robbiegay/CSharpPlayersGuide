using System.Diagnostics;

namespace CSharpPlayersGuide.Levels
{
    internal class Level43 : ILevel
    {
        public static void Notes()
        {
            Utilities.PrintNotesTitle(43);

            Console.WriteLine(
"""
- 0: Notes
- 1: Threads Experiment 1
- 2: Threads Experiment 2
- 3: Threads Experiment 3
- 3: Threads Experiment 3
- 4: Threads Experiment 4
""");
            var selection = Console.ReadLine();

            if (selection == "0")
            {
                Console.WriteLine("");
                Console.WriteLine("Running with multiple threads is called concurency.");
                Console.WriteLine("Each program you make gets a thread that starts with your Main");
                Console.WriteLine("method and runs line-by-line until it completes.");
                Console.WriteLine("");
                Console.WriteLine("Using multiple threads can allow your system to run faster.");
                Console.WriteLine("Knowing when to use muliti-threading is an art and a science.");
                Console.WriteLine("");
                Console.WriteLine("Threads get their own stack but share the heap. There are almosts");
                Console.WriteLine("always more threads can processors on your computer, so the 'scheduler'");
                Console.WriteLine("does some compplex logic to decide when to let each thread have a");
                Console.WriteLine("chance to run. There is overhead assoicated with this, so your new");
                Console.WriteLine("threads need to run on things that are:\n\t- Seperate from your other code");
                Console.WriteLine("\t- And will take long enough to be worth multi-threading.");
                Console.WriteLine("");
                Console.WriteLine("You can create a new thread via: var t = new Thread(del);");
                Console.WriteLine("del = a void, parameterless method. Run the thread: t.Start();");
                Console.WriteLine("");
                Console.WriteLine("You can join your thread to others to wait for them to finish:");
                Console.WriteLine("t.Join();");
                Console.WriteLine("");
                Console.WriteLine(
                    """
                    Working with threads can lead to concurency issues, so only work with
                    threads when you really have to. These occur when: modifying the same data.
                    Work arounds include: using readonly data or a mutex (mutually exclusive)
                    device on data. In C#, this is often the 'lock' keyword.
                    You use a mutex on a 'critical section' of code that should only
                    be used by one thread at a time.

                    Generally, you will use a single lock object per piece of data
                    or related data. You need to be careful when using multiple locks
                    as this can lead to a 'deadlock' where two processes are waiting
                    for the other to release their lock.
                    """);
            }
            else if (selection == "1")
                {
                Console.WriteLine("Enter: 1 = run multithreaded, 2 = single threaded, else = skip");
                var input = Console.ReadLine();

                if (input == "1")
                {
                    Thread thread1 = new Thread(DoMath);
                    Thread thread2 = new Thread(DoMath);
                    Thread thread3 = new Thread(DoMath);

                    thread1.Start();
                    thread2.Start();
                    thread3.Start();
                }
                else if (input == "2")
                {
                    DoMath();
                    DoMath();
                    DoMath();
                }
            }
            else if (selection == "2")
            {
                while (true)
                {
                    Console.WriteLine(
                        """
                        Enter:
                        - 1: run multi-threaded
                        - 2: run multi-threaded but wait to finish
                        - 3: run single threaded
                        - e: break
                        """);

                    var userInput = Console.ReadLine();

                    if (userInput == "e")
                        break;
                    else if (userInput == "1")
                    {
                        var t1 = new Thread(CountTo100);
                        var t2 = new Thread(CountTo100);

                        t1.Start();
                        t2.Start();
                    }
                    else if (userInput == "2")
                    {
                        var t1 = new Thread(CountTo100);
                        var t2 = new Thread(CountTo100);

                        t1.Start();
                        t2.Start();

                        t1.Join();
                        t2.Join();
                    }
                    else if (userInput == "3")
                    {
                        CountTo100();
                        CountTo100();
                    }

                    Utilities.PrintInColor("Finished running...", 3);
                }
            }
            else if (selection == "3")
            {
                Console.WriteLine("Run 5 threads. Each thread prints 1 char of space and");
                Console.WriteLine("is a different color. Gives a visual feel for how");
                Console.WriteLine("threads are swapped.");

                var iterations = 500;
                var settings1 = new ColorSettings(1, iterations);
                var settings2 = new ColorSettings(2, iterations);
                var settings3 = new ColorSettings(5, iterations);
                var settings4 = new ColorSettings(9, iterations);
                var settings5 = new ColorSettings(14, iterations);

                var t1 = new Thread(PrintSomeColors);
                var t2 = new Thread(PrintSomeColors);
                var t3 = new Thread(PrintSomeColors);
                var t4 = new Thread(PrintSomeColors);
                var t5 = new Thread(PrintSomeColors);

                t1.Start(settings1);
                t2.Start(settings2);
                t3.Start(settings3);
                t4.Start(settings4);
                t5.Start(settings5);

                t1.Join();
                t2.Join();
                t3.Join();
                t4.Join();
                t5.Join();

                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (selection == "4")
            {
                Console.WriteLine("Intentionally creates a situation where two threads");
                Console.WriteLine("both modify an object and moniters when this leads to");
                Console.WriteLine("inccorect results (ie concurrency issues). Made this");
                Console.WriteLine("more likely by throwing in some Thread.Sleep's.");

                Utilities.PrintInColor("Do you want to use a lock (y/n)?", 4);
                var response = Console.ReadLine();
                Console.WriteLine();

                var iterations = 200;
                var successes = 0;
                var failures = 0;

                for (int i = 0; i < iterations; i++)
                {
                    var op = new Operation();
                    op.UseLock = response == "y";
                    var t1 = new Thread(op.Increment);

                    t1.Start();

                    op.Increment();

                    t1.Join();

                    if (op.Value == 2)
                        successes++;
                    else if (op.Value == 1)
                        failures++;

                    Utilities.PrintInColor("Value: ", 3, true);
                    Utilities.PrintInColor($"{op.Value}", 2, true);
                    Utilities.PrintInColor(", Successes: ", 3, true);
                    Utilities.PrintInColor($"{successes}", 6, true);
                    Utilities.PrintInColor(", Failures: ", 3, true);
                    Utilities.PrintInColor($"{failures}", 1, false);
                }
            }
        }

        private class Operation
        {
            private object _valueLock = new object();
            public bool UseLock { get; set; }
            public int Value { get; set; }
            public void Increment()
            {
                if (!UseLock)
                {
                    var rnd = new Random();

                    var oldValue = Value;

                    var s1 = rnd.Next(2);
                    Thread.Sleep(s1);

                    var newValue = oldValue + 1;

                    var s2 = rnd.Next(2);
                    Thread.Sleep(s2);

                    Value = newValue;
                }
                else
                {
                    lock (_valueLock)
                    {
                        var rnd = new Random();

                        var oldValue = Value;

                        var s1 = rnd.Next(2);
                        Thread.Sleep(s1);

                        var newValue = oldValue + 1;

                        var s2 = rnd.Next(2);
                        Thread.Sleep(s2);

                        Value = newValue;
                    }
                }
            }
        }

        private static void PrintSomeColors(object? s)
        {
            if (s == null) return;
            var settings = (ColorSettings)s;

            for (int i = 0; i < settings.GoalCount - 1; i++)
            {
                Console.BackgroundColor = (ConsoleColor)settings.Color;
                Console.Write(" ");
            }

                Console.Write("X");
        }

        private class ColorSettings
        {
            public int Color { get; set; }
            public int GoalCount { get; set; }

            public ColorSettings(int color, int goalCount)
            {
                Color = color;
                GoalCount = goalCount;
            }
        }

        private static void CountTo100()
        {
            var rnd = new Random();
            var color = rnd.Next(16);
            if ((int)Console.ForegroundColor == color)
            {
                color = (color == 15) ? color - 1 : color + 1;
            }
            
            for (int i = 0; i < 100; i++)
            {
                Utilities.PrintInColor($"{i}", color);
            }
        }

        private static void DoMath()
        {
            var sw = new Stopwatch();
            sw.Start();

            var loop = ushort.MaxValue;
            var stuff = "";

            while (loop > 0)
            {
                stuff += " ";
                loop--;
            }

            sw.Stop();

            Console.WriteLine($"Took {sw.ElapsedMilliseconds} milliseconds.");
        }

        public static void TheRepeatingStream()
        {

        }
    }
}
