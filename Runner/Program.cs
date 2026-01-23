using System.Xml.Linq;

namespace Simulator
{
    internal class Program
    {
        static void TestCreatures()
        {
            //Creature c = new() { Name = "   Shrek    ", Level = 20 };
            //c.SayHi();
            //c.Upgrade();
            //Console.WriteLine(c.Info);

            //c = new("  ", -5);
            //c.SayHi();
            //c.Upgrade();
            //Console.WriteLine(c.Info);

            //c = new("  donkey ") { Level = 7 };
            //c.SayHi();
            //c.Upgrade();
            //Console.WriteLine(c.Info);

            //c = new("Puss in Boots – a clever and brave cat.");
            //c.SayHi();
            //c.Upgrade();
            //Console.WriteLine(c.Info);

            //c = new("a                            troll name", 5);
            //c.SayHi();
            //c.Upgrade();
            //Console.WriteLine(c.Info);

            //var a = new Animals() { Description = "   Cats " };
            //Console.WriteLine(a.Info);

            //a = new() { Description = "Mice           are great", Size = 40 };
            //Console.WriteLine(a.Info);
        }
        //static void TestDirections()
        //{
        //    Creature c = new Orc("Shrek", 7);
        //    Console.WriteLine(c.Greeting());

        //    Console.WriteLine("\n* Up");
        //    Console.WriteLine(c.Go(Direction.Up));

        //    Console.WriteLine("\n* Right, Left, Left, Down");
        //    Direction[] directions = {
        //        Direction.Right, Direction.Left, Direction.Left, Direction.Down
        //    };

        //    foreach (string direction in (c.Go(directions))) Console.WriteLine(direction);

        //    Console.WriteLine("\n* LRL");
        //    foreach (string direction in (c.Go("LRL"))) Console.WriteLine(direction);

        //    Console.WriteLine("\n* xxxdR lyyLTyu");
        //    foreach (string direction in (c.Go("xxxdR lyyLTyu"))) Console.WriteLine(direction);
        //}
        static void TestElfsAndOrcs()
        {
    //        Console.WriteLine("HUNT TEST\n");
    //        var o = new Orc() { Name = "Gorbag", Rage = 7 };
    //        o.SayHi();
    //        for (int i = 0; i < 10; i++)
    //        {
    //            o.Hunt();
    //            o.SayHi();
    //        }

    //        Console.WriteLine("\nSING TEST\n");
    //        var e = new Elf("Legolas", agility: 2);
    //        e.SayHi();
    //        for (int i = 0; i < 10; i++)
    //        {
    //            e.Sing();
    //            e.SayHi();
    //        }

    //        Console.WriteLine("\nPOWER TEST\n");
    //        Creature[] creatures = {
    //    o,
    //    e,
    //    new Orc("Morgash", 3, 8),
    //    new Elf("Elandor", 5, 3)
    //};
    //        foreach (Creature creature in creatures)
    //        {
    //            Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
    //        }
        }
        static void TestValidators()
        {
            //Creature c = new Elf() { Name = "   Shrek    ", Level = 20 };
            //c.SayHi();
            //c.Upgrade();
            //Console.WriteLine(c.Info);

            //c = new Orc("  ", -5);
            //c.SayHi();
            //c.Upgrade();
            //Console.WriteLine(c.Info);

            //c = new Elf("  donkey ") { Level = 7 };
            //c.SayHi();
            //c.Upgrade();
            //Console.WriteLine(c.Info);

            //c = new Orc("Puss in Boots – a clever and brave cat.");
            //c.SayHi();
            //c.Upgrade();
            //Console.WriteLine(c.Info);

            //c = new Elf("a                            troll name", 5);
            //c.SayHi();
            //c.Upgrade();
            //Console.WriteLine(c.Info);

            //var a = new Animals() { Description = "   Cats " };
            //Console.WriteLine(a.Info);

            //a = new() { Description = "Mice           are great", Size = 40 };
            //Console.WriteLine(a.Info);
        }
        static void TestObjectsToString()
        {
            object[] myObjects = 
                {
                new Animals() { Description = "dogs"},
                new Birds { Description = "  eagles ", Size = 10 },
                new Elf("e", 15, -3),
                new Orc("morgash", 6, 4)
                };

            Console.WriteLine("\nMy objects:");
            foreach (var o in myObjects) Console.WriteLine(o);

            /*
                My objects:
                ANIMALS: Dogs <3>
                BIRDS: Eagles (fly+) <10>
                ELF: E## [10][0]
                ORC: Morgash [6][4]
            */
        }


        static void Main(string[] args)
        {
            //TESTS:

            Creature e = new Elf("Kerillian", 2, -1);
            Creature o = new Orc("Gorbag", rage: 12, level: 2);

            SmallSquareMap map = new SmallSquareMap(10);

            Point point = new Point(1,1);
            Point point2 = new Point(1,0);


            map.Add(o, point);
            map.Add(e, point2);
            Console.WriteLine(o.Position);
            o.Go(Direction.Down);
            Console.WriteLine(o.Position);
            o.Go(Direction.Down);
            Console.WriteLine(o.Position);

            Console.WriteLine(map.creaturesLocations[0]);

            foreach (string item in map.At(point2))
            {
                Console.WriteLine(item);
            }
        }
    }
}
