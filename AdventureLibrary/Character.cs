namespace AdventureLibrary {
    public abstract class Character {

        // fields
        private int _maxLife;

        // properties
        public string Name { get; set; }
        public int MaxLife { 
            get { return _maxLife;} 
            set { _maxLife = value < 1 ? 1 : value;} 
        }
        public int Life { get; set; }
        public int ToHit { get; set; }

        // ctors
        public Character(string name, int maxLife, int toHit) {
            Name = name;
            Life = MaxLife = maxLife;
            ToHit = toHit;
        }

        // methods

        public override string ToString() {
            return $"{Name} has {Life} of {MaxLife} life left.";
        }

    }   // end class Character

}   // end namespace
