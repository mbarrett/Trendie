using System;

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
                case "aus":
                    return "Australia";
                default:
                    throw new Exception(string.Format("Country name not found for '{0}'", country));
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
                case "aus":
                    return 23424748;
                default:
                    throw new Exception(string.Format("Country id not found for '{0}'", country));
            }
        }
    }
}