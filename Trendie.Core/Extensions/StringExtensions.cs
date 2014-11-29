using System.Collections.Generic;
using System.Linq;

namespace Trendie.Core.Extensions
{
    public static class HrefExtensions
    {
        private static readonly Dictionary<string, string> UrlUnfriendlyCharsMap = new Dictionary<string, string>
			                                         {
														 {"#", string.Empty},
                                                         {"'", string.Empty},
				                                         {" ", string.Empty},
			                                         };

        public static string ToHref(this string value)
        {
            value = UrlUnfriendlyCharsMap
                .Keys
                .Aggregate(value, (current, key) => current
                    .Replace(key, UrlUnfriendlyCharsMap[key]));

            return value;
        } 
    }
}