namespace CSharpPlayersGuide.Levels
{
    internal class Level37 : ILevel
    {
        public static void Notes()
        {
            Utilities.PrintNotesTitle(37);
            Console.WriteLine("Events let you create delegates that other classes can subscribe to");
            Console.WriteLine("");
            var ship = new Ship(100);
            new SoundEffect(ship);
            new Animation(ship);
            ship.TakeDamage(10);
            ship.TakeDamage(10);
            ship.TakeDamage(10);
            ship.TakeDamage(10);
            ship.TakeDamage(10);
            ship.TakeDamage(10);
            ship.TakeDamage(10);
            ship.TakeDamage(10);
            ship.TakeDamage(10);
            ship.TakeDamage(10);
        }

        private class Ship
        {
            public Action? ShipExploded = () => { Utilities.PrintInColor("An empty delegate", 5); };
            private int _damage;
            private int _health;

            public Ship(int health)
            {
                _damage = health;
                _health = health;
            }

            public void TakeDamage(int damage)
            {
                _damage -= damage;

                Utilities.PrintInColor($"Your ship took {damage} damage. {_damage}/{_health} remaining...", 15);

                if (_damage <= 0)
                {
                    ShipExploded?.Invoke();
                }
            }
        }

        private class SoundEffect
        {
            public SoundEffect(Ship ship)
            {
                ship.ShipExploded += PlayExplosion;
            }

            private void PlayExplosion()
            {
                Utilities.PrintInColor("Your ship exploded!", 1);
            }
        }

        private class Animation
        {
            public Animation(Ship ship)
            {
                ship.ShipExploded += PlayShipExplosionAnimation;
            }

            private void PlayShipExplosionAnimation()
            {
                for (int i = 0; i < 10; i++)
                {
                    Utilities.PrintInColor("\\", 13, true);
                    Thread.Sleep(5);

                    Utilities.PrintInColor("~", 1, true);
                    Thread.Sleep(5);
                }

                Utilities.PrintInColor(" <", 3, true);
                Thread.Sleep(5);

                Utilities.PrintInColor("0", 4, true);
                Thread.Sleep(5);

                Utilities.PrintInColor("> ", 3, true);
                Thread.Sleep(5);

                for (int i = 0; i < 10; i++)
                {
                    Utilities.PrintInColor("/", 13, true);
                    Thread.Sleep(5);

                    Utilities.PrintInColor("~", 1, true);
                    Thread.Sleep(5);
                }
            }
        }

        public static void CharberryTrees()
        {
            throw new NotImplementedException();
        }
    }
}
