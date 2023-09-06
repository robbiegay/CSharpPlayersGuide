namespace CSharpPlayersGuide.Levels
{
    internal class Level44 : ILevel
    {
        public static void Notes()
        {
            Utilities.PrintNotesTitle(44);
            Console.WriteLine(
"""



Quiz:
1. async
2. await
3. Task (void return), Task<T> (T return), void (void return and you don't need to know when it finishes)
4. False
5. a: Task, b: void, c: Task<T>


""");

            Console.WriteLine("Run with a delay:");
            int result = AddOnEuropa(2, 3);
            Console.WriteLine(result);
            
            Console.WriteLine("Now run on a new thread:");
            int result2 = 0; 
            Thread thread = new Thread(() => result2 = AddOnEuropa(2, 3));
            Utilities.PrintInColor("Start the adding thread...", 5);
            thread.Start();
            Thread.Sleep(800);
            Utilities.PrintInColor("Do other work here...", 3);
            Thread.Sleep(800);
            Utilities.PrintInColor("Join adding thread...", 5);
            thread.Join();
            Console.WriteLine(result2);

            Console.WriteLine("Using a callback:");
            AddOnEuropa(2, 3, result => Console.WriteLine(result));
        }

        private static int AddOnEuropa(int a, int b)
        {
            var amount = 500;

            // Simulate light delay. It should be far longer!
            for (int i = 0; i < 3000; i += amount)
            {
                Thread.Sleep(amount);
                Utilities.PrintInColor($"Sleeping for {i}...", 5);
            }
            return a + b;
        }

        private static void AddOnEuropa(int a, int b, Action<int> callback)
        {
            Thread thread = new Thread(() => {
                var amount = 500;

                // Simulate light delay. It should be far longer!
                for (int i = 0; i < 3000; i += amount)
                {
                    Thread.Sleep(amount);
                    Utilities.PrintInColor($"Sleeping for {i}...", 5);
                }

                int result = a + b; 
                callback(result);
            }); 
            
            thread.Start();
        }

        public static void AsynchronousRandomWords()
        {
            throw new NotImplementedException();
        }

        //private async Task<int> AsyncRandomlyRecreate(string word)
        //{
        //    //return Task.Run(async () => { await RandomlyRecreate(word); });
        //}

        private int RandomlyRecreate(string word)
        {
            var rnd = new Random();
            var length = word.Length;
            string? randomWord = null;
            var attempts = 0;

            while (randomWord is null && word != randomWord)
            {
                randomWord = null;

                for (int i = 0; i < length; i++)
                {
                    randomWord += (char)('a' + rnd.Next(26));
                }

                attempts++;
            }

            return attempts;
        }

        public static void ManyRandomWords()
        {
            throw new NotImplementedException();
        }
    }
}
