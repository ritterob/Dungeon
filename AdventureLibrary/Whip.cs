using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureLibrary {
    public sealed class Whip : Weapon {


        public Whip() {
            Name = "Whip";
            Type = WeaponType.Whip;
            MaxDamage = 7;
            Special = SpecialAttack.Extra_turn;
        }
    }

}
