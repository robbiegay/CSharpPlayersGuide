//global using Microsoft;
using static System.Console; // Author recommends against this as it makes your code more ambiguous
using IField;
using McDroid;
using FieldPig = IField.Pig;
using DroidPig = McDroid.Pig;

namespace CSharpPlayersGuide.Levels
{
    internal class Level33
    {
        internal static void Notes()
        {
            Utilities.PrintNotesTitle(33);
            System.Console.WriteLine("System.Console.WriteLine = fully qualified name");
            WriteLine("global using -> adds the using for all files -> typically put in its own file");
            WriteLine("When you use top level statements, it compiles to <Main>$ which is an 'unspeakable', something the code cant ref by name.");
            WriteLine("Quiz: 1. True 2. System, System.Collections.Generics, System.Text 3. namespace 4. False");
        }

        internal static void TheFeud()
        {
            var sheep = new Sheep();
            var pig1 = new FieldPig();
            var cow = new Cow();
            var pig2 = new DroidPig();

            Utilities.PrintCode(
"""
using FieldPig = IField.Pig;
using DroidPig = McDroid.Pig;

var sheep = new Sheep();
var pig1 = new FieldPig();
var cow = new Cow();
var pig2 = new DroidPig();
""");
        }

        internal static void DuelingTraditions()
        {
            Console.WriteLine("I've already: put things in namespaces, put types in their own files. Skipping the Main method part.");
        }
    }
}

namespace IField
{
    internal class Sheep
    {
        //
    }

    internal class Pig
    {
        //
    }
}

namespace McDroid
{
    internal class Cow
    {
        //
    }

    internal class Pig
    {
        //
    }
}