using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureLibrary {
    public sealed class Webley : FireArm {
        public Webley() {
            Name = "Webley";
            Type = WeaponType.Webley;
            MaxDamage = 8;
            Special = SpecialAttack.One_shot_kill;
            Rounds = 60;
            ShotsPerEncounter = 6;
        }
    }
}
