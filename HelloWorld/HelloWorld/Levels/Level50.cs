namespace CSharpPlayersGuide.Levels
{
    internal class Level50 : ILevel
    {
        public static void Notes()
        {
            Console.WriteLine(
"""
History of .NET

There was at first .NET Framework, but this was close source so they released Mono.
Then they released .NET Core and eventually dropped the Core, and now .NET is the 
prefered framework.

Layers:
1. Common: CIL (common intermediary language): basically a shared assembly lang. 
CLR (Common language runtime), the VM that C# runs on. This manages memory/GC, 
keeps memory usage safe (can't access memory you shouldn't and checks memory types),
SDK
2. Base Class Library: Standard library that solves everyday problems.
3. App Models:
    - Desktop Dev: UWP is the new framework.
    - Mobile: MAUI (cross-platform, new framework)
    - Web: ASP.NET, which includes MVC, Razor, and Blazor (runs WebAssembly directly
      in clients web browsers) for front end and other backend options.
    - Also popular for gamedev using engines like Unity.

Quiz:
1. MAUI seems exciting for mobile dev.
2. Winforms, UWP.
3. BCL (Base Class Library).
4. False
""");
        }
    }
}
