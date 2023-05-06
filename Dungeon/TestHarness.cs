using AdventureLibrary;
using System.Numerics;

namespace Dungeon {

    public class TestHarness {

        static void Main(string[] args) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new String(' ', 35) + "Welcome to an ARCHAEOLOGICAL");
            Console.WriteLine(GameInfo.Title);
            Console.WriteLine($"\n{new String(' ', 20)}Proudly released by GREEN SCREEN " +
                $"PRODUCTIONS, MMXXIII\n");
            Console.Write("Press a key to continue...");
            int y = Console.GetCursorPosition().Top;
            Console.ReadKey(true);
            Console.SetCursorPosition(0, y);
            Console.WriteLine(GameInfo.Intro);
            Console.Write("\nPress a key to continue...");
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine("You must choose which ARCHAEOLOGICAL ADVENTURER you will personify...");
            Console.Write("\nPress a key to continue...");
            y = Console.GetCursorPosition().Top;
            Console.ReadKey(true);
            Console.SetCursorPosition(0, y - 1);
            Console.WriteLine(GameInfo.Indy);
            Console.WriteLine(new String('-', 100));
            Console.WriteLine(GameInfo.Lara);
            Console.WriteLine(new String('-', 100));
            Console.WriteLine(GameInfo.Allan);
            Console.WriteLine(new String('-', 100));
            Console.WriteLine(GameInfo.Harry);
            Console.WriteLine(new String('-', 100));
            Console.Write("\nPress a key to continue...");
            Console.ReadKey(true);
            Console.Clear();
            Console.ResetColor();

            Player player = new("Dave", 0, 0, 0, 0, 0, new List<Weapon>{ new Machuahuitl()}, WeaponType.Machuahuitl);
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            while (Console.GetCursorPosition().Top < Console.WindowHeight - 11) {
                Console.WriteLine("\n");
                Console.SetCursorPosition(0, Console.GetCursorPosition().Top - 1);
            }
            Console.SetCursorPosition(0, Console.WindowHeight - 10);
            Message.Reverse("Congratulations! You've succeeded in your quest!");
            Console.Write("" +
                "You've managed to win the game with most of your limbs intact and a score " +
                $"of ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(player.XP);
            Console.ResetColor();
            Console.WriteLine(". This calls\nfor a celebration!");
            Thread.Sleep(2000);
            y = Console.GetCursorPosition().Top;
            for (int i = 0; i < 27; i++) {
                ConsoleColor color = Console.ForegroundColor;
                while (color == Console.ForegroundColor) {
                    color = GameInfo.Party[new Random().Next(GameInfo.Party.Length)];
                }
                Console.ForegroundColor = color;
                Console.WriteLine(GameInfo.Celebration);
                Thread.Sleep(333);
                Console.SetCursorPosition(0, y);
            }
            Console.ResetColor();
            Console.WriteLine();

            /*Player player = null;
            Random d20 = new Random();
            Console.Write("Please select a character: (1-4) ");
            int selection = int.Parse(Console.ReadLine());
            Console.WriteLine((Protagonist)selection);
            switch ((Protagonist)selection) {
                case Protagonist.Indy:
                    player = new("Indy", 2, 1, 2, 1, 2, new List<Weapon> {
                        new Whip(), new Webley() }, WeaponType.Whip);
                    break;
                case Protagonist.Lara:
                    player = new("Lara", 1, 1, 2, 0, 1, new List<Weapon> {
                        new PairOfKnives(), new Webley()}, WeaponType.Pair_of_Knives);
                    break;
                case Protagonist.Allan:
                    player = new("Allan", 2, 2, 2, 3, 1, new List<Weapon> {
                       new Whip(), new Webley()}, WeaponType.Webley);
                    break;
                case Protagonist.Harry:
                    player = new("Harry", 0, 5, 1, 0, 0, new List<Weapon> {
                        new Whip(), new Boomstick()}, WeaponType.Whip);
                    break;

            }   // end switch
            
            Console.WriteLine("{0} has {1} life and is wielding a {2}.", 
                    player.Name, player.Life, player.Wielded);
            Console.WriteLine("{0} {1} wielding their best weapon.", player.Name,
                    player.Wielded.Type == player.ProficientWeapon ? "is" : "isn't");
            Console.Write("{0} is carrying the following: ", player.Name);
            foreach (Weapon item in player.Arms) {
                string sep = item != player.Arms[player.Arms.Count - 1] ?  ", " : " ";
                Console.Write(item.Name + sep);
            }

            Console.WriteLine();
            Monster monster = new Monster ((MonsterType)d20.Next(1,6),
                    d20.Next(12,18), d20.Next(7,12), d20.Next(1,7));
            Console.WriteLine(monster);

            while (monster.Life > 0 && player.Life > 0) {
                Console.WriteLine();
                Console.WriteLine($"You attack with your {player.Wielded.Name}.");
                Combat.DoAttack(player, monster);
                Console.WriteLine($"Your life: {player.Life}\t{monster.Name}'s life: {monster.Life}");
                Console.WriteLine($"The {monster.Name} attacks!");
                Combat.DoAttack(monster, player);
                Console.WriteLine($"Your life: {player.Life}\t{monster.Name}'s life: {monster.Life}");
            }*/

        }   // end method Main()

    }   // end class TestHarness


}   // end namespace Dungeon