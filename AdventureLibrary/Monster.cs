namespace AdventureLibrary {

    public class Monster : Character {

        // properties
        public MonsterType Type { get; set; }
        public int MaxDamage { get; set; }

        // constructors
        public Monster (MonsterType type, int maxLife, int toHit, int maxDamage) 
            : base (type.ToString().Replace('_', ' '), maxLife, toHit) {
            Type = type;
            MaxDamage = maxDamage;
        }

        // methods
        public override string ToString() {
            return  Name;
        }

    }   // end class Monster

}   // end namespace AdventureLibrary