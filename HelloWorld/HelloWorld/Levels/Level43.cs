using System.Diagnostics;

namespace CSharpPlayersGuide.Levels
{
    internal class Level43 : ILevel
    {
        public static void Notes()
        {
            Utilities.PrintNotesTitle(43);

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
