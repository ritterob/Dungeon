namespace AdventureLibrary;
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

    // ctors
    public Character(string name, int maxLife) {
        Name = name;
        Life = MaxLife = maxLife;
    }

    // methods

}   // end class Character
