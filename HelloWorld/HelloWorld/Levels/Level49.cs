namespace CSharpPlayersGuide.Levels
{
    internal class Level49 : ILevel
    {
        public static void Notes()
        {
            Console.WriteLine(
"""
The Compiler in Depth

binary code: 01100101
assembly: li $t0 -> human readable but still mpas directly to machine code

binary will run different things on different archetectures and operating systems.
Common archs: x86 (32-bit OS), x64 (x86-64, an extension to 64 bit) and ARM (mobile).
Operating Systems sit on top of the hardware and control resources like the CPU. Windows, Mac, Linux.

A lot of compilers use a virtual machine. This sets up an abstraction layer
where the compiler just uses instruction sets known by the VM, and the VM then
has a job to translate these virtual instructions to the matching hardware and OS.
This makes it so that the VM is the only on concerned with hardware concerns. This 
means that you can write Programming languages more easily because they all can 
share the VM code. Optimizations to VM can then cascade to all langs that use it. 

C# often uses JIT (just in time compelation), which means that the VM code is only
compiled when actually needed. Another option is Ahead of Time (AOT) which compiles 
all at once.

Quiz:
1. Two most popular instruction set archs? x86/x64 and ARM
2. False
3. C#'s VM: Common Language Runtime (CLR)
4. F#, Python
5. Common Intermediary Language (CIL or IL)
""");
        }
    }
}
