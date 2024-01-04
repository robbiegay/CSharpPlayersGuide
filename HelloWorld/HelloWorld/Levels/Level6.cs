namespace CSharpPlayersGuide.Levels
{
    internal class Level6
    {
        // Notes: built in/primitive types
        /*
        byte w; //      0 - 256 (size: 1 byte)
        sbyte ww; // -128 - 127

        short x; //  -32k~ - 32k~
        int y; // -2 billion~ - 2 billion (4 bytes)
        long z; // -large number - large number (8 bytes)
        ushort xx; // 0 - 65535 (2 bytes)
        uint yy = 0xFF4; // hex literal 
        ulong zz = 0b1011; // binary literal

        char ch = '\u0061'; // 2 bytes -- \uxxxx = unicode encoding

        byte test = 257 - 2;

        double sci = 43e22; // scientifici notation
        */

        // float, doube, decimal (money)
        // computer will convert anything smaller than an int to int to do math and convert it back so the smaller values aren't really that useful

        public static void TheVariableShop()
        {
            // each of the 14 variable types
            byte b = 255;
            sbyte sb = -12;
            short s = 32_000;
            ushort us = 65000;
            int i = -2_000_000;
            uint ui = 4_000_000;
            long l = 0xFFFFFFFF;
            ulong ul = 0b00000000_00000000_00000000_00000000_00000000_00000000_00000000_00000001;

            char c = '\u0123';
            string str = "hi!!";

            float f = 4.0f;
            double d = 84.3e23;
            decimal dec = 44.42m;

            bool isABool = true;

            Console.WriteLine($"byte: {b}");
            Console.WriteLine($"sbyte: {sb}");
            Console.WriteLine($"short: {s}");
            Console.WriteLine($"ushort: {us}");
            Console.WriteLine($"int: {i}");
            Console.WriteLine($"uint: {ui}");
            Console.WriteLine($"long: {l}");
            Console.WriteLine($"ulong: {ul}");

            Console.WriteLine($"char: {c}");
            Console.WriteLine($"string: {str}");

            Console.WriteLine($"float: {f}");
            Console.WriteLine($"double: {d}");
            Console.WriteLine($"decimal: {dec}");

            Console.WriteLine($"isABool: {isABool}");
        }

        public static void TheVariableShopReturns()
        {
            // each of the 14 variable types
            byte b = 255;
            sbyte sb = -12;
            short s = 32_000;
            ushort us = 65000;
            int i = -2_000_000;
            uint ui = 4_000_000;
            long l = 0xFFFFFFFF;
            ulong ul = 0b00000000_00000000_00000000_00000000_00000000_00000000_00000000_00000001;

            char c = '\u0123';
            string str = "hi!!";

            float f = 4.0f;
            double d = 84.3e23;
            decimal dec = 44.42m;

            bool isAllOfThem = true;

            b = byte.MinValue;
            sb = sbyte.MinValue;
            s = short.MinValue;
            us = ushort.MinValue;
            i = int.MaxValue;
            ui = uint.MaxValue;
            l = long.MaxValue;
            ul = ulong.MaxValue;
            c = '~';
            str = "A new value!";
            f = float.NegativeInfinity;
            d = double.NaN;
            dec = 1_000.99m;
            bool isABool = false;

            Console.WriteLine($"byte: {b}");
            Console.WriteLine($"sbyte: {sb}");
            Console.WriteLine($"short: {s}");
            Console.WriteLine($"ushort: {us}");
            Console.WriteLine($"int: {i}");
            Console.WriteLine($"uint: {ui}");
            Console.WriteLine($"long: {l}");
            Console.WriteLine($"ulong: {ul}");

            Console.WriteLine($"char: {c}");
            Console.WriteLine($"string: {str}");

            Console.WriteLine($"float: {f}");
            Console.WriteLine($"double: {d}");
            Console.WriteLine($"decimal: {dec}");

            Console.WriteLine($"isABool: {isABool}");
        }

        public static void Notes()
        {
            Console.WriteLine(@"Reference material: https://csharpplayersguide.com/articles/operators-table" + "\n\n");

            //
            // Range structure
            //

            Console.WriteLine("Using the range (..) structure:");

            Console.ForegroundColor = ConsoleColor.Green;
            var code = """
var marks = new int[] { 23, 45, 67, 88, 99, 56, 27, 67, 89, 90, 39 };

// x..y -> inclusive of x, exclusive of y
var rangeOfMarks = marks[2..5]; 
Console.Write("Marks 2-4: ");
foreach (var mark in rangeOfMarks)
    Console.Write($" {mark} ");
""";
            Console.WriteLine(code);
            Console.ForegroundColor = ConsoleColor.White;

            var marks = new int[] { 23, 45, 67, 88, 99, 56, 27, 67, 89, 90, 39 };

            // x..y -> inclusive of x, exclusive of y
            var rangeOfMarks = marks[2..5];
            Console.Write("Marks 2-4: ");
            foreach (var mark in rangeOfMarks)
                Console.Write($" {mark} ");

            Console.Write("\n\n");

            //
            // checked/unchecked
            //

            Console.WriteLine("\n\nChecked/unchecked keywords:");

            Console.ForegroundColor = ConsoleColor.Green;
            code = """
uint maxValue = uint.MaxValue;

unchecked
{
    // unchecked: overflows without exception
    // output: 0
    Console.WriteLine(maxValue + 1);  // output: 0
}

try
{
    checked
    {
        // checked: overflows and throws OverflowException
        Console.WriteLine(maxValue + 1);
    }
}
catch (OverflowException e)
{
    Console.WriteLine(e.Message);
}
""";
            Console.WriteLine(code);
            Console.ForegroundColor = ConsoleColor.White;

            uint maxValue = uint.MaxValue;

            unchecked
            {
                // unchecked: overflows without exception
                // output: 0
                Console.WriteLine(maxValue + 1);  // output: 0
            }

            try
            {
                checked
                {
                    // checked: overflows and throws OverflowException
                    Console.WriteLine(maxValue + 1);
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }

            //
            // Unsafe keyword
            //

            Console.WriteLine("\n\nUnsafe keyword:\nHad to add <AllowUnsafeBlocks>true</AllowUnsafeBlocks> to .csproj");

            Console.ForegroundColor = ConsoleColor.Green;
            code = """
unsafe 
{
    int test = 4;
    int* address = &test; // reference the pointer address
    Console.WriteLine($"Address cast to int: {(int)address}");
    Console.WriteLine($"Address via pointer: {*address}");
}
""";
            Console.WriteLine(code);
            Console.ForegroundColor = ConsoleColor.White;

            unsafe
            {
                int test = 4;
                int* address = &test; // reference the pointer address
                Console.WriteLine($"Address cast to int: {(int)address}");
                Console.WriteLine($"Address via pointer: {*address}");
            }
        }

        // quiz: false / byte, short, int, long / false / uint / float, double (4.0f), decimal (4.0m) / double (decimal trades percision for size, i think) / decimal / string / boolean (bool)
    }
}
