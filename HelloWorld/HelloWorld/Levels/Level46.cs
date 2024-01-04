namespace CSharpPlayersGuide.Levels
{
    internal class Level46 : ILevel
    {
        public static void Notes()
        {
            Console.WriteLine(
"""
Unsafe code allows you to manipulate memory addresses.
Use the unsafe keyword to declare sections of code as 'unsafe' and allow mem manipulation.

Pointers allow you to reference a specific address. C# borrows *, &, and -> from C++.
'fixed' can be used to pin managed references in place so that a pointer can reference them.
'stackalloc' allows you to define a local cariable array with data stored on the stack.
'sizeof' can tell you the size of an unmanged type.

C# manages memory for you but using 'unsafe' you can enter the world of 
unmanged code. Sometimes called native code.

int x;
unsafe
{
    // Some notes copied from the book:

    // Address-Of Operator. Gets the address of something and returns it.
    // This gets the address of 'x' and puts it in 'pointerToX'.
    int* pointerToX = &x;

    // Indirection Operator: Dereferences the pointer, giving you the object at
    // the location pointed to by a pointer. This puts a 3 in the memory location
    // pointerToX points at (the original 'x' variable).
    *pointerToX = 3;

    // Pointer Member Access Operator: allows access to members through a pointer.
    pointerToX->GetType();

    // Reference types are managed by GC. We have to make sure that 
    // GC doesn't move around what our pointers are referencing
    // so to point to a ref type, you must 'pin' it. This keeps it
    // in one memory location while the code in the fixed block runs.
    Point p = new Point();
    fixed (double* y = &p.X)
    {
        (*y)++;
    }
}

Quiz:
1. False, unsafe code is not inherently dangerous, you are just operating with the gaurd rails off.
2. The unsafe keyword.
3. The fixed keyword.
4. int*.
""");

            int x;
            unsafe
            {
                // Some notes copied from the book:

                // Address-Of Operator. Gets the address of something and returns it.
                // This gets the address of 'x' and puts it in 'pointerToX'.
                int* pointerToX = &x;

                // Indirection Operator: Dereferences the pointer, giving you the object at
                // the location pointed to by a pointer. This puts a 3 in the memory location
                // pointerToX points at (the original 'x' variable).
                *pointerToX = 3;

                // Pointer Member Access Operator: allows access to members through a pointer.
                pointerToX->GetType();

                // Reference types are managed by GC. We have to make sure that 
                // GC doesn't move around what our pointers are referencing
                // so to point to a ref type, you must 'pin' it. This keeps it
                // in one memory location while the code in the fixed block runs.
                Point p = new Point();
                fixed (double* y = &p.X)
                {
                    (*y)++;
                }
            }
        }

        public class Point
        {
            public double X;
            public double Y;
        }
    }
}
