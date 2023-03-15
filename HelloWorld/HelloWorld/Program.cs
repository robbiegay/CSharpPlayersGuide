using CSharpPlayersGuide;
using CSharpPlayersGuide.Levels;

// Lets users select which exercise to run:
var shouldExit = false;

while (!shouldExit) 
{
    Console.Title = "C# Player's Guide";

    Console.WriteLine("Press 'e' to exit...\n\nEnter a value to run a program:");
    PrintLevel(1, true);

    PrintLevel(2, true);

    PrintLevel(3);
    Console.WriteLine("\t1: HelloWorld");
    Console.WriteLine("\t2: WhatComesNext");
    Console.WriteLine("\t3: TheMakingsOfAProgrammer");
    Console.WriteLine("\t4: ConsolasAndTelim");

    PrintLevel(4);
    Console.WriteLine("\t5: TheThingNamer3000");

    PrintLevel(5, true);

    PrintLevel(6);
    Console.WriteLine("\t6: TheVariableShop");
    Console.WriteLine("\t7: TheVariableShopReturns");
    Console.WriteLine("\t8: Notes");

    PrintLevel(7);
    Console.WriteLine("\t9: TheTriangleFarmer");
    Console.WriteLine("\t10: TheFourSistersAndTheDuckbear");
    Console.WriteLine("\t11: TheDominionOfKings");

    PrintLevel(8);
    Console.WriteLine("\t12: ColorsAndSounds");
    Console.WriteLine("\t13: TheDefenseOfConsolas");

    PrintLevel(9);
    Console.WriteLine("\t14: RepairingTheClocktower");
    Console.WriteLine("\t15: Watchtower");

    PrintLevel(10);
    Console.WriteLine("\t16: BuyingInventory");
    Console.WriteLine("\t17: DiscountedInventory");

    PrintLevel(11);
    Console.WriteLine("\t18: ThePrototype");
    Console.WriteLine("\t19: TheMagicCannon");

    PrintLevel(12);
    Console.WriteLine("\t20: Notes");
    Console.WriteLine("\t21: TheReplicatorOfDTo");
    Console.WriteLine("\t22: TheLawsOfFreach");

    PrintLevel(13);
    Console.WriteLine("\t23: Countdown");

    PrintLevel(14);
    Console.WriteLine("\t24: Notes");
    Console.WriteLine("\t25: HuntingTheMantiCore");

    PrintLevel(15, true);

    PrintLevel(16);
    Console.WriteLine("\t26: SimulasTest");

    PrintLevel(17);
    Console.WriteLine("\t27: Notes");
    Console.WriteLine("\t28: SimulasSoup");

    PrintLevel(18);
    Console.WriteLine("\t29: Notes");
    Console.WriteLine("\t30: TellMeTheFiveObjectOrientedPrinciples");
    Console.WriteLine("\t31: VinFletchersArrows");

    PrintLevel(19);
    Console.WriteLine("\t32: Notes");
    Console.WriteLine("\t33: VinsTrouble");

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
