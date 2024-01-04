using System;

namespace CSharpPlayersGuide.Levels
{
    class Level16
    {
        public static void SimulasTest()
        {
            Box boxState = Box.Closed;

            var keepRunning = true;
            Utilities.PrintInColor("Valid inputs: e/exit, l/lock, u/unlock, o/open, c/close", 2);

            while (keepRunning)
            {
                Console.Write($"The chest is {boxState}. What do you want to do? ");
                string input = (Console.ReadLine() ?? "").ToLower();
                Console.Write("\n");

                switch (input)
                {
                    case "e":
                    case "exit":
                        keepRunning = false;
                        break;
                    case "l":
                    case "lock":
                        if (boxState == Box.Closed)
                            boxState = Box.Locked;
                        else
                            Utilities.PrintInColor($"Box is {boxState} and cannot be locked.", 1);
                        break;
                    case "u":
                    case "unlock":
                        if (boxState == Box.Locked)
                            boxState = Box.Closed;
                        else
                            Utilities.PrintInColor($"Box is {boxState} and cannot be unlocked.", 1);
                        break;
                    case "o":
                    case "open":
                        if (boxState == Box.Closed)
                            boxState = Box.Open;
                        else
                            Utilities.PrintInColor($"Box is {boxState} and cannot be opened.", 1);
                        break;
                    case "c":
                    case "close":
                        if (boxState == Box.Open)
                            boxState = Box.Closed;
                        else
                            Utilities.PrintInColor($"Box is {boxState} and cannot be closed.", 1);
                        break;
                }
            }
            
        }
    }

    enum Box
    {
        Locked, // first item is the enum's default value
        Closed,
        Open
    }

    // Enums are based on ints. You can change this:
    enum Test : byte
    {
        StartsAtThree = 3,
        IsImplicitlyFour, // assigned 4
        CanBeAssignedAnotherValue = 100

    }
    // automatically assigned 0...n
    // you can overwrite this by assining custom values
    // and any unassigned value are: last value + 1
    // The default value is still 0 even if nothing is assigned, so having something like Unknown = 0 is a good idea
}
