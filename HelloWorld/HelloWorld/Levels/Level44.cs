namespace CSharpPlayersGuide.Levels
{
    internal class Level44 : ILevel
    {
        public static async void Notes()
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
            Console.WriteLine("Enter 'y' to run some experiments:");
            if (Console.ReadKey().KeyChar == 'y')
            {
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
                AddOnEuropa(2, 3, result3 => Console.WriteLine(result3));
                AddOnEuropa(2, 3, result3 => { result3 = result3 * result3 * result3; Utilities.PrintInColor($"Some wild results: {result3}", 15); });
                
                var t = AddOnEuropaTask(2, 3);
                // Wait() and .Result both cause the thread to wait
                //t.Wait(); // Causes the current thread to wait
                Console.WriteLine("test1");
                Console.WriteLine(t.Result);
                Console.WriteLine("test2");
            }

            var result4 = await AddOnEuropaTask(1, 2); // Without an 'await', it will return result4 before a value is even set
            Console.WriteLine("testing...");
            Console.WriteLine(result4);
            Console.WriteLine("More testing...");
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

        private static Task<int> AddOnEuropaTask(int a, int b)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(3000);
                return a + b;
            });
        }

        public static async void AsynchronousRandomWords()
        {
            string? word = null;

            while (word is null)
            {
                Utilities.PrintInColor("Enter a word:", 2);
                word = Console.ReadLine();
            }

            var before = DateTime.Now;
            var iterations = await RandomlyRecreateAsync(word);
            var after = DateTime.Now;

            Console.WriteLine();

            Utilities.PrintInColor($"It took {iterations} iterations to generate your word {word} randomly!", 2);
            Utilities.PrintInColor($"The total time elapsed was {(after - before).TotalSeconds} seconds!", 2);
        }

        // Schedules a new thread to run your task
        // If you await this method, it will cause main thread to 'join' the new thread.
        private static Task<int> RandomlyRecreateAsync(string word)
        {
            return Task.Run(() => 
            { 
                return RandomlyRecreate(word);
            });
        }

        private static int RandomlyRecreate(string word)
        {
            Console.WriteLine("Enter 'r' for randomly, else, password-cracker style:");
            var randomly = Console.ReadLine();

            var attempts = 0;
            var rnd = new Random();

            if (randomly == "r")
            {
                var length = word.Length;
                string? randomWord = null;

                while (randomWord is null || word != randomWord)
                {
                    randomWord = null;

                    for (int i = 0; i < length; i++)
                    {
                        randomWord += (char)('a' + rnd.Next(26));
                    }

                    attempts++;

                    Utilities.PrintInColor(randomWord, word != randomWord ? 5 : 6);
                }
            }
            else
            {
                var i = 0;
                string partialWord = "";

                do
                {
                    Utilities.PrintInColor(partialWord, 6, true);

                    var randomChar = (char)(rnd.Next(32, 128));

                    if (word[i] == randomChar)
                    {
                        i++;
                        partialWord += randomChar;
                        Utilities.PrintInColor(randomChar.ToString(), 6, true);
                    }
                    else
                    {
                        Utilities.PrintInColor(randomChar.ToString(), 5, true);
                    }

                    var remainingLegth = word.Length - partialWord.Length;
                    Utilities.PrintInColor(new string('a', remainingLegth), 5, true);

                    Console.WriteLine();

                    attempts++;
                }
                while (word != partialWord);
            }

            return attempts;
        }

        public static void ManyRandomWords()
        {
            throw new NotImplementedException();
        }
    }
}
