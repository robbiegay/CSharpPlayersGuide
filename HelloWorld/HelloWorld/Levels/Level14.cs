namespace CSharpPlayersGuide.Levels
{
    internal class Level14
    {
        // Notes:
        // 
        // Stack: When a method is called, enough memory for its local variables
        //        and parameters is created (its stack frame). When you return from
        //        the function, that stack allocation gets recycled
        // Heap: When data is needed, a free spot os found on the heap. A reference
        //       is used to keep track of objects on the heap.
        //
        // Each time you call a function, a new stack is placed on the call stack.
        // This stack has enough memory to hold the parameters and local variables of
        // the method. Anything outside the stack is garbage. It may have values because
        // deallocated memory is not just automatically erased, but rather marked as ready
        // for reuse. This is why you cannot use a variable until you initalize it:
        //     - Because the variable was given a memory address on the stack already, and 
        //       until you initalize it, it would likely have some garbage values in it.
        //
        // The stack keeps track of the line location of the program below it, so that when 
        // it returns, it can resume execution at its previous spot.
        //
        // Cleanup on the stack is easy because when we return out of a stack frame, we deallocated
        // everything in that frame.
        //
        // Call stack frames get iniatalized with space for variables, but no data there (initalization 
        // must happen in the function. Passing in parameters sets the values when the stack frame is 
        // created. So passing in variables is really passing variables into the frame.
        //
        // Returning values out of a frame get a little bit messier because of optimizations behind
        // the scenes. Rather than giving the return value a variable on the stack and allowing the 
        // frame below it to temporariliy access it, the return sidesteps the stack entierly, and passes
        // its value to the calling line of code. This is why only one item can be returned from a method.
        //
        // The stack works best if the frame can be a finite size. Reference types (arrays, strings, etc)
        // complicate this. To fix this, we just keep a fixed size reference (pointer) to the location 
        // on the heap.
        //
        // This is because when we create the frame, the values are uninitalized, so we don't know if out
        // string with be 5 chars or 5,000. So we keep a fixed size pointer. In some languages, this is just
        // a memory address. In C#, it is a bit more complicated, but we can think of it as a memory address.
        // References are 8 bytes on a 64-bit computer and 4 bytes on a 32-bit computer. This is because on 
        // those architectures, that is the size of memory, so a reference is equal to the memory size.
        //
        // integers, floating point numbers, chars, and bools all are value types
        // strings and arrays are reference types
        // 
        // equality: value types are equal if the bits are the same
        // ex. a (8) == b (8)
        // Reference semantics have to be pointed to the same address to be equal (you are sort of 
        // checking address equality)
        // ex. array1 == array2
        // true if: array1 and array2 are pointing to the same reference
        // false if: array1 = new [] {1} and array2 = new [] {1}
        // even though in the second example the values in the array are equal, the comparison will be false
        //
        // strings are reference types but have value semantics
        //
        // When manually managing memory, if you forget to dereference items, this can cause a memory leak.
        // Long running programs with memory leaks will slow down and eventually crash the system as it eats
        // up all of the memory.
        //
        // Conversely, if you give up a reference too early, the heap location will be freed up but your  
        // program will still reference that location later on. If that happenes then you have a situation
        // where that memory address is being used and modified by something else but we still use it, causing
        // all sorts of wild bugs. This is called a dangling reference or dangling pointer.
        //
        // Because manually managing memory can be so challenging, C# takes this responsability from the 
        // programmer and assigns it to the runtime. This is called: automatic memory managment or
        // grabage collection
        //
        // Garbage collection periodically wakes up and scans the program -- starting with a set of root 
        // objects including the first item in the call stack and looks for anything that can no longer
        // be reached. It then returns that to the heap.
        // Downsides include: less fine grained control. Not knowning or controlling when memory will
        // be cleaned up (ussually several times per second), and having a 'stop the world' process like
        // GC that has to stop the entier program to run. Ussually this is micro or even nano seconds but
        // could take longer.
        // millisecond = 1/1,000 of second, micro = 1,000,000/second, nano = 1/1,000,000 second
        //
        // Garbage Collector is typically well optimized and handles memory on the heap so that programmers
        // don't have to.
        // The stack manages its own memory
        //
        // Quiz:
        // 1. False -- you can only access the current frame of the call stack
        // 2. True -- the stack keeps track of your local variables and parameters
        // 3. True -- Sort of true. Value types are placed on the stack but if a reference type
        //             holds a value type then I guess it is on the heap
        // 4. False -- ussually value types are placed on the stack
        // 5. True -- reference types are always placed on the heap (with a reference to them on the stack)
        // 6. False -- GC only cleans up unused memory on the heap
        // 7. True -- if two arrays reference the same address, then modifying on will modify the other
        // 8. False -- modifying one int will never affect another
        // /

        /*void Test(bool isTrue)
        {
            int x; // uninitialized so could be a random value like 76
            object obj = null;

            if (isTrue)
            {
                x = 1;
            }

            Console.WriteLine(x); // compiler won't let you use a random (uninitalized) value
            Console.WriteLine(obj);
        }*/

        public static void Level14Notes()
        {
            Console.WriteLine("Create two values of types: int, int[], string\n");
            int i1;
            int i2;

            int[] a1;
            int[] a2;

            string s1;
            string s2;

            Console.WriteLine("Initialize first values\n");
            i1 = 2;
            a1 = new[] { 1, 2 };
            s1 = "Hello";

            Console.WriteLine("Set second values = first values\n");
            i2 = i1;
            a2 = a1;
            s2 = s1;

            Console.WriteLine("Change second value values\n");
            i2 = 4;
            Console.WriteLine($"Are the two ints different? {i1}, {i2}");
            a2[0] = 1000;
            Console.WriteLine($"Are the first index of the arrays the same? {a1[0]}, {a2[0]}");
            s2 = "World";
            Console.WriteLine($"Are the two strings different? {s1}, {s2}");
            Console.WriteLine("Strings are reference types but have value semantics, so the second value changed.\n");

            Console.WriteLine("Testing value and reference semantic equality\n");

            i2 = 2;
            Console.WriteLine($"ints equal (currently both set to: {i1}, {i2}): {i1 == i2}");
            Console.WriteLine($"arrays equal (currently reference same location -- values: {a1[0]}, {a1[1]} -- {a2[0]}, {a2[1]}): {a1 == a2}");
            s2 = s1;
            Console.WriteLine($"strings equal (currently set to: {s1}, {s2}): {s1 == s2}");
            a2 = new[] { 1000, 2 };
            Console.WriteLine($"arrays values are equal but different addresses (values: {a1[0]}, {a1[1]} -- {a2[0]}, {a2[1]}): {a1 == a2}");
            s2 = "Not the same lol";
            Console.WriteLine($"strings not equal (currently set to: {s1}, {s2}): {s1 == s2}");
        }
    }
}
