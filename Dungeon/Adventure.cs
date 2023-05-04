using AdventureLibrary;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Threading;

namespace Dungeon {

    public class Adventure {

        static void Main(string[] args) {
            string choice = String.Empty;
            Player player = null;
            Random d20 = new Random();
            bool gameOver = false;

            #region Player Selection
            // TODO Display info so user can choose a character to play.

            for (int i = 1; i <= 4; i++) {
                Console.Write("Select your character: ");
                choice = Console.ReadLine();
                if (new Regex("^[1234]$").IsMatch(choice)) { break; }
                switch (i) {
                    case 1:
                        Console.WriteLine("Only one of the four greatest adventurers of all " +
                            "time can survive this trial.");
                        break;
                    case 2:
                        Console.WriteLine("Really, just one of the four. That's all.");
                        break;
                    case 3:
                        Console.WriteLine("You seem to be missing the point. Valid values are " +
                            "the numbers 1 through 4.");
                        break;
                    case 4:
                        Console.WriteLine("Okay, so you're probably not bright enough to succeed " +
                            "at this quest. Perhaps another time.");
                        return;
                }
            }

            int selection = int.Parse(choice);
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

            Console.WriteLine("You have chosen to play as {0}. You currently have {1} " +
                "health.\nYou're carrying the following: {2}.\nYou're wielding the {3}, " +
                "which is{4} your most practiced weapon.", 
                player.Name, player.Life, String.Join(", ", player.Arms), player.Wielded,
                player.Wielded.Type == player.ProficientWeapon ? "" : " not");

            #endregion

            #region Main Game Loop

            Monster monster = SelectMonster(player);
            while (monster.Life > 0 && player.Life > 0) {
                Combat.DoCombat(player, monster);
                Console.ReadLine();
            }

            #endregion

        }   // end method Main()

        private static Monster SelectMonster(Player player) {
            // Return a random monster. Monsters get harder as the user progresses through
            // the game. If the user has retrieved the idol, there's a good chance that
            // they will run into Belloq.
            Random d20 = new Random();
            int monsterMod = 0, lifeMod = 0, hitMod = 0, damageMod = 0;

            if (player.HasIdol && d20.Next(20) > 1) {
                return new Monster(MonsterType.Belloq, d20.Next(23, 28),
                    d20.Next(12, 15), d20.Next(6, 11));
            }
            else if (player.Encounters > 6 && player.Encounters < 13) {
                lifeMod = 3; hitMod = 1; damageMod = 1;
            }
            else if(player.Encounters >= 13) {
                monsterMod = 1; lifeMod = 5; hitMod = 2; damageMod = 2;
            }
            return new Monster((MonsterType)d20.Next(1, 6 + monsterMod),
                d20.Next(12, 18 + lifeMod), 
                d20.Next(7, 12 + hitMod), 
                d20.Next(1, 7 + damageMod));

        }   // end method SelectMonster()

    }   // end class Dungeon


}   // end namespace Dungeon