using AdventureInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureLibrary {
    public sealed class Webley : Weapon, IFirearm {
        private int _rounds;
        private int _shotsPerEncounter;

        public int Rounds {
            get { return _rounds; }
            set {
                _rounds = value < 0 ? 0 : value;
            }
        }
        public int ShotsPerEncounter {
            get { return _shotsPerEncounter; }
            set {
                _shotsPerEncounter = value > 6 ? 6 : value;
            }
        }
        public Webley() {
            Name = "Webley";
            Type = WeaponType.Webley;
            MaxDamage = 8;
            Special = SpecialAttack.One_shot_kill;
            Rounds = 60;
            ShotsPerEncounter = 6;
        }

        public void Reload() {
            if (Rounds + ShotsPerEncounter >= 6) {
                Rounds -= 6 - ShotsPerEncounter;
                ShotsPerEncounter = 6;
            }
            else {
                ShotsPerEncounter += Rounds;
                Rounds = 0;
            }
        }
    }
}
