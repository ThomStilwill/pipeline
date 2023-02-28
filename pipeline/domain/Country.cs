namespace pipeline.domain
{
    public class Country: Enumeration<Country.Keys>
    {
        public enum Keys
        {
            UnitedStates,
            UnitedKingdom,
            Ireland,
            Germany,
            France,
            Holland,
            Spain,
            Italy
        }

        public static Country UnitedStates = new(Keys.UnitedStates,"US");
        public static Country UnitedKingdom = new(Keys.UnitedKingdom,"UK","Great Britain");
        public static Country Ireland = new(Keys.Ireland);
        public static Country Germany = new(Keys.Germany);

        public Country() { }
        public Country(Keys key) : base(key) { }
        public Country(Keys key, string value) : base(key, value) { }
        public Country(Keys key, string value, string display) : base(key, value, display) { }
        
    }
}
