namespace AdventureLibrary {

    public class Player : Character {

        #region Fields

        #endregion

        #region Properties

        public int Strength { get; set; }   // hit, evade, and damage for melee attacks
        public int Dexterity { get; set; }  // hit, evade, and activate weapon special for all attacks
        public int Proficiency { get; set; }    // hit and activate weapon special for proficient weapon
        public int Marksmanship { get; set; }   // hit, damage, and activate weapon special for ranged attacks
        public int Luck { get; set; }   // modifies everything, including ability to detect and avoid traps
        //TODO define weapons class so we can set weapon here
        //public Weapon Wielded { get; set; }
        //public Weapon[3] Arms // - all weapons carried (up to three)
        public WeaponType[] Arms { get; set; }
        public WeaponType Wielded { get; set; }
        public int Encounters { get; set; }
        public bool HasIdol { get; set; }

        #endregion

        #region Constructors

        public Player (string name, int strength, int dexterity, int proficiency, int marksmanship, 
                int luck, WeaponType[] arms)
                : base (name, 35) {
            Strength = strength;
            Dexterity = dexterity;
            Proficiency = proficiency;
            Marksmanship = marksmanship;
            Luck = luck;
            Arms = arms;
            Wielded = Arms[0];
            Encounters = 0;
            HasIdol = false;
        }

        #endregion

        #region Methods

        #endregion

    }   // end class Player

}   // end namespace AdventureLibrary