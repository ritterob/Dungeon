namespace AdventureLibrary;
public abstract class Character {

    #region  Fields

    private int _maxLife;

    #endregion

    #region Properties

    public int MaxLife { 
        get { return _maxLife;} 
        set { _maxLife = value < 1 ? 1 : value;} 
    }
    public int Life { get; set; }

    #endregion

    #region Constructors

    public Character(int maxLife) {
        Life = MaxLife = maxLife;
    }

    #endregion

    #region Methods

    #endregion

}   // end class Character
