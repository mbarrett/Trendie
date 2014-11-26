namespace Trendie.Core.Extensions
{
    public static class CountryExtensions
    {
        public static string ToFullname(this string country)
        {
            switch (country.ToLower())
            {
                case "uk":
                    return "United Kingdom";
                case "us":
                    return "United States";
                default:
                    return "Australia";
            }
        }

        public static int ToId(this string country)
        {
            switch (country.ToLower())
            {
                case "uk":
                    return 23424975;
                case "us":
                    return 23424977;
                default:
                    return 23424748;
            }
        }
    }
}