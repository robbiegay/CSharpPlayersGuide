namespace CSharpPlayersGuide.Levels
{
    internal class BonusLevelA : ILevel
    {
        public static void Notes()
        {
            //var x; // error

            var y = 1; // warning
            
            var z = new List<int> { 1 }; // suggestion

            Console.WriteLine(
"""
This section covers Visual Studio

Scrollbar:
- Minimap of the code
- Left shows changes: 
    - green outline = unsaved changes, filled in = saved
    - red outline = deleted, filled in = saved
    - blue stripes = modified, bolded = saved
    - Staged changes are not shown
- Left, but to the right of changes: errors, warnings, suggestions
    - Red: error
    - Green: warning
    - Gray: Suggestion
- Vertical bar across is cursor position
- Box = window view

Screwdriver icon is refactoring options. VS is not claiming that this is an improvement,
just showing it as an option.

Properties window: When you have an item selected in Solution Explorer, gives details.
Windows > Reset Layout: resets to default layout.
Tools > Options: customize VS.
Windows: Shows the many windows available to you.

Shortcuts:
alt + left-arrow/right-arrow = back and forward buttons
ctrl + space = open intellisense (esc to exit)

Quiz:
1. IntelliSense
2. Quick Actions
3. Solution Explorer
4. Error List
""");
        }
    }
}
