using CSharpPlayersGuide;
using CSharpPlayersGuide.Levels;

// Lets users select which exercise to run:
var shouldExit = false;

while (!shouldExit) 
{
    var code = 0;

    Console.Title = "C# Player's Guide";

    Console.WriteLine("Press 'e' to exit...\n\nEnter a value to run a program:");
    PrintLevel(1, true);

    PrintLevel(2, true);

    PrintLevel(3);
    PrintProgram(ref code, "HelloWorld");
    PrintProgram(ref code, "WhatComesNext");
    PrintProgram(ref code, "TheMakingsOfAProgrammer");
    PrintProgram(ref code, "ConsolasAndTelim");

    PrintLevel(4);
    PrintProgram(ref code, "TheThingNamer3000");

    PrintLevel(5, true);

    PrintLevel(6);
    PrintProgram(ref code, "TheVariableShop");
    PrintProgram(ref code, "TheVariableShopReturns");
    PrintProgram(ref code, "Notes");

    PrintLevel(7);
    PrintProgram(ref code, "TheTriangleFarmer");
    PrintProgram(ref code, "TheFourSistersAndTheDuckbear");
    PrintProgram(ref code, "TheDominionOfKings");

    PrintLevel(8);
    PrintProgram(ref code, "ColorsAndSounds");
    PrintProgram(ref code, "TheDefenseOfConsolas");

    PrintLevel(9);
    PrintProgram(ref code, "RepairingTheClocktower");
    PrintProgram(ref code, "Watchtower");

    PrintLevel(10);
    PrintProgram(ref code, "BuyingInventory");
    PrintProgram(ref code, "DiscountedInventory");

    PrintLevel(11);
    PrintProgram(ref code, "ThePrototype");
    PrintProgram(ref code, "TheMagicCannon");

    PrintLevel(12);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "TheReplicatorOfDTo");
    PrintProgram(ref code, "TheLawsOfFreach");

    PrintLevel(13);
    PrintProgram(ref code, "Countdown");

    PrintLevel(14);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "HuntingTheMantiCore");

    PrintLevel(15, true);

    PrintLevel(16);
    PrintProgram(ref code, "SimulasTest");

    PrintLevel(17);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "SimulasSoup");

    PrintLevel(18);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "TellMeTheFiveObjectOrientedPrinciples");
    PrintProgram(ref code, "VinFletchersArrows");

    PrintLevel(19);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "VinsTrouble");

    PrintLevel(20);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "ThePropertiesOfArrows");

    PrintLevel(21);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "ArrowFactories");

    PrintLevel(22);
    PrintProgram(ref code, "Notes");

    PrintLevel(23);
    PrintProgram(ref code, "Notes");

    PrintLevel(24);
    PrintProgram(ref code, "BossBattles");

    PrintLevel(25);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "PackingInventory");

    PrintLevel(26);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "LabelingInventory");
    PrintProgram(ref code, "TheOldRobot");

    PrintLevel(27);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "RoboticInterface");

    PrintLevel(28);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "RoomCoordinates");

    PrintLevel(29);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "WarPreparations");

    PrintLevel(30);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "ColoredItems");

    PrintLevel(31);
    PrintProgram(ref code, "DesignNotes");
    PrintProgram(ref code, "TheFountainOfObjects");

    PrintLevel(32);
    PrintProgram(ref code, "Notes");

    Console.Write("> ");
    var input = Console.ReadLine();
    Console.Clear();

    switch (input)
    {
        case "e":
            shouldExit = true;
            break;
        case "1":
            Level3.HelloWorld();
            break;
        case "2":
            Level3.WhatComesNext();
            break;
        case "3":
            Level3.TheMakingsOfAProgrammer();
            break;
        case "4":
            Level3.ConsolasAndTelim();
            break;
        case "5":
            Level4.TheThingNamer3000();
            break;
        case "6":
            Level6.TheVariableShop();
            break;
        case "7":
            Level6.TheVariableShopReturns();
            break;
        case "8":
            Level6.Notes();
            break;
        case "9":
            Level7.TheTriangleFarmer();
            break;
        case "10":
            Level7.TheFourSistersAndTheDuckbear();
            break;
        case "11":
            Level7.TheDominionOfKings();
            break;
        case "12":
            Level8.ColorsAndSounds();
            break;
        case "13":
            Level8.TheDefenseOfConsolas();
            break;
        case "14":
            Level9.RepairingTheClocktower();
            break;
        case "15":
            Level9.Watchtower();
            break;
        case "16":
            Level10.BuyingInventory();
            break;
        case "17":
            Level10.DiscountedInventory();
            break;
        case "18":
            Level11.ThePrototype();
            break;
        case "19":
            Level11.TheMagicCannon();
            break;
        case "20":
            Level12.Notes();
            break;
        case "21":
            Level12.TheReplicatorOfDTo();
            break;
        case "22":
            Level12.TheLawsOfFreach();
            break;
        case "23":
            Level13.Countdown();
            break;
        case "24":
            Level14.Notes();
            break;
        case "25":
            Level14.HuntingTheMantiCore();
            break;
        case "26":
            Level16.SimulasTest();
            break;
        case "27":
            Level17.Notes();
            break;
        case "28":
            Level17.SimulasSoup();
            break;
        case "29":
            Level18.Notes();
            break;
        case "30":
            Level18.TellMeTheFiveObjectOrientedPrinciples();
            break;
        case "31":
            Level18.VinFletchersArrows();
            break;
        case "32":
            Level19.Notes();
            break;
        case "33":
            Level19.VinsTrouble();
            break;
        case "34":
            Level20.Notes();
            break;
        case "35":
            Level20.ThePropertiesOfArrows();
            break;
        case "36":
            Level21.Notes();
            break;
        case "37":
            Level21.ArrowFactories();
            break;
        case "38":
            Level22.Notes();
            break;
        case "39":
            Level23.Notes();
            break;
        case "40":
            Level24.BossBattles();
            break;
        case "41":
            Level25.Notes();
            break;
        case "42":
            Level25.PackingInventory();
            break;
        case "43":
            Level26.Notes();
            break;
        case "44":
            Level26.LabelingInventory();
            break;
        case "45":
            Level26.TheOldRobot();
            break;
        case "46":
            Level27.Notes();
            break;
        case "47":
            Level27.RoboticInterface();
            break;
        case "48":
            Level28.Notes();
            break;
        case "49":
            Level28.RoomCoordinates();
            break;
        case "50":
            Level29.Notes();
            break;
        case "51":
            Level29.WarPreparations();
            break;
        case "52":
            Level30.Notes();
            break;
        case "53":
            Level30.ColoredItems();
            break;
        case "54":
            Level31.DesignNotes();
            break;
        case "55":
            Level31.TheFountainOfObjects();
            break;
        case "56":
            Level32.Notes();
            break;
    }

    if (input != "e")
    {
        Console.WriteLine($"\nPress any key to run again...\n");
        Console.ReadKey(true);
        Console.Clear();
    }
}

void PrintLevel(int level, bool hasNoExercises = false)
{
    Console.WriteLine();

    Utilities.PrintInColor($"\t~~ Level {level} ~~", 2);

    if (hasNoExercises)
        Utilities.PrintInColor($"\t[Level {level} has no exercises]", 5);
}

void PrintProgram(ref int code, string program)
{
    code++;

    Console.WriteLine($"\t{code}: {program}");
}
