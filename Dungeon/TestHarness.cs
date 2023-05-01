using AdventureLibrary;

namespace Dungeon {

    public class TestHarness {

        static void Main(string[] args) {

            Player player = null;
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
            Monster monster = new Monster ((MonsterType)d20.Next(1,7),
                    d20.Next(7,11), d20.Next(7,12));
            Console.WriteLine(monster);

        }   // end method Main()

    }   // end class TestHarness


}   // end namespace Dungeon