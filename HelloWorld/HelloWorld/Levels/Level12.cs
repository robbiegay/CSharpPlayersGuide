namespace CSharpPlayersGuide.Levels
{
    internal class Level12
    {
        public static void Level12Notes()
        {
            // Collection initalizer syntax: { ...values... }
            // Can ommit the size and type if it is obvious:
            var scores = new[] { 50, 50, 55, 80, 90, 95, 100 };

            // Copy a range of values
            // [x..y] -> inclusive of x, exclusive of y
            var firstThreeScores = scores[0..3];
            var scoreOneToEnd = scores[1..]; // index 1 to end
            var scoresThreeToLast = scores[3..^0]; // ^x -> index from the end, last item is ^1

            var arrayOfIntArray = new[] { firstThreeScores, scoreOneToEnd, scoresThreeToLast };

            Console.WriteLine("Level 12 Notes:\n");

            foreach (var array in arrayOfIntArray)
            {
                foreach (var item in array)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();
            }

            // Jagged array -> each array within the array can be of a different length
            var jagged = new int[3][];
            jagged[0] = new[] { 1, 2, 3 };
            jagged[1] = new[] { 3, 4, 5, 6 };
            jagged[2] = new[] { 7 };

            // If each array within the array is of the same length,
            // then much easier to use a multi-dimensional or rectangular array
            // [x,y] -> x is the outter array size, y is the inner size
            // Can have as many dimensions as you want -> [,,,]
            int[,] multi = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            // Access via array[1,2]
            Console.WriteLine($"Accessing a multi-dimensional array via arr[x,y]: {multi[0,1]}");

            // Super multi array
            var soManyLevels = new bool[10,3,6,1];
            Console.WriteLine($"Accessing a multi-multi-multi dimensional array: {soManyLevels[5,0,2,0]}");
            Console.WriteLine($"Can use 'GetLength(depth)': {soManyLevels.GetLength(3)}");
        }

        public static void TheReplicatorOfDTo()
        {
            var array = new int[5];

            Console.WriteLine($"The Replicator of D'To needs you to enter {array.Length} numbers...\n");

            for (int i = 0; i < array.Length; i++)
            {
                // Replacing with Level 13 method:
                // Console.Write($"Enter number {i + 1}: ");
                // array[i] = Convert.ToInt32(Console.ReadLine());

                array[i] = Level13.AskForNumberInRange($"Enter number 0-100 for position {i + 1}: ", -1, 101);
            }

            var replicatedArray = new int[5];

            Console.WriteLine("\nThe Replicator of D'To is replicating...\n");

            for (int i = 0; i < array.Length; i++)
            {
                replicatedArray[i] = array[i];
            }

            for (int i = 0; i < array.Length; i++)
            {
                Utilities.PrintInColor($"{nameof(array)} -> {array[i], -4} || {replicatedArray[i], 4} <- {nameof(replicatedArray)}");
            }
        }

        public static void TheLawsOfFreach()
        {
            Console.WriteLine("Rewrite the copied code using foreach loops...\n");

            // Find the smallest:
            int[] smallestArray = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 }; 
            int currentSmallest = int.MaxValue; // Start higher than anything in the array.
            foreach (var item in smallestArray)
            {     
                if (item < currentSmallest)         
                    currentSmallest = item; 
            } 
            
            Console.WriteLine(currentSmallest);

            // Find the average
            int[] averageArray = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 }; 
            int total = 0; 
            foreach (var item in averageArray) 
                total += item; 
            
            float average = (float)total / averageArray.Length; 
            
            Console.WriteLine(average);
        }
    }
}
