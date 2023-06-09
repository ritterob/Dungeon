using System.Numerics;

namespace AdventureLibrary {

    public class Player : Character {

        // properties
        public int Strength { get; set; }   // hit, block, and damage for 
                                            // melee attacks
        public int Dexterity { get; set; }  // hit, evade, and activate weapon 
                                            //special for all attacks
        public int Proficiency { get; set; }    // hit and activate weapon 
                                                // special for proficient 
                                                // weapon
        public int Marksmanship { get; set; }   // hit, damage, and activate 
                                                // weapon special for ranged 
                                                // attacks
        public int Luck { get; set; }   // modifies everything, including 
                                        // ability to detect and avoid traps
        public int XP { get; set; }
        public List<Weapon> Arms { get; set; }  // list of all weapons 
                                                    // carried
        public Weapon Wielded { get; set; } // weapon in hand
        public WeaponType ProficientWeapon { get; set; }
        public int Encounters { get; set; } // number of encounters so far
        public bool HasIdol { get; set; }   // determine whether you've found
                                            // the idol


        // constructors
        public Player (string name, int strength, int dexterity, 
                int proficiency, int marksmanship, int luck, 
                List<Weapon> arms, WeaponType proficientWeapon)
                : base (name, 35, 8) {
            Strength = strength;
            Dexterity = dexterity;
            Proficiency = proficiency;
            Marksmanship = marksmanship;
            Luck = luck;
            Arms = arms;
            XP = 0;
            Wielded = Arms[0];
            ProficientWeapon = proficientWeapon;
            Encounters = 0;
            HasIdol = false;
        }

        public void SwapWeapon() {
            Weapon notWielded = Arms.First(x => x != Wielded);
            Wielded = notWielded;
            Message.Info($"You're now wielding your {Wielded}.\n" +
            $"This is {(Wielded.Type == ProficientWeapon ? "" : " not ")}" +
            $"your most proficient weapon.");
        }


    }   // end class Player


}   // end namespace AdventureLibrary