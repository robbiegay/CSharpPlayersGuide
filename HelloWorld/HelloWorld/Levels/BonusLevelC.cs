namespace CSharpPlayersGuide.Levels
{
    internal class BonusLevelC : ILevel
    {
        public static void Notes()
        {
            Console.WriteLine(
"""
Debugging:
- Locals: shows local variables. You can ussually set new values.
- Call Stack: Can click through call stack to go to execution pauses.
- Watch: Can type something like "max > min" and that expression will be evaluated
         as you step through code.
- Immediate Window: Can run code, including local variables.

Tips:
- Step over and into are the same except that step into will enter a method call.
- Step out: runs until you exit the current method.
- Run to cursor: right click and select this to run to the current line of code.
- Set next statement: causes code to jump from current line to selected line without
                      running any of the code in between. Scary but also useful if you
                      need to skip a section for debugging.

- Hot reload: Can click to do reload on demand, or select "on file save" to reload with 
              each save.
- Edit and Continue: If you are stopped at a breakpoint, make a change and save, when you
                     continue, the new version will be used.

    - Note: Some edits known as "rude" edits cannot be hot reloaded or edit and continued.

- Breakpoint actions: Right click on a breakpoint and you can set actions such as logging
                      a message to output and not stopping execution.
- Breakpoint conditions: Right click a breakpoint and set conditions that you want it to hit.

Quiz:
1. True
2. True
3. True
""");
            // Some example code from the book:
            Console.Write("Enter a number: ");
            double number = Convert.ToDouble(Console.ReadLine());
            double clampedNumber = Clamp(number, 0, 10);
            Console.WriteLine($"Clamped: {clampedNumber}");

            Utilities.PrintInColor("First book club meeting was 2/2/23, Book finished: 12/20/23", 14);
        }

        static double Clamp(double value, double min, double max) // Also see Math.Clamp.
        {
            if (value < min) return min;
            if (value > max) return max;

            if (true)
            {
                Utilities.PrintInColor("You can skip this line via 'set next statement", 1);
            }

            return value;
        }
    }
}
