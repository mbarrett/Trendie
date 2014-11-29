using System.Collections.Generic;
using Trendie.Core.Builders;

namespace Trendie.Core.Models
{
    public class ViewModel
    {
        public string Country { get; set; }
        public Dictionary<Trend, List<Tweet>> TrendResults { get; set; }
    }
}