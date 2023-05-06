using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdventureLibrary {
    public sealed class Machuahuitl : Weapon {

        public Machuahuitl() {
            Name = "Machuahuitl";
            Type = WeaponType.Machuahuitl;
            MaxDamage = 8;
            Special = SpecialAttack.Extra_damage;
        }


    }
}
