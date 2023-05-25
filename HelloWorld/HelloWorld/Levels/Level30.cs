namespace CSharpPlayersGuide.Levels
{
    internal class Level30
    {
        internal static void Notes()
        {
            Utilities.PrintNotesTitle(30);
            Console.WriteLine("Generics make your classes and methods more reusabe by allowing you to use multiple types in a single class/method!");
            Console.WriteLine("This can greatly reduce code duplication.");
            Console.WriteLine("");
            Console.WriteLine("As an example, imagine you are creating your own List class (dynamically sized array)");
            Console.WriteLine("You might make it to hold 'ints', but then you need 'strings', and what about 'doubles'?");
            Console.WriteLine("Soon you will have 100 nearly idential List implementations.");
            Console.WriteLine("");
            Console.WriteLine("One possible solution would be to make your List class use: object[]");
            Console.WriteLine("This will allow you to put anything in your List, but it takes away all the great saftey features of a strongly typed language.");
            Console.WriteLine("Using objects for your types makes C# behave like it is loosely typed:");
            Utilities.PrintCode(
"""
object a = 'a';
a = 1;
a = true;
"""
                );
            Console.WriteLine("");
            object a = 'a';
            Utilities.PrintInColor($"Value of 'a': {a} (Type: {a.GetType()})", 2);
            a = 1;
            Utilities.PrintInColor($"Value of 'a': {a} (Type: {a.GetType()})", 2);
            a = true;
            Utilities.PrintInColor($"Value of 'a': {a} (Type: {a.GetType()})", 2);
            Console.WriteLine("");
            Console.WriteLine("An implementation of List using object[] means that you can add any types:");
            var myList = new MyList();
            myList.Add(1);
            myList.Add("test");
            myList.Add(false);
            Utilities.PrintCode(
"""
var myList = new MyList();
myList.Add(1);
myList.Add("test");
myList.Add(false);
"""
                );
            Console.WriteLine("");
            for (int i = 0; i < myList.Length; i++)
            {
                //int item2 = (int)myList.Get(i);// This will break: expects an int, gets something else
                var item = myList.Get(i);
                Utilities.PrintInColor($"Item {i}: {item} (Type: {item.GetType()})", 2);
            }
            Console.WriteLine("");
            Console.WriteLine("There are several problems with this:");
            Console.WriteLine("\t- You never know what you are pulling out when you access an item in the list");
            Console.Write("\t- The compiler can no longer help you avoid type errors.\n\t  Code like this will compile but break if not the expected type: ");
            Utilities.PrintCode("(int)myList.Get(i);", true);
            Console.WriteLine("\n");
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Generics provide an answer to the problem of using multiple types in the same class/method!");
            Console.WriteLine("Some terms:");
            Console.WriteLine("\t- MyGenericList<T> -> Generic type parameter");
            Console.WriteLine("\t  Conventions: T (type), K (key), V (value) -OR- TItem, TString, etc");
            Console.WriteLine("\t- new MyGenericList<int>(); -> Generic type argument");
            Console.WriteLine("");
            Console.WriteLine("Generics can be set at the class (class MyClass<T>) or method level (void MyMethod<T>(int x)");
            Console.WriteLine("Generics can then by used as: return types, input parameters, or anywhere in the class or method body.");
            Console.WriteLine("");
            var myGenericList = new MyGenericList<int>(); // Generic type argument
            var myStringList = new MyGenericList<string>(); // Can make any type for free!
            var myObjectList = new MyGenericList<object>();
            var myMyGenericListList = new MyGenericList<MyGenericList<object>>();
            myGenericList.Add(1);
            myGenericList.Add(2);
            myGenericList.Add(3);
            //myGenericList.Add("test"); // We now get type checking
            //myGenericList.Add(false);
            Utilities.PrintCode(
"""
var myGenericList = new MyGenericList<int>(); // We can now use any type!
var myStringList = new MyGenericList<string>();
var myObjectList = new MyGenericList<object>();
var myMyGenericListList = new MyGenericList<MyGenericList<object>>();

myGenericList.Add(1);
myGenericList.Add(2);
myGenericList.Add(3);

//myGenericList.Add("test"); // Compiler error: We now get type checking!
//myGenericList.Add(false);
"""
                );
            Console.WriteLine("");
            Console.WriteLine("Now all of the items in myGenericList are ints:");
            Console.WriteLine("");
            for (int i = 0; i < myGenericList.Length; i++)
            {
                //int item2 = (int)myGenericList.Get(i);// This will work now (though we dont need to cast anymore
                var item = myGenericList.Get(i);
                Utilities.PrintInColor($"Item {i}: {item} (Type: {item.GetType()})", 2);
            }
            Console.WriteLine("");
            Console.WriteLine("You can use inheritence with generics:");
            Console.WriteLine("\t- Open -- Pass the generic variable between classes: class Child<T> : Parent<T>");
            Console.WriteLine("\t- Open -- Add a new generic variable: class Child<T> : Parent");
            Console.WriteLine("\t- Closed -- remove the generic variable: class Child : Parent<T>");
            Console.WriteLine("");
            Console.WriteLine("In many cases, you might use generics on a method that is inside a class without generics.");
            Console.WriteLine("");
            Console.WriteLine("Generic constraints: can place limits on what type can be used: ");
            Console.WriteLine("\t- Can specify types: where T : class");
            Console.WriteLine("\t- Or that the type has a parameterless ctor: new()");
            Console.WriteLine("\t  This is useful because it allows you to use: default");
            Console.WriteLine("\t  Default: int = 0, bool = false, etc");
            Console.WriteLine("");
            //Test.Print<int>(); // throws compiler error
            Utilities.PrintCode(
"""
public static T Print<T>() where T : class, new() 
{
    T item = new();
    item = default; // Create default value. Ex: int = 0, bool = false

    return item;
}

//Test.Print<int>(); // throws compiler error
""");
        }

        internal static void ColoredItems()
        {
            var blueSword = new ColoredItem<Sword>();
            var redBow = new ColoredItem<Bow>();
            var greenAxe = new ColoredItem<Axe>();

            blueSword.Color = ConsoleColor.Blue;
            redBow.Color = ConsoleColor.Red;
            greenAxe.Color = ConsoleColor.Green;

            blueSword.Display();
            redBow.Display();
            greenAxe.Display();
        }

        private record Sword { }
        private record Bow { }
        private record Axe { }

        private class ColoredItem<T> where T : new()
        {
            public T Item { get; set; } = new();
            public ConsoleColor Color { get; set; } = ConsoleColor.White;

            public void Display()
            {
                Console.ForegroundColor = Color;
                Console.WriteLine($"The {nameof(Item)}: {Item?.ToString()}");
                Console.ResetColor();
            }
        }

        // --------------------------------------------------------------

        private class MyList
        {
            private object[] items = new object[0];
            public int Length { get { return items.Length; } }

            public void Add(object item)
            {
                var newItems = new object[items.Length + 1];

                for (int i = 0; i < items.Length; i++)
                {
                    newItems[i] = items[i];
                }

                newItems[^1] = item;

                items = newItems;
            }

            public object Get(int index) 
            {
                return items[index];
            }

            public void Set(int index, object item)
            {
                items[index] = item;
            }
        }

        private class MyGenericList<T> // Generic type parameter
                                       // Can be named anything but two conventions:
                                       //   - Single, capital letter: T, K, V, etc (Type, Key, Value)
                                       //   - TString, TItem, etc
        {
            private T[] items = new T[0];
            public int Length { get { return items.Length; } }

            public void Add(T item)
            {
                var newItems = new T[items.Length + 1];

                for (int i = 0; i < items.Length; i++)
                {
                    newItems[i] = items[i];
                }

                newItems[^1] = item;

                items = newItems;
            }

            public object Get(int index)
            {
                return items[index];
            }

            public void Set(int index, T item)
            {
                items[index] = item;
            }
        }

        private class FancyGenericList<TFirst, TSecond> : MyGenericList<TFirst> { } // Open: can still use generics. Also, adds a second generic 'TSecond'
        private class FancyGenericListClosed : MyGenericList<int> { } // Closed: can only use int
        private class Simple { }
        private class MoreComplex<T> : Simple { } // Can add generics to a non-generic base class
        private class Test
        {
            public static T Print<T>() where T : class, new() // Generic constraint -> this ensures a class type and parameterless ctor
            {
                T item = new();
                item = default; // Create default value. Ex: int = 0, bool = false

                return item;
            }
        }
    }
}
