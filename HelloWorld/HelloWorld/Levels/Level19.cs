using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static CSharpPlayersGuide.Levels.Level18;

namespace CSharpPlayersGuide.Levels
{
    internal class Level19
    {
        public static void Notes()
        {
            Utilities.PrintInColor("Level 19 Notes:", 3);
            Console.WriteLine("");
            Console.WriteLine("Make things as inaccessable as possible while still allowing the class to do its job");
            Console.WriteLine("Fields (data) should almost always be private");
            Console.WriteLine("In fact, the default accessability level is private");
            Console.WriteLine("Private data allows you to enforce rules such as: a field can't be negative");
            Console.WriteLine("");
            Console.WriteLine("Accessability levels are guidelines, not laws: they cause the compiler to throw errors");
            Console.WriteLine("but there are ways to intentionally get around it (one such being via reflaction)");
            Console.WriteLine("");
            Console.WriteLine("A class cannot be private as this would mean nothing could access it, and that doesn't really make sense.");
            Console.WriteLine("");
            Console.WriteLine("A class can be: public, internal\nA member of a class can be: public, internal, private");
            Console.WriteLine("Enum member can only be public");
            Console.WriteLine("");
            Console.WriteLine("Internal: can only be accessed within the project");
        }

        public static void VinsTrouble()
        {
            Level18.VinFletchersArrows(true);
        }

        internal class ImprovedArrow
        {
            private ArrowHead _arrowHead;
            private int _length;
            private Fletching _fletching;

            private int minLength = 60;
            private int maxLength = 100;

            // Creates a default values for an empty constructor
            public ImprovedArrow() : this(ArrowHead.Wood, 80, Fletching.Plastic)
            {

            }

            public ImprovedArrow(ArrowHead arrowHead, int length, Fletching fletching)
            {
                if (length < minLength)
                    length = minLength;
                else if (length > maxLength)
                    length = maxLength;

                _arrowHead = arrowHead;
                _length = length;
                _fletching = fletching;
            }

            // Setters: no setters per the exercise prompt

            //public void SetArrowHead(ArrowHead arrowHead) => _arrowHead = arrowHead;
            //public void SetLength(int length) => _length = length;
            //public void SetFletching(Fletching fletching) => _fletching = fletching;

            // Getters:
            public string GetArrowHead() => _arrowHead.ToString();
            public string GetLength() => $"{_length}";
            public string GetFletching() => _fletching.ToString();

            public double GetCost()
            {
                var cost = 0.0;

                cost += _arrowHead switch
                {
                    ArrowHead.Steel => 10,
                    ArrowHead.Wood => 3,
                    ArrowHead.Obsidian => 5,
                    _ => 0
                };

                cost += _length * 0.05;

                cost += _fletching switch
                {
                    Fletching.Plastic => 10,
                    Fletching.TurkeyFeathers => 5,
                    Fletching.GooseFeathers => 3,
                    _ => 0
                };

                return cost;
            }
        }
    }
}
