using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayersGuide.Levels
{
    internal class Level17
    {
        public static void Level17Notes()
        {
            Utilities.PrintInColor("\nTuples:\n\n", 3);
            var tuple1 = (Name: "Robbie", Home: "KY", FavNumber: 7, "random-value-lol");

            Console.WriteLine("Tuples can be accessed via:");
            Utilities.PrintInColor("tuple.Item1", 7);

            Console.WriteLine("\nor can be given ephemeral names:");
            Utilities.PrintInColor("var tuple1 = (Name: \"Robbie\", Home: \"KY\", FavNumber: 7, \"random-value-lol\");", 7);
            
            Console.WriteLine($"\nYou can then access items like this:");
            Utilities.PrintInColor($"tuple1.Name: {tuple1.Name}\ntuple1.FavNumber: {tuple1.FavNumber}\ntuple1.Home: {tuple1.Home}\ntuple1.Item4: {tuple1.Item4}", 2);

            var tuple2 = (5, 6, 7);

            Console.WriteLine("\n\n\nDeconstructing a tuple:\n"); 
            Utilities.PrintInColor("var tuple2 = (5, 6, 7);", 7);
            Console.WriteLine("\nDefines the variables and deconstructes the tuple into them, all in one line:");
            Console.WriteLine("If we don't want one of the variables, we can use a discard '_'");
            Utilities.PrintInColor("(int x, int y, _) = tuple2;", 7);

            (int x, int y, _) = tuple2;
            Utilities.PrintInColor($"x: {x}\ny: {y}", 2);

            Console.WriteLine("\n\n\nClever way to swap values:\n");
            int a = 5;
            int b = 10;
            Utilities.PrintInColor("int a = 5;\nint b = 10;", 7);
            Utilities.PrintInColor($"a: {a}, b: {b}", 2);
            Console.WriteLine("Swapping via:");
            Utilities.PrintInColor("(a, b) = (b, a);", 7);
            (a, b) = (b, a);
            Utilities.PrintInColor($"a: {a}, b: {b}", 2);

            Console.WriteLine("\n\n\nTuple equality:");
            Console.WriteLine("\nIf the number of elements, types, and values are equal, then tuples are equal.");
            Console.WriteLine("If there are reference types in the tuple, then they will just check for reference equality.");

            var t1 = (A: 1, B: 2);
            var t2 = (X: 1, Y: 2);
            Utilities.PrintInColor("\nvar t1 = (A: 1, B: 2);\nvar t2 = (X: 1, Y: 2);", 7);

            Console.WriteLine("\nNames in tuples are not part of the data, so naming of varialbes does not factor into equality checks.");

            Utilities.PrintInColor($"\nt1 == t2: {t1 == t2}\nt1 != t2: {t1 != t2}", 2);
        }

        public static void SimulasSoup()
        {
            (SoupType Type, MainIngredient Ingredient, SoupSeasoning Seasoning) soup;

            Utilities.PrintInColor("Let's make some soup!\n", 3);

            Console.WriteLine("Select a soup type:");
            Utilities.PrintInColor("1 - Soup", 2);
            Utilities.PrintInColor("2 - Stew", 2);
            Utilities.PrintInColor("3 - Gumbo", 2);
            soup.Type = GetSoupType();

            Console.WriteLine("\nSelect a main ingredient:");
            Utilities.PrintInColor("1 - Mushroom", 2);
            Utilities.PrintInColor("2 - Chicken", 2);
            Utilities.PrintInColor("3 - Carrot", 2);
            Utilities.PrintInColor("4 - Potato", 2);
            soup.Ingredient = GetMainIngredient();

            Console.WriteLine("\nSelect a seasoning:");
            Utilities.PrintInColor("1 - Spicy", 2);
            Utilities.PrintInColor("2 - Salty", 2);
            Utilities.PrintInColor("3 - Sweet", 2);
            soup.Seasoning = GetSoupSeasoning();

            Utilities.PrintInColor($"\nYou made some {soup.Seasoning} {soup.Ingredient} {soup.Type}... Yummy!", 2);
        }

        static SoupType GetSoupType()
        {
            var soupType = Console.ReadLine();

            if (soupType == "1")
                return SoupType.Soup;
            else if (soupType == "2")
                return SoupType.Stew;
            else if (soupType == "3")
                return SoupType.Gumbo;
            else
            {
                Utilities.PrintInColor($"'{soupType}' is not a valid choice, please try again...", 1);
                return GetSoupType();
            }
        }
        
        static MainIngredient GetMainIngredient()
        {
            var mainIngredient = Console.ReadLine();

            if (mainIngredient == "1")
                return MainIngredient.Mushroom;
            else if (mainIngredient == "2")
                return MainIngredient.Chicken;
            else if (mainIngredient == "3")
                return MainIngredient.Carrot;
            else if (mainIngredient == "4")
                return MainIngredient.Potato;
            else
            {
                Utilities.PrintInColor($"'{mainIngredient}' is not a valid choice, please try again...", 1);
                return GetMainIngredient();
            }
        }

        static SoupSeasoning GetSoupSeasoning()
        {
            var soupSeasoning = Console.ReadLine();

            if (soupSeasoning == "1")
                return SoupSeasoning.Spicy;
            else if (soupSeasoning == "2")
                return SoupSeasoning.Salty;
            else if (soupSeasoning == "3")
                return SoupSeasoning.Sweet;
            else
            {
                Utilities.PrintInColor($"'{soupSeasoning}' is not a valid choice, please try again...", 1);
                return GetSoupSeasoning();
            }
        }

        enum SoupType
        {
            Soup,
            Stew,
            Gumbo
        }

        enum MainIngredient
        {
            Mushroom,
            Chicken,
            Carrot,
            Potato
        }

        enum SoupSeasoning
        {
            Spicy,
            Salty,
            Sweet
        }
    }
}
