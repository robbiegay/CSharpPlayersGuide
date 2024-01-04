namespace CSharpPlayersGuide.Levels
{
    internal class Level44 : ILevel
    {
        public static async void Notes()
        {
            Utilities.PrintNotesTitle(44);
            Console.WriteLine(
"""
Trying to understand async/await, each version is me trying out a different mental model:

v1 notes:
Task.Run( ... code to run ...);
will kick off a new thread.

If the method returns void, then it kicks off and you dont wait.
Task or Task<T> means you wait
You have to await a method and can only call await in an async method

v2 notes:
async/await: can await a Task (ie another thread)
Task and Task<T>: run something on another thread
Can also run something on another thread with void to run but not await

v3 notes:
When you make a method 'async', the compiler adds some plumbing code that automatically returns
void, Task or Task<T>. 
You can only await Tasks
A Task is just something running on another thread, though I think you have to actually kick off that run.

v4 notes:
A task can run something on a new thread (though it doesn't have to. Here's how:

Task MyMethod()
{
    return Task.Run(() => /* do something */ );
}
- OR -
Task<int> MyMethod()
{
    return Task.Run(() => { return 5; } );
}

Now you can await either of those via:

async Task MyCallingMethod() // Mark your calling method as a Task if you want it awaited
{
    await MyMethod();
}

You can also call a task a return void. This means that you can still kick off a new thread,
but you cannot await it:

void MyMethod()
{
    Task.Run(() => { /* do something */ } );
}

async Task MyCallingMethod()
{
    MyMethod();
}

--------------------------------------------------------

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

        public static async Task AsynchronousRandomWords()
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

        public static async Task ManyRandomWords()
        {
            Utilities.PrintInColor("Enter words to kick off a random word generator!", 2);
            Utilities.PrintInColor("", 2);
            Utilities.PrintInColor("Type 'exit' to exit", 2);
            Utilities.PrintInColor("", 2);

            while (true)
            {
                Utilities.PrintInColor("Enter a word: ", 3);
                var word = Console.ReadLine();
                if (word == "exit") break;

                // So this works
                // FIXED: made this method Task and awaited it in Program
                //var t = new Thread(() => { var r = GenerateRandomWords(word); Console.WriteLine(r.Result.iterations); });
                //t.Start();
                //t.Join();

                GenerateRandomWords(word ?? "");
            }
        }

        private static void GenerateRandomWords(string word)
        {
            Task.Run(() =>
            {
                var start = DateTime.Now;

                string? randomWord = null;
                var iterations = 0;
                var rnd = new Random();

                do
                {
                    randomWord = null;

                    for (int i = 0; i < word.Length; i++)
                    {
                        randomWord += (char)('a' + rnd.Next(26));
                    }

                    iterations++;
                }
                while (randomWord != word);

                var end = DateTime.Now;
                var elapsed = end - start;

                var result = new Results(iterations, elapsed);

                Utilities.PrintInColor($"The word {word} was generated in {result.iterations} iterations over a period of {result.timeElapsed.TotalSeconds} seconds.", 10);
            });
        }

        private record Results(int iterations, TimeSpan timeElapsed);

        public static async Task TaskExperiments()
        {
            Console.WriteLine("""
                1: void -> kicks off but doesn't wait
                2: Task -> awaits but no return type
                3: Task<T> -> awaits with a return type
                """);
            var input = Console.ReadLine();

            if (input == "1")
            {
                Test1();
                Console.WriteLine("RUNS AFTER TEST 1");
            }
            else if (input == "2")
            {
                await Test2();
                Console.WriteLine("RUNS AFTER TEST 2");
            }
            else if (input == "3")
            {
                var value = await Test3();
                Console.WriteLine($"GOT THE VALUE: {value}");
            }
        }

        private static void Test1()
        {
            Task.Run(() =>
            {
                Console.WriteLine("Sleeping for 3 seconds...");
                Thread.Sleep(3000);
                Console.WriteLine("Test1: DONE!");
            });
        }

        private static Task Test2()
        {
            return Task.Run(() =>
            {
                Console.WriteLine("Sleeping for 3 seconds...");
                Thread.Sleep(3000);
                Console.WriteLine("Test2: DONE!");
            });
        }

        private static Task<int> Test3()
        {
            return Task.Run(() =>
            {
                var value = 5;
                Console.WriteLine("Sleeping for 3 seconds...");
                Thread.Sleep(3000);
                Console.WriteLine($"Test3: DONE! and returning {value}");
                return value;
            });
        }
    }
}
