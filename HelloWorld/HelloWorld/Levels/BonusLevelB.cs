namespace CSharpPlayersGuide.Levels
{
    internal class BonusLevelB : ILevel
    {
        public static void Notes()
        {
            Console.WriteLine(
"""
Compiler Errors:
- The Error List shows errors, warnings, and messages
- Error: The compiler cannot turn this into working code, must be fixed.
- Warnings: The compiler can turn this into working code but it is suspicious. The compiler
            is nearly always right -- these should probably be fixed. There is a project 
            setting that lets you treat warnings like errors, if you fell like strictly
            enforcing this.
- Messages: Notable but not for sure bad. You could still fix them if you wanted to.
- Clicking on the error code in the Error List opens up online docs for that code.

Tips:
- If using code from the internet, understand it completely before using it. Ideally, 
  understand it well enough that we can write your own version and avoid copy/paste
  entierly!

Quiz:
1. True
2. Click the error code to read docs, look for quick actions, try undoing/commenting out
   recent changes to see when the error first appeared, look in other places as the problem
   code might not be on the line where the error actually appears.
""");
        }
    }
}
