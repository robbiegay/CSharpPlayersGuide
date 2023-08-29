using System.Diagnostics;

namespace CSharpPlayersGuide.Levels
{
    internal class Level43 : ILevel
    {
        public static void Notes()
        {
            Utilities.PrintNotesTitle(43);

            Console.WriteLine("Enter: 1 = run multithreaded, 2 = single threaded, else = skip");
            var input = "3";//Console.ReadLine();

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
