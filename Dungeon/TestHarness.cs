using AdventureLibrary;

namespace Dungeon {

    public class TestHarness {

        static void Main(string[] args) {

            Player player = new("Indy", 2, 1, 2, 1, 2, (new WeaponType[] {WeaponType.Whip, WeaponType.Webley}));

            Console.WriteLine("{0} has {1} life and is carrying a {2}.", 
                    player.Name, player.Life, player.Wielded);

        }   // end method Main()

    }   // end class Dungeon

}   // end namespace Dungeon