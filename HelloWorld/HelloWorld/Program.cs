using System.Threading.Tasks;

// See https://aka.ms/new-console-template for more information
// Lets users select which exercise to run:
var shouldExit = false;

while (!shouldExit) 
{
    Console.Title = "C# Player's Guide: chapters 2-9";

    Console.WriteLine("Press 'e' to exit...\n\nEnter a value to run a program:");
    Console.WriteLine("\t1: HelloWorld");
    Console.WriteLine("\t2: WhatComesNext");
    Console.WriteLine("\t3: TheMakingsOfAProgrammer");
    Console.WriteLine("\t4: ConsolasAndTelim");
    Console.WriteLine("\t5: TheThingNamer3000");
    Console.WriteLine("\t6: TheVariableShop");
    Console.WriteLine("\t7: TheVariableShopReturns");
    Console.WriteLine("\t8: Chapter6Notes");
    Console.WriteLine("\t9: TheTriangleFarmer");
    Console.WriteLine("\t10: TheFourSistersAndTheDuckbear");
    Console.WriteLine("\t11: TheDominionOfKings");
    Console.WriteLine("\t12: ColorsAndSounds");
    Console.WriteLine("\t13: TheDefenseOfConsolas");
    Console.WriteLine("\t14: RepairingTheClocktower");
    Console.WriteLine("\t15: Watchtower");

    var input = Console.ReadLine();
    Console.Clear();

    switch (input)
    {
        case "e":
        {
            shouldExit = true;
            break;
        }
        case "1":
        {
            HelloWorld();
            break;
        }
        case "2":
        {
            WhatComesNext();
            break;
        }
        case "3":
        {
            TheMakingsOfAProgrammer();
            break;
        }
        case "4":
        {
            ConsolasAndTelim();
            break;
        }
        case "5":
        {
            TheThingNamer3000();
            break;
        }
        case "6":
        {
            TheVariableShop();
            break;
        }
        case "7":
        {
            TheVariableShopReturns();
            break;
        }
        case "8":
        {
            Chapter6Notes();
            break;
        }
        case "9":
        {
            TheTriangleFarmer();
            break;
        }
        case "10":
        {
            TheFourSistersAndTheDuckbear();
            break;
        }
        case "11":
        {
            TheDominionOfKings();
            break;
        }
        case "12":
        {
            ColorsAndSounds();
            break;
        }
        case "13":
        {
            TheDefenseOfConsolas();
            break;
        }
        case "14":
        {
            RepairingTheClocktower();
            break;
        }
        case "15":
        {
            Watchtower();
            break;
        }
    }

    if (input != "e")
    {
        Console.WriteLine($"\nPress any key to run again...\n");
        Console.ReadKey(true);
        Console.Clear();
    }
}


//
// Level 3
//
void HelloWorld()
{
    Console.WriteLine("Hello, world!");
}

void WhatComesNext()
{
    Console.WriteLine("Say something other than 'Hello, world!'");
}

void TheMakingsOfAProgrammer()
{
    Console.WriteLine("Hello! I am in a C# RPG game"); // string literal
    Console.WriteLine("And I need a few statements"); // string literal
    Console.WriteLine("2 more after this"); // string literal
    Console.WriteLine("one more..."); // string literal
    Console.WriteLine("done!"); // string literal
}

// . = member access operator
// code map: Base Class Library (BCL) -> system (namespace) -> Console (class) -> WriteLine (method)
// BCL also includes things like Convert and Math classes

void ConsolasAndTelim()
{
    Console.WriteLine("Bread is ready.\nWho is the bread ready for?");
    string name = Console.ReadLine() ?? "default"; // compiler warning (could be an issue) vs a compiler error
    Console.WriteLine($"Notes: {name} got bread.");
}

// build configs -> release has code optimization turns on that will do things like remove unused variables. Good for releases but can make debugging harder



//
// Level 4
//

void TheThingNamer3000()
{
    Console.WriteLine("What kind of thing are we talking about?");
    string item = Console.ReadLine() ?? ""; // item
    Console.WriteLine("How would you describe it? Big? Azure? Tattered?");
    string adj = Console.ReadLine() ?? ""; /* adjective */
    string ofDoom = "of Doom";
    string version = "3000";
    Console.WriteLine($"The {adj} {item} of {ofDoom} {version}!");
}


// 
// Level 5
// 

// muli value initilization and assignment
/*int a, b, c = 10;
a = b = c = 7;
Console.WriteLine(a + b + c);*/
// quiz: name, type value / true / no / answer, value1, delete_me, PI



// 
// Level 6
//

// built in / primitive types
/*byte w; //      0 - 256 (size: 1 byte)
sbyte ww; // -128 - 127

short x; //  -32k~ - 32k~
int y; // -2 billion~ - 2 billion (4 bytes)
long z; // -large number - large number (8 bytes)
ushort xx; // 0 - 65535 (2 bytes)
uint yy = 0xFF4; // hex literal 
ulong zz = 0b1011; // binary literal

char yeah = '\u0061'; // 2 bytes? ascii or unicode -> \uxxxx = unicode

byte test = 257 - 2;

double sci = 43e22; // scientifici notation*/

// float, doube, decimal (money)
// computer will convert anything smaller than an int to int to do math and convert it back so the smaller values aren't really that useful

void TheVariableShop()
{
    // each of 14 variable types
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

    Console.WriteLine($"isAllOfThem: {isAllOfThem}");
}

void TheVariableShopReturns()
{
    // each of 14 variable types
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
    isAllOfThem = false;

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

    Console.WriteLine($"isAllOfThem: {isAllOfThem}");
}

void Chapter6Notes()
{
    Console.WriteLine("Using the range (..) operator:");
    int[] marks = new int[] {23, 45, 67, 88, 99,
                            56, 27, 67, 89, 90, 39};

    // range struct:
    var a3 = marks[2..4];
    Console.Write("\nMarks List 3: ");
    foreach (var st_3 in a3)
        Console.Write($" {st_3} ");
    Console.Write("\n");

    Console.WriteLine("Using checked and unchecked to either check for (and throw an error) if there is overflow, or to not check (unchecked)");
    uint a = uint.MaxValue;

    unchecked
    {
        Console.WriteLine(a + 1);  // output: 0
    }

    try
    {
        checked
        {
            Console.WriteLine(a + 1);
        }
    }
    catch (OverflowException e)
    {
        Console.WriteLine(e.Message);  // output: Arithmetic operation resulted in an overflow.
    }

    Console.WriteLine(@"cool reference material: https://csharpplayersguide.com/articles/operators-table");

    Console.WriteLine("Using unsafe to allow pointers.\nHad to add <AllowUnsafeBlocks>true</AllowUnsafeBlocks> to .csproj");
    unsafe 
    {
        int test = 4;
        int* address = &test;
        Console.WriteLine($"Address cast to int: {(int)address}");
        Console.WriteLine($"Address via *: {*address}");
    }
}

// quiz: false / byte, short, int, long / false / uint / float, double (4.0f), decimal (4.0m) / double (decimal trades percision for size, i think) / decimal / string / boolean (bool)



//
// Level 7
//

void TheTriangleFarmer()
{
    // Compute area of triangle
    Console.WriteLine("Calculate the area of a triange...");
    Console.WriteLine("Enter a base length:");
    double baseValue;
    double.TryParse(Console.ReadLine(), out baseValue);
    double height;
    Console.WriteLine("Enter a height:");
    double.TryParse(Console.ReadLine(), out height);
    double area = baseValue * height / 2.0;
    Console.WriteLine($"{area} = {baseValue} * {height} / 2");
}

/*int testInt = short.MinValue;
Console.WriteLine(testInt);
Console.WriteLine(double.NegativeInfinity);
Console.WriteLine(double.NaN);
Console.WriteLine(8.0 / 0); // floating point division by zero assumes that you are actually dividing by an incredibly small (infinitesmal) but non-zero number
Console.WriteLine(-8.0 / 0);
Console.WriteLine(0.0 / 0); // 0.0 / 0.0 = NaN

int aaa = -1;
Console.WriteLine(+aaa);
aaa = -aaa;
Console.WriteLine(aaa);
aaa = -aaa;
Console.WriteLine(aaa);*/

void TheFourSistersAndTheDuckbear()
{
    Console.WriteLine("Enter the number of chocolate eggs laid today:");
    int eggs;
    int.TryParse(Console.ReadLine(), out eggs);
    Console.WriteLine($"Total eggs: {eggs}");
    Console.WriteLine($"Each of the 4 sisters will recieve {eggs / 4} eggs");
    Console.WriteLine($"Duckbear will recieve {eggs % 4} eggs");
}

void TheDominionOfKings()
{
    var kings = new string[3] { "Melik", "Casik", "Balik" };
    for (int i = 0; i < 3; i++)
    {
        Console.WriteLine($"Enter the number of estates for {kings[i]}:");
        int estates;
        int.TryParse(Console.ReadLine(), out estates);
        Console.WriteLine($"Enter the number of duchies for {kings[i]}:");
        int duchies;
        int.TryParse(Console.ReadLine(), out duchies);
        Console.WriteLine($"Enter the number of provinces for {kings[i]}:");
        int provinces;
        int.TryParse(Console.ReadLine(), out provinces);
        Console.WriteLine($"{kings[i]} has the following points:");
        Console.WriteLine($"estates: {estates} x 1 point = {estates *= 1}");
        Console.WriteLine($"duchyes: {duchies} x 3 points = {duchies *= 3}");
        Console.WriteLine($"provinces: {provinces} x 6 points = {provinces *= 6}");
        Console.WriteLine($"Total = {estates + duchies + provinces}");
    }
}

/*byte a = byte.MaxValue;
byte b = 4;
byte result = (byte)(a + b); // no addition defined for shorts so there is implicit casting to int, so you have to do an explicit cast back to int
Console.WriteLine(result);

Console.WriteLine(Math.Clamp(50, 0, 100)); // keeps a value in a range*/



//
// Chapter 8
//


/*Console.Title = "A new adventure begins...";
Console.Write("What is your name, human? ");
var name = Console.ReadLine();
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine(@$"Welcome to the game /\/\ {name} /\/\");*/

/*for (int i = 0; i < 1000; i++)
{
    Console.ForegroundColor = (ConsoleColor)(i % 16);
    Console.BackgroundColor = (ConsoleColor)(i % 16);
    Console.WriteLine();
    Thread.Sleep(100);
}*/

/*var x = 5;
Console.WriteLine($@"how to put x in \t {{{x}}}"); // {{ to escape to {
Console.WriteLine(@"how to put x in \t {{{x}}}"); 
Console.WriteLine($"how to put x in \t {{{x}}}"); 
Console.WriteLine("how to put x in \t {{{x}}}"); 
// @ means no escape chars
// $ means -> can use {}
Console.ReadKey(true);*/

/*Console.WriteLine($"Formating numbers");
Console.WriteLine($"{042.0100}");
Console.WriteLine($"{042.0100:000.000000}"); // 0's = display digits no matter what
Console.WriteLine($"{042.0100:###.######}"); // #'s = only display significant digits
Console.WriteLine($"{042.0100:0.00%}"); // display a decimal as a percent
Console.ReadKey(true);*/

void ColorsAndSounds()
{
    // you could create a graphic display program that pints color line by line
    // Create some rainbows
    for (int i = 0; i < 100; i++)
    {
        var colorNumber = i % 16;
        Console.Title = $"Adding color: {Enum.GetName(typeof(ConsoleColor), colorNumber)}";
        Console.BackgroundColor = (ConsoleColor)(colorNumber);
        Console.Write("                   ");
        Thread.Sleep(50);
    }

    // make some music
    Thread.Sleep(500);
    Console.WriteLine();
    Console.BackgroundColor = ConsoleColor.Black;
    Console.Title = "Playing F\u00FCr Elise...";

    double bpm = 30;
    double quarter = (60 / bpm) * 1000;
    var eighth = quarter / 2;
    var sixteenth = quarter / 4;
    var half = quarter * 2;
    var whole = quarter * 4;

    var notes = new List<(int, double)>() {
    (659, sixteenth), // E5
    (622, sixteenth), // D#5
    (659, sixteenth), // E5
    (622, sixteenth), // D#5
    (659, sixteenth), // E5
    (493, sixteenth), // B4
    (587, sixteenth), // D5
    (523, sixteenth), // C5
    (440, eighth) // A4
};
    for (int i = 0; i < notes.Count; i++)
    {
        var note = notes[i];
        Console.WriteLine($"freq: {note.Item1,5} -- duration: {note.Item2,5}"); // {x , [whitespace before word]}
        Console.Beep(note.Item1, (int)note.Item2);
    }
}

void TheDefenseOfConsolas()
{
    Console.Title = "Defense of Consolas";
    Console.Write("Target Row? ");
    int targetRow;
    int.TryParse(Console.ReadLine(), out targetRow);
    Console.Write("Target Column? ");
    int targetColumn;
    int.TryParse(Console.ReadLine(), out targetColumn);
    Console.WriteLine("Deploy to:");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"({targetRow}, {targetColumn - 1})");
    Console.WriteLine($"({targetRow - 1}, {targetColumn})");
    Console.WriteLine($"({targetRow}, {targetColumn + 1})");
    Console.WriteLine($"({targetRow + 1}, {targetColumn})");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Beep();
}



//
// Chapter 9
//

/*var t = 1;
if (true)
{
    t = 2;
}
Console.WriteLine(t);*/

void RepairingTheClocktower()
{
    Console.Title = "The Great Clock of Consola";
    Console.WriteLine("Enter -1 to exit...");
    while (true)
    {
        Console.Write("Enter a number: ");
        int number;
        int.TryParse(Console.ReadLine(), out number);
        if (number == -1) break;

        bool isEven = number % 2 == 0;

        if (isEven)
            Console.WriteLine("Tick");
        else
            Console.WriteLine("Tock");
    }
}

void Watchtower()
{
    Console.Title = "The Watchtower";
    Console.WriteLine("\nConsolas is located at: 0, 0\n");
    Console.Write("Enter an x coordinate: ");
    int x;
    int.TryParse(Console.ReadLine(), out x);
    Console.Write("Enter an y coordinate: ");
    int y;
    int.TryParse(Console.ReadLine(), out y);

    Console.WriteLine($"Enemy location: {x}, {y}");

    Console.Write("The enemy is ");
    Console.ForegroundColor = ConsoleColor.Black;
    Console.BackgroundColor = ConsoleColor.Green;

    if (x < 0 && y > 0)
        Console.Write("to the northwest!");
    else if (x < 0 && y == 0)
        Console.Write("to the west!");
    else if (x < 0 && y < 0)
        Console.Write("to the southwest!");
    else if (x == 0 && y > 0)
        Console.Write("to the north!");
    else if (x == 0 && y == 0)
        Console.Write("here!");
    else if (x == 0 && y < 0)
        Console.Write("to the south!");
    else if (x > 0 && y > 0)
        Console.Write("to the northeast!");
    else if (x > 0 && y == 0)
        Console.Write("to the east!");
    else if (x > 0 && y < 0)
        Console.Write("to the southeast!");

    Console.ForegroundColor = ConsoleColor.White;
    Console.BackgroundColor = ConsoleColor.Black;

    Console.Write("\n\n");
}
