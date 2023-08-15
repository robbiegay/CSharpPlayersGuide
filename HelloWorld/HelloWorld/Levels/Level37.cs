namespace CSharpPlayersGuide.Levels
{
    internal class Level37 : ILevel
    {
        public static void Notes()
        {
            Utilities.PrintNotesTitle(37);
            Console.WriteLine("Events let you create delegates that other classes can subscribe to.");
            Console.WriteLine("Don't forget to unsubscribe so that garbage collection can run when you are done with an object.");
            Console.WriteLine("EventHandlers are an alternate option to events.");
            Console.WriteLine("events create backing delegate fields.");
            Console.WriteLine("You should probably have a void return type (ie Action).");
            Console.WriteLine("To allow for a case of no subscribers, ussually you use a nullable Action type: Action?");
            Console.WriteLine("You can allow for parameters: Action<T>?");
            Console.WriteLine("You need to invoke the event in your subject class. Using Something?.Invoke() allows for a safe null check.");
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
            Utilities.PrintInColor("Welcome to the Charberry orchard!\n", 15);

            CharberryTree tree1 = new CharberryTree("Tall", 6);
            CharberryTree tree2 = new CharberryTree("Short", 9);
            CharberryTree tree3 = new CharberryTree("Leafy", 10);
            
            Notifier notifier = new Notifier();
            Harvester harvester = new Harvester();

            notifier.Subscripe(tree1);
            notifier.Subscripe(tree2);
            notifier.Subscripe(tree3);
            harvester.Subscribe(tree1);
            harvester.Subscribe(tree2);
            harvester.Subscribe(tree3);

            while (true)
            {
                tree1.MaybeGrow();
                tree2.MaybeGrow();
                tree3.MaybeGrow();
            }
        }

        private class Notifier
        {
            public void Subscripe(CharberryTree tree)
            {
                tree.Ripened += Announcement;
            }

            private void Announcement(CharberryTree tree)
            {


                Utilities.PrintInColor($"The {tree.Name} charberry tree has ripened!", tree.Color);
            }
        }

        private class Harvester
        {
            public void Subscribe(CharberryTree tree)
            {
                tree.Ripened += Harvest;
            }

            private void Harvest(CharberryTree tree)
            {
                Utilities.PrintInColor("Harvested some fruit from the charberry tree!", 2);
                tree.Ripe = false;
            }
        }

        private class CharberryTree
        {
            private Random _random = new Random();
            public string Name { get; init; }
            public int Color { get; init; }
            public bool Ripe { get; set; }
            public event Action<CharberryTree>? Ripened;

            public CharberryTree(string name, int color)
            {
                Name = name;
                Color = color;
            }

            public void MaybeGrow()
            {        
                // Only a tiny chance of ripening each time, but we try a lot!
                if (_random.NextDouble() < 0.00000001 && !Ripe) 
                {            
                    Ripe = true;
                    Ripened?.Invoke(this);
                }   
            }    
        }
    }
}
