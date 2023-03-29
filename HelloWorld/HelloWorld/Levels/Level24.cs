using System.Xml;

namespace CSharpPlayersGuide.Levels
{
    internal static class Level24
    {
        public static void BossBattles()
        {
            Utilities.PrintInColor("Level 24 Boss Battles:", 2);
            Console.WriteLine("");
            Utilities.PrintInColor("The Point:", 4);
            var p1 = new Point(2, 3);
            var p2 = new Point(-4, 0);
            Console.WriteLine($"Point 1: X:{p1.X}, Y:{p1.Y}");
            Console.WriteLine($"Point 2: X:{p2.X}, Y:{p2.Y}");
            Console.WriteLine("X and Y are immutable because the design requierments did not say that they need to be changed: YAGNI");
            Console.WriteLine("");
            Utilities.PrintInColor("The Color:", 4);
            var c1 = new Color(-1, 256, 128); // Should change -1 to 0 and 256 to 255
            var c2 = Color.Purple;
            Console.WriteLine($"Color 1: red: {c1.R}, green: {c1.G}, blue: {c1.B}");
            Console.WriteLine($"Color 2: red: {c2.R}, green: {c2.G}, blue: {c2.B}");
            Console.WriteLine("");
            Utilities.PrintInColor("NextChallenge:", 4);
        }
    }

    internal class Point
    {
        public int X { get; init; }
        public int Y { get; init; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point()
        {
            X = 0;
            Y = 0;
        }
    }
    internal class Color
    {
        public static Color White => new Color(255, 255, 255);
        public static Color Black => new Color(0, 0, 0);
        public static Color Red => new Color(255, 0, 0);
        public static Color Orange => new Color(255, 165, 0);
        public static Color Yellow => new Color(255, 255, 0);
        public static Color Green => new Color(0, 128, 0);
        public static Color Blue => new Color(0, 0, 255);
        public static Color Purple => new Color(128, 0, 128);

        private int _red;
        private int _green;
        private int _blue;

        public int R 
        { 
            get => _red; 
            init
            {
                if (value < 0)
                    _red = 0;
                else if (value > 255)
                    _red = 255;
                else
                    _red = value;
            }
        }

        public int G
        { 
            get => _green; 
            init
            {
                if (value < 0)
                    _green = 0;
                else if (value > 255)
                    _green = 255;
                else
                    _green = value;
            }
        }
        public int B 
        {
            get => _blue;
            init
            {
                if (value < 0)
                    _blue = 0;
                else if (value > 255)
                    _blue = 255;
                else
                    _blue = value;
            }
        }

        public Color(int red, int green, int blue)
        {
            R = red;
            G = green;
            B = blue;
        }
    }
}
