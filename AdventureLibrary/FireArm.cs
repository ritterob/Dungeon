using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureLibrary {
    public abstract class FireArm : Weapon {
        public int Rounds { get; set; }
        public int ShotsPerEncounter { get; set; }

        public FireArm() {}
    }

    
}
