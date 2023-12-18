using CSharpPlayersGuide;
using CSharpPlayersGuide.Levels;

// Lets users select which exercise to run:
var shouldExit = false;

while (!shouldExit) 
{
    var code = 0;
    var level = 0;

    Console.Title = "C# Player's Guide";

    Console.WriteLine("Press 'e' to exit...\n\nEnter a value to run a program:");
    PrintLevel(ref level, true); // Level 1

    PrintLevel(ref level, true);

    PrintLevel(ref level);
    PrintProgram(ref code, "HelloWorld");
    PrintProgram(ref code, "WhatComesNext");
    PrintProgram(ref code, "TheMakingsOfAProgrammer");
    PrintProgram(ref code, "ConsolasAndTelim");

    PrintLevel(ref level);
    PrintProgram(ref code, "TheThingNamer3000");

    PrintLevel(ref level, true); // Level 5

    PrintLevel(ref level);
    PrintProgram(ref code, "TheVariableShop");
    PrintProgram(ref code, "TheVariableShopReturns");
    PrintProgram(ref code, "Notes");

    PrintLevel(ref level);
    PrintProgram(ref code, "TheTriangleFarmer");
    PrintProgram(ref code, "TheFourSistersAndTheDuckbear");
    PrintProgram(ref code, "TheDominionOfKings");

    PrintLevel(ref level);
    PrintProgram(ref code, "ColorsAndSounds");
    PrintProgram(ref code, "TheDefenseOfConsolas");

    PrintLevel(ref level);
    PrintProgram(ref code, "RepairingTheClocktower");
    PrintProgram(ref code, "Watchtower");

    PrintLevel(ref level); // Level 10
    PrintProgram(ref code, "BuyingInventory");
    PrintProgram(ref code, "DiscountedInventory");

    PrintLevel(ref level);
    PrintProgram(ref code, "ThePrototype");
    PrintProgram(ref code, "TheMagicCannon");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "TheReplicatorOfDTo");
    PrintProgram(ref code, "TheLawsOfFreach");

    PrintLevel(ref level);
    PrintProgram(ref code, "Countdown");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "HuntingTheMantiCore");

    PrintLevel(ref level, true); // Level 15

    PrintLevel(ref level);
    PrintProgram(ref code, "SimulasTest");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "SimulasSoup");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "TellMeTheFiveObjectOrientedPrinciples");
    PrintProgram(ref code, "VinFletchersArrows");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "VinsTrouble");

    PrintLevel(ref level); // Level 20
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "ThePropertiesOfArrows");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "ArrowFactories");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");

    PrintLevel(ref level);
    PrintProgram(ref code, "BossBattles");

    PrintLevel(ref level); // Level 25
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "PackingInventory");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "LabelingInventory");
    PrintProgram(ref code, "TheOldRobot");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "RoboticInterface");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "RoomCoordinates");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "WarPreparations");

    PrintLevel(ref level); // Level 30
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "ColoredItems");

    PrintLevel(ref level);
    PrintProgram(ref code, "DesignNotes");
    PrintProgram(ref code, "TheFountainOfObjects");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "TheFeud");
    PrintProgram(ref code, "DuelingTraditions");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "SaferNumberCrunching");
    PrintProgram(ref code, "BetterRandom");

    PrintLevel(ref level); // Level 35
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "ExeptisGame");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "TheSieve");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "CharberryTrees");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "TheLambdaSieve");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "MessageInABottle");
    PrintProgram(ref code, "HighScores");
    PrintProgram(ref code, "TheLongGame");

    PrintLevel(ref level); // Level 40
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "ThePotionMastersOfPattren");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "NavigatingOperandCity");
    PrintProgram(ref code, "IndexingOperandCity");
    PrintProgram(ref code, "ConvertingDirectionsToOffsets");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "TheThreeLenses");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "TheRepeatingStream");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "AsynchronousRandomWords");
    PrintProgram(ref code, "ManyRandomWords");
    PrintProgram(ref code, "TaskExperiments");

    PrintLevel(ref level); // Level 45
    PrintProgram(ref code, "Notes");
    PrintProgram(ref code, "UniterOfAdds");
    PrintProgram(ref code, "TheRobotFactory");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");

    PrintLevel(ref level); // Level 50
    PrintProgram(ref code, "Notes");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");

    PrintLevel(ref level);
    PrintProgram(ref code, "Notes");

    PrintLevel(ref level); // Level 53
    PrintProgram(ref code, "Notes");

    PrintBonusLevel("Bonus Level A");
    PrintProgram(ref code, "Notes");

    PrintBonusLevel("Bonus Level B");
    PrintProgram(ref code, "Notes");

    PrintBonusLevel("Bonus Level C");
    PrintProgram(ref code, "Notes");

    PrintBonusLevel("C# 11 Expansion");
    PrintProgram(ref code, "Notes");

    PrintBonusLevel("C# 12 Expansion");
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
        case "57":
            Level33.Notes();
            break;
        case "58":
            Level33.TheFeud();
            break;
        case "59":
            Level33.DuelingTraditions();
            break;
        case "60":
            Level34.Notes();
            break;
        case "61":
            Level34.SaferNumberCrunching();
            break;
        case "62":
            Level34.BetterRandom();
            break;
        case "63":
            Level35.Notes();
            break;
        case "64":
            Level35.ExeptisGame();
            break;
        case "65":
            Level36.Notes();
            break;
        case "66":
            Level36.TheSieve();
            break;
        case "67":
            Level37.Notes();
            break;
        case "68":
            Level37.CharberryTrees();
            break;
        case "69":
            Level38.Notes();
            break;
        case "70":
            Level38.TheLambdaSieve();
            break;
        case "71":
            Level39.Notes();
            break;
        case "72":
            Level39.MessageInABottle();
            break;
        case "73":
            Level39.HighScores();
            break;
        case "74":
            Level39.TheLongGame();
            break;
        case "75":
            Level40.Notes();
            break;
        case "76":
            Level40.ThePotionMastersOfPattren();
            break;
        case "77":
            Level41.Notes();
            break;
        case "78":
            Level41.NavigatingOperandCity();
            break;
        case "79":
            Level41.IndexingOperandCity();
            break;
        case "80":
            Level41.ConvertingDirectionsToOffsets();
            break;
        case "81":
            Level42.Notes();
            break;
        case "82":
            Level42.TheThreeLenses();
            break;
        case "83":
            Level43.Notes();
            break;
        case "84":
            Level43.TheRepeatingStream();
            break;
        case "85":
            Level44.Notes();
            break;
        case "86":
            await Level44.AsynchronousRandomWords();
            break;
        case "87":
            await Level44.ManyRandomWords();
            break;
        case "88":
            await Level44.TaskExperiments();
            break;
        case "89":
            Level45.Notes();
            break;
        case "90":
            Level45.UniterOfAdds();
            break;
        case "91":
            Level45.TheRobotFactory();
            break;
        case "92":
            Level46.Notes();
            break;
    }

    if (input != "e")
    {
        Console.WriteLine($"\nPress any key to run again...\n");
        Console.ReadKey(true);
        Console.Clear();
    }
}

void PrintLevel(ref int level, bool hasNoExercises = false)
{
    level += 1;

    Console.WriteLine();

    Utilities.PrintInColor($"\t~~ Level {level} ~~", 2);

    if (hasNoExercises)
        Utilities.PrintInColor($"\t[Level {level} has no exercises]", 5);
}

void PrintBonusLevel(string level, bool hasNoExercises = false)
{
    Console.WriteLine();

    Utilities.PrintInColor($"\t~~ {level} ~~", 2);

    if (hasNoExercises)
        Utilities.PrintInColor($"\t[{level} has no exercises]", 5);
}

void PrintProgram(ref int code, string program)
{
    code++;

    Console.WriteLine($"\t{code}: {program}");
}
