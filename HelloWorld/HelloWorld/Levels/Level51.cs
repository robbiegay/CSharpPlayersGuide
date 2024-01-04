namespace CSharpPlayersGuide.Levels
{
    internal class Level51 : ILevel
    {
        public static void Notes()
        {
            Console.WriteLine(
"""
Publishing:

Click Publish and save a new profile. Rename it to something useful. If you make 
it self-contained then you don't need to have .NET installed on the target machine.
You can also set it to trim files. When doing self-contained, you will need to 
target a specific architecture (runtime). But then you can ship that file and run 
it! For example, I built one targeting osx-x64 and ran it on my Mac. I had to run
the following command to change the run type: chmod +x ./MyProgram, and then I had
to try running it, and then go to: Settings > Security > General and follow the 
prompt to allow an app from an unknown developer to run.

You have 2 default profiles: Debug defines the DEBUG symbol and allows for 
debugging. Release is faster.
""");
        }
    }
}
