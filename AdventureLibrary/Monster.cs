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
            return  $"You encounter an angry {Name}. It has {Life} life left. You'll need at " +
                $"least {ToHit} to hit it.";
        }

    }   // end class Monster

}   // end namespace AdventureLibrary