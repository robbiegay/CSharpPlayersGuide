namespace CSharpPlayersGuide.Extensions
{
    internal static class RandomExtensions
    {  
        public static double NextDouble(this Random r, int maxValue)
        {
            return r.NextDouble() * maxValue;
        }

        public static string NextString(this Random r, params string[] input)
        {
            var numberOfChoices = input.Length;

            var index = r.NextInt64(numberOfChoices);

            return input[index];
        }

        public static bool CoinFlip(this Random r, double probabilityOfHeads = 0.5)
        {
            var toss = r.NextDouble();

            if (toss < probabilityOfHeads)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
