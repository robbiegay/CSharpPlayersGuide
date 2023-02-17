using CSharpPlayersGuide.Levels;

// Lets users select which exercise to run:
var shouldExit = false;

while (!shouldExit) 
{
    Console.Title = "C# Player's Guide";

    Console.WriteLine("Press 'e' to exit...\n\nEnter a value to run a program:");
    Console.WriteLine("\t1: HelloWorld");
    Console.WriteLine("\t2: WhatComesNext");
    Console.WriteLine("\t3: TheMakingsOfAProgrammer");
    Console.WriteLine("\t4: ConsolasAndTelim");
    Console.WriteLine("\t5: TheThingNamer3000");
    Console.WriteLine("\t6: TheVariableShop");
    Console.WriteLine("\t7: TheVariableShopReturns");
    Console.WriteLine("\t8: Level6Notes");
    Console.WriteLine("\t9: TheTriangleFarmer");
    Console.WriteLine("\t10: TheFourSistersAndTheDuckbear");
    Console.WriteLine("\t11: TheDominionOfKings");
    Console.WriteLine("\t12: ColorsAndSounds");
    Console.WriteLine("\t13: TheDefenseOfConsolas");
    Console.WriteLine("\t14: RepairingTheClocktower");
    Console.WriteLine("\t15: Watchtower");
    Console.WriteLine("\t16: BuyingInventory");
    Console.WriteLine("\t17: DiscountedInventory");
    Console.WriteLine("\t18: ThePrototype");
    Console.WriteLine("\t19: TheMagicCannon");
    Console.WriteLine("\t20: Level12Notes");
    Console.WriteLine("\t21: TheReplicatorOfDTo");
    Console.WriteLine("\t22: TheLawsOfFreach");

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
            Level6.Level6Notes();
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
            Level12.Level12Notes();
            break;
        case "21":
            Level12.TheReplicatorOfDTo();
            break;
        case "22":
            Level12.TheLawsOfFreach();
            break;
    }

    if (input != "e")
    {
        Console.WriteLine($"\nPress any key to run again...\n");
        Console.ReadKey(true);
        Console.Clear();
    }
}
