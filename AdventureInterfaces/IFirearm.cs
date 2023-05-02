namespace AdventureInterfaces {
    public interface IFirearm {

        public int Rounds { get; set; }
        public int ShotsPerEncounter { get; set; }
        public void Reload();

    }
}