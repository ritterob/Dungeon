using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdventureLibrary {
    public sealed class Boomstick : FireArm {

        public Boomstick()
        {
            Name = "Boomstick";
            Type = WeaponType.Boomstick;
            MaxDamage = 12;
            Special = SpecialAttack.One_shot_kill;
            Rounds = 25;
            ShotsPerEncounter = 1;

        }

    }
}
