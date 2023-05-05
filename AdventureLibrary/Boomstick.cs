using AdventureInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdventureLibrary {
    public sealed class Boomstick : Weapon, IFirearm {
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
                _shotsPerEncounter = value > 1 ? 1 : value;
            } 
        }
        public Boomstick()
        {
            Name = "Boomstick";
            Type = WeaponType.Boomstick;
            MaxDamage = 14;
            Special = SpecialAttack.One_shot_kill;
            Rounds = 25;
            ShotsPerEncounter = 2;

        }

        public void Reload() {
            ShotsPerEncounter += Rounds <= 0 ? 0 : 1 ;
            Rounds-- ;
        }
    }
}
