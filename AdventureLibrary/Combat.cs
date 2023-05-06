using AdventureInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureLibrary {
    public static class Combat {

        public static bool IsSpecialAttack = false;

        public static void DoAttack(Character attacker, Character defender, bool getBonus) {

            int attackBonus = 0, defendBonus = 0, damage = 0, hitRoll = 0;
            Random d20 = new Random();

            if (attacker is Player) {   // order is player, monster
                Player player = attacker as Player;

                if (getBonus) {
                    (attackBonus, defendBonus) = GetRollBonuses(player);
                }
                hitRoll = d20.Next(1, 21) + attackBonus;
                if (hitRoll >= defender.ToHit) {
                    damage = d20.Next(1, player.Wielded.MaxDamage + 1) + attackBonus;
                    Message.Warning($"You hit the {defender.Name}, doing {damage} damage.");
                    defender.Life -= damage;
                    if (hitRoll >= 24 && IsSpecialAttack == false) {    // critical hit
                        IsSpecialAttack = true;
                        switch (player.Wielded.Special) {
                            case SpecialAttack.Extra_turn:
                                if (player.Wielded.Type == WeaponType.Pair_of_Knives) {
                                    Console.WriteLine("" +
                                        "You're in the zone and you go for another attack!");
                                }
                                else if (player.Wielded.Type == WeaponType.Whip) {
                                    Console.WriteLine("" +
                                        $"The {defender} gets entangled in your whip and can't " +
                                        $"counter attack right away!");
                                }
                                DoAttack(player, defender, getBonus);
                                break;
                            case SpecialAttack.Extra_damage:
                                Console.WriteLine("You made a really bloody mess of that one.");
                                defender.Life -= d20.Next(1,6);
                                break;
                            case SpecialAttack.One_shot_kill:
                                Console.WriteLine("That was a great headshot!");
                                defender.Life = 0;
                                break;
                        }   // end switch
                    }   // end inner if
                }
                else {
                    Console.WriteLine("You missed the {0}.", defender);
                }

                if (player.Wielded is IFirearm) {
                    (player.Wielded as IFirearm).ShotsPerEncounter--;
                    if ((player.Wielded as IFirearm).ShotsPerEncounter <= 0) {
                        player.SwapWeapon();
                    }
                }
            }
            else {  // order is monster, player
                (attackBonus, defendBonus) = GetRollBonuses((Player)defender);
                Monster monster = attacker as Monster;
                if (d20.Next(1,21) >= defender.ToHit + defendBonus) {
                    damage = d20.Next(4, monster.MaxDamage + 1) - defendBonus;
                    damage = damage < 0 ? 0 : damage;
                    Message.Danger($"The {monster.Name} hits you, doing {damage} damage.");
                    defender.Life -= damage;
                }
                else {
                    Console.WriteLine("The {0} misses.", monster);
                }
            }

            IsSpecialAttack = false;

        }   // end method DoAttack()

        public static void DoCombat(Player player, Monster monster, bool getBonus) {

            DoAttack(player, monster, getBonus);
            if (monster.Life <= 0) {
                Message.Huzzah($"You killed the {monster.Name}!");
                return;
            }
            //Console.WriteLine("The {0} has {1} health.", monster.Name, monster.Life);

            DoAttack(monster, player, getBonus);
            if (player.Life <= 0) {
                Console.WriteLine("The {0} got the best of you!", monster.Name);
                return;
            }
            //Console.WriteLine("You have {0} health.", player.Life);
        }

        private static (int attack, int defend) GetRollBonuses (Player player) {
            int attack = player.Luck + player.Dexterity;
            attack += player.Wielded.GetType() is IFirearm ? player.Marksmanship : player.Strength;
            attack += player.Wielded.Type == player.ProficientWeapon ? player.Proficiency : 0;

            int defend = player.Luck + player.Dexterity + player.Strength;

            return (attack, defend);

        }   // end method GetRollBonuses()


    }
}
