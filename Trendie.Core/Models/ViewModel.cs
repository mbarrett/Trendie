using System.Collections.Generic;

namespace Trendie.Core.Models
{
    public class ViewModel
    {
        public string Country { get; set; }
        public string CountryName { get; set; }
        public Dictionary<Trend, List<Tweet>> TrendResults { get; set; }
    }
}