using AdventureLibrary;

namespace Dungeon {

    public class TestHarness {

        static void Main(string[] args) {

            Player player = null;
            Random d20 = new Random();
            Console.Write("Please select a character: ");
            int selection = int.Parse(Console.ReadLine());
            Console.WriteLine((Protagonist)selection);
            switch ((Protagonist)selection) {
                case Protagonist.Indy:
                    player = new("Indy", 2, 1, 2, 1, 2, (new List<WeaponType> {
                        WeaponType.Whip, WeaponType.Webley }), WeaponType.Whip);
                    break;
                case Protagonist.Lara:
                    player = new("Lara", 1, 1, 2, 0, 1, (new List<WeaponType> {
                        WeaponType.Pair_of_Knives, WeaponType.Webley}), WeaponType.Pair_of_Knives);
                    break;
                case Protagonist.Allan:
                    player = new("Allan", 2, 2, 2, 3, 1, (new List<WeaponType> {
                        WeaponType.Whip, WeaponType.Webley}), WeaponType.Webley);
                    break;
                case Protagonist.Harry:
                    player = new("Harry", 0, 5, 1, 0, 0, (new List<WeaponType> {
                        WeaponType.Whip, WeaponType.Boomstick}), WeaponType.Whip);
                    break;

            }   // end switch
            
            Console.WriteLine("{0} has {1} life and is carrying a {2}.", 
                    player.Name, player.Life, player.Wielded);
            Console.WriteLine("{0} is carrying {1} weapons.", player.Name, player.Arms.Count);

            Monster monster = new Monster (MonsterType.Jaguar,
                    d20.Next(7,11), d20.Next(5,9));
            Console.WriteLine(monster);

        }   // end method Main()

    }   // end class TestHarness


}   // end namespace Dungeon