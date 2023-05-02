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

            if (attacker.GetType() == typeof(Player)) {
                Player player = attacker as Player;
                (attackBonus, defendBonus) = GetRollBonuses(player);
                if (d20.Next(1,21) + attackBonus >= defender.ToHit) {
                    damage = d20.Next(1, player.Wielded.MaxDamage + 1) + attackBonus;
                    Console.WriteLine($"You hit the {defender.Name}, doing {damage} damage.");
                    defender.Life -= damage;
                }
            }
            else {
                (attackBonus, defendBonus) = GetRollBonuses((Player)defender);
                Monster monster = attacker as Monster;
                if (d20.Next(1,21) >= defender.ToHit + defendBonus) {
                    damage = d20.Next(1, monster.MaxDamage + 1) - defendBonus;
                    Console.WriteLine($"The {monster.Name} hits you, doing {damage} damage.");
                    defender.Life -= damage;
                }
            }



        }   // end method Attack()

        private static (int attack, int defend) GetRollBonuses (Player player) {
            int attack = player.Luck + player.Dexterity;
            attack += player.Wielded.GetType() == typeof(FireArm) ? player.Marksmanship : player.Strength;
            attack += player.Wielded.Type == player.ProficientWeapon ? player.Proficiency : 0;

            int defend = player.Luck + player.Dexterity + player.Strength;

            return (attack, defend);

        }   // end method GetRollBonuses()


    }
}
