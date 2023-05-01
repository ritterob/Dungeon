using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdventureLibrary {
    public sealed class PairOfKnives : Weapon {

        public PairOfKnives() {
            Name = "Pair of Knives";
            Type = WeaponType.Pair_of_Knives;
            MaxDamage = 8;
            Special = SpecialAttack.Extra_turn;
        }


    }
}
