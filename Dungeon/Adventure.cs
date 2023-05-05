using AdventureInterfaces;
using AdventureLibrary;
using System.Text.RegularExpressions;

namespace Dungeon {

    public class Adventure {

        private static Random D20 = new Random();

        static void Main(string[] args) {

            #region Variable Declaration

            string choice = String.Empty, action = String.Empty;
            string[] adjectives = new string[] {
                "angry", "annoyed", "antogonistic", "aloof", "acrimoniuous",
                "enraged", "exasperated", "estranged",
                "irate", "irked", "indignant", "irascible", "inhospitable",
                "offended", "outraged",
                "unfriendly", "uptight", "uncharitable"
            };
            Player player = null;
            //IFirearm gun = null;
            Place place = Place.Jungle;
            bool gameOver = false;
            int lastLoop = D20.Next(3,6);

            #endregion

            #region Player Selection
            // TODO Display info so user can choose a character to play.

            for (int i = 1; i <= 4; i++) {  // Give the user four chances to provide a valid value.
                Console.Write("Select your character: ");
                choice = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine($"\t{choice}");

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

            int selection = int.Parse(choice);  // Instantiate the selected player character.
            switch ((Protagonist)selection) {
                case Protagonist.Indy:
                    player = new("Indy", 2, 1, 2, 1, 2, new List<Weapon> {
                        new Whip(), new Webley() }, WeaponType.Whip);
                    break;
                case Protagonist.Lara:
                    player = new("Lara", 1, 1, 2, 0, 2, new List<Weapon> {
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

            Console.Clear();
            Console.WriteLine("You have chosen to play as {0}. You currently have {1} " +
                "health.\nYou're carrying the following: {2}.\nYou're wielding the {3}, " +
                "which is{4} your most practiced weapon.", 
                player, player.Life, String.Join(", ", player.Arms), player.Wielded,
                player.Wielded.Type == player.ProficientWeapon ? "" : " not");
            Console.Write("\nPress enter to continue...");
            Console.ReadLine();
            Console.Clear();
            var gun = player.Arms.First(x => x is IFirearm) as IFirearm;

            #endregion

            #region Main Game Loop

            while (!gameOver) {  // turn loop

                Console.Clear();
                gun.Reload();
                DisplayStats(player, place);

                // Check to see if player needs healing, and roll for health.
                if ((player.Life < player.MaxLife - 5 && D20.Next(20) > 11 - player.Luck) ||
                        (player.Life < player.MaxLife - 3 && D20.Next(20) > 14 - player.Luck)) {
                    player.Life += (player.MaxLife - player.Life) / 3;
                    Message.Info("You feel a bit better.\n");
                }
                else if (player.Life < player.MaxLife && D20.Next(20) > 17 - player.Luck) {
                    player.Life++;
                    Message.Info("You feel a little bit better.\n");
                }

                // Check to see if player discovers the Necropolis. The likelihood increases
                // as the game progresses.
                if (player.HasIdol == false && place == Place.Jungle) {
                    if ((player.Encounters > 20 && D20.Next(20) > 4) ||
                        (player.Encounters > 15 && D20.Next(20) > 11) ||
                        (player.Encounters > 10 && D20.Next(20) > 18)) {
                        place = Place.Necropolis;
                        Message.Reverse("You've discovered the Necropolis!\n");
                    }
                }

                // "Room" descriptions.
                if (place == Place.Jungle) {
                    switch (D20.Next(7)) {
                        case 0:
                            Console.WriteLine("You're walking through a jungle clearing. The break\n" +
                                "in the canopy reveals an oasis of bright blue in the otherwise\n" +
                                "dark rain forest.");
                            break;
                        case 1:
                            Console.WriteLine("You've found you're way into a muddy swamp. Things are\n" +
                                "moving about your feet. Slimy, unnerving things.");
                            break;
                        case 2:
                            Console.WriteLine("The air grows still and dark as you enter the thickest\n" +
                                "part of the jungle.");
                            break;
                        case 3:
                            Console.WriteLine("A little stream meanders on its way inexorably toward\n" +
                                "the mighty Amazon.");
                            break;
                        case 4:
                            Console.WriteLine("The canopy high above is filled with the sounds of \n" +
                                "buzzing insects and other jungle life.");
                            break;
                        case 5:
                            Console.WriteLine("The beasts in the dark underside of the jungle canopy\n" +
                                "seem to be crying out for mates — or meals.");
                            break;
                        case 6:
                            Console.WriteLine("The thick greenery above blocks out most of the sunlight\n" +
                                "leaving the jungle floor in constant twilight.");
                            break;
                    }   // end switch
                }
                else {
                    Console.WriteLine("You tread softly among the dead in the Necropolis.");
                    lastLoop--;
                    if (lastLoop <= 0) {
                        Message.Reverse("\nYou've discovered the idol!");
                        player.HasIdol = true;
                        place = Place.Jungle;
                        Console.Write("\nPress enter to continue...");
                        Console.ReadLine();
                        continue;
                    }
                }

                if (D20.Next(20) >= 18) {    // There's a chance that you won't encounter an enemy.
                    Console.Write("\nPress enter to continue...");
                    Console.ReadLine();
                    continue;
                }

                Monster monster = SelectMonster(player);    // Rival archaeologist is the boss.
                if (monster.Type == MonsterType.Rival_Archaeologist) {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine("\nYou encounter an {0} {1}!\n",
                    adjectives[D20.Next(adjectives.Length)], monster.Name);
                Console.ResetColor();
                // Roll for initiative...
                if (player.Wielded.Type != player.ProficientWeapon &&
                    D20.Next(20 + player.Luck + player.Dexterity) < D20.Next(20)) {
                    Combat.DoAttack(monster, player);
                }

                while (monster.Life > 0 && player.Life > 0) {   // combat loop

                    DisplayStats(player, place);
                    Console.Write("Do you want to (A)ttack,{0} (F)lee, or (Q)uit? ", 
                        (gun.Rounds <= 0 && gun.ShotsPerEncounter <= 0 ? "" : " (C)hange weapon,"));
                    action = Console.ReadKey().Key.ToString();
                    Console.WriteLine();

                    if (action.ToLower() == "f") {
                        Combat.DoAttack(monster, player);
                        break;
                    }
                    else if (action.ToLower() == "c" && gun.Rounds != 0 && gun.ShotsPerEncounter != 0) {
                        player.SwapWeapon();
                    }
                    else if (action.ToLower() == "q") {
                        Message.Danger("\n\nNobody likes a quitter, you know?\n\n");
                        gameOver = true;
                        break;
                    }
                    else if (action.ToLower() != "a") {
                        Console.WriteLine("Indecisiveness can be fatal in the jungle.");
                        Combat.DoAttack(monster, player);
                    }

                    Combat.DoCombat(player, monster);

                }   // end combat loop
                if (player.Life <= 0) {
                    gameOver = true;
                    Message.Danger("You died!");
                    Console.WriteLine("Well, we had a nice run. Don't worry, your corpse will\n" +
                        "provide much-needed nutrients for the recovering rainforest\n" +
                        "ecosystems. And your equipment may be of use to some future \n" +
                        "adventurer.\n\nNot that you'll care, much.\n\n~~ Sayonara! ~~");
                }
                else {
                    if (monster.Type == MonsterType.Rival_Archaeologist) {
                        gameOver = true;
                        Message.Reverse("Congratulations! You've succeeded in your quest!");
                        Console.WriteLine("You've managed to win the game with most of your limbs " +
                            "intact. This calls for a celebration!");
                    }
                    player.XP += monster.MaxLife;
                    player.Encounters++;
                    Console.WriteLine();
                    DisplayStats(player, place);
                    Console.Write("Press enter to continue...");
                    Console.ReadLine();
                }
            }   // end turn loop

            #endregion

        }   // end method Main()

        private static Monster SelectMonster(Player player) {
            // Return a random monster. Monsters get harder as the user progresses through
            // the game. If the user has retrieved the idol, there's a good chance that
            // they will run into Belloq.
            int monsterMod = 0, lifeMod = 0, hitMod = 0, damageMod = 0;

            if (player.HasIdol && D20.Next(20) > 10) {
                return new Monster(MonsterType.Rival_Archaeologist, D20.Next(24, 28),
                    D20.Next(12, 16), D20.Next(7, 13));
            }
            else if (player.XP > 230) {
                monsterMod = 2; lifeMod = 9; hitMod = 4; damageMod = 4;
            }
            else if (player.XP > 180) {
                monsterMod = 1; lifeMod = 7; hitMod = 3; damageMod = 3;

            }
            else if (player.XP > 130) {
                monsterMod = 1; lifeMod = 5; hitMod = 2; damageMod = 2;
            }
            else if(player.XP > 80) {
                lifeMod = 3; hitMod = 1; damageMod = 1;
            }
            return new Monster((MonsterType)D20.Next(6 + monsterMod),
                D20.Next(12, 18 + lifeMod), 
                D20.Next(9, 12 + hitMod), 
                D20.Next(7, 9 + damageMod));

        }   // end method SelectMonster()

        private static void DisplayStats(Player player, Place place) {

            string title = player.Name + " in the " + place + "  ";
            //string roundsInfo = String.Empty;
            var gun = player.Arms.First(x => x is IFirearm) as IFirearm;
            string roundsInfo = $"{gun.ShotsPerEncounter} / {gun.Rounds}";

            int lineNumber = Console.GetCursorPosition().Top;   // Save current cursor pos.
            lineNumber = lineNumber < 5 ? 5 : lineNumber;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);
            Console.Write(title);
            Console.WriteLine(new string('*', 41 - title.Length));

            Console.WriteLine("{0,-6}    {1,3}    {2,-6}    {3}          ", "Health", "XP", "Ammo",
                "Weapon in Hand");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("{0, 6}    {1,3}    {2,-6}    {3}          ", player.Life, player.XP,
                roundsInfo, player.Wielded);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('*', 41));
            Console.ResetColor();
            Console.WriteLine();
            Console.SetCursorPosition(0, lineNumber);   // Restore cursor pos.

        }   // end method DisplayStats()

    }   // end class Dungeon

    internal enum Place {
        Jungle,
        Necropolis
    }


}   // end namespace Dungeon