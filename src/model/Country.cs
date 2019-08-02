namespace HangmanCSharp.model
{
    public class Country
    {
        public Country(string capitalName, string countryName)
        {
            CapitalName = capitalName;
            CountryName = countryName;
        }

        public string CapitalName { get; }
        public string CountryName { get; }

        public override string ToString()
        {
            return $"Country: {CountryName}, Capital: {CapitalName}";
        }
    }
}