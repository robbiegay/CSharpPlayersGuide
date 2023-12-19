using CSharpPlayersGuide.Common;
using Humanizer;

namespace CSharpPlayersGuide.Levels
{
    internal class Level48 : ILevel
    {
        public static void Notes()
        {
            Console.WriteLine(
"""
You can organize large code bases into seperate projects:
- Shared code library: DLLs, you add a dependency on library. Dependencies cannot be circular. Often named, MyProject.Common
- You can use Nuget to make or use shared code. Nuget is a package manager, basically DLLs and metadata like version numbers. You download a nupkg which is basically a zip with the DLL and metadata.

The internal modifier is useful when creating shared libraries. When you mark something as internal, you know you can safely change it. Public items might cause breaking changes.
""");
        }

        public static void TheColoredConsole()
        {
            var name = ColoredConsole.Prompt("What is your name?");
            ColoredConsole.WriteLine($"Hello, {name}!", ConsoleColor.Green);
            ColoredConsole.ResetColor();
        }

        public static void TheGreatHumanizer()
        {
            var hourOffsets = new double[] { 2.5, 30, 50, 1506 };

            foreach (var offset in hourOffsets)
            {
                var feastDate = DateTime.Now.AddHours(offset);

                // Humanize is an extension method from the Nuget package Humanizer.Core
                Console.WriteLine($"When is the feast? {feastDate.Humanize()}");
            }
        }
    }
}
