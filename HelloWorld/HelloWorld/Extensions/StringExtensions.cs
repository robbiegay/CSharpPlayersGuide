namespace CSharpPlayersGuide.Extensions
{
    internal static class StringExtensions
    {
        public static string ChangeToRob(this string text, bool makeRobbie = false)
        {
            if (makeRobbie)
                return "Robbie";

            return "Rob";
        }
    }
}
