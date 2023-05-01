using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureLibrary {
    public class Weapon {

        public string Name { get; set; }
        public WeaponType Type { get; set; }
        public int MaxDamage { get; set; }
        public SpecialAttack Special { get; set; }


        public Weapon(){}

        public override string ToString() {
            return Name;
        }

    }   // class Weapon

}   // end namespace
