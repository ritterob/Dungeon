namespace AdventureLibrary {

    public class Monster : Character {

        // properties
        public MonsterType Type { get; set; }

        // constructors
        public Monster (MonsterType type, int maxLife, int toHit) 
            : base (type.ToString().Replace('_', ' '), maxLife, toHit) {
            Type = type;
        }

        // methods
        public override string ToString() {
            return  $"You encounter a {Name}. It has {Life} life left. You'll need at least " +
                    $"a {ToHit} to hit it.";
        }

    }   // end class Monster

}   // end namespace AdventureLibrary