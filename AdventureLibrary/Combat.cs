﻿using AdventureInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureLibrary {
    public static class Combat {

        public static void DoAttack(Character attacker, Character defender) {

            int attackBonus = 0, defendBonus = 0, damage = 0;
            Random d20 = new Random();

            if (attacker is Player) {
                Player player = attacker as Player;
                (attackBonus, defendBonus) = GetRollBonuses(player);
                if (d20.Next(1,21) + attackBonus >= defender.ToHit) {
                    damage = d20.Next(1, player.Wielded.MaxDamage + 1) + attackBonus;
                    Console.WriteLine($"You hit the {defender.Name}, doing {damage} damage.");
                    defender.Life -= damage;
                }
                else {
                    Console.WriteLine("You missed the {0}.", defender.Name);
                }
            }
            else {
                (attackBonus, defendBonus) = GetRollBonuses((Player)defender);
                Monster monster = attacker as Monster;
                if (d20.Next(1,21) >= defender.ToHit + defendBonus) {
                    damage = d20.Next(1, monster.MaxDamage + 1) - defendBonus;
                    damage = damage < 0 ? 0 : damage;
                    Console.WriteLine($"The {monster.Name} hits you, doing {damage} damage.");
                    defender.Life -= damage;
                }
                else {
                    Console.WriteLine("The {0} misses.", monster.Name);
                }
            }



        }   // end method DoAttack()

        public static void DoCombat(Player player, Monster monster) {
            Random d20 = new Random();
            // Roll for initiative...
            if (player.Wielded.Type != player.ProficientWeapon &&
                d20.Next(20 + player.Luck + player.Dexterity) < d20.Next(20)) {
                goto monsterInitiative;
            }

            DoAttack(player, monster);
            if (monster.Life <= 0) {
                Console.WriteLine("You killed the {0}!", monster.Name);
                return;
            }
            Console.WriteLine("The {0} has {1} health.", monster.Name, monster.Life);

        monsterInitiative:
            DoAttack(monster, player);
            if (player.Life <= 0) {
                Console.WriteLine("The {0} got the best of you!", monster.Name);
                return;
            }
            Console.WriteLine("You have {0} health.", player.Life);
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
