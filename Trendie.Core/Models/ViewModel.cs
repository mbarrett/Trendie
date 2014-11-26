using System.Collections.Generic;

namespace Trendie.Core.Models
{
    public class ViewModel
    {
        public string Country { get; set; }
        public Dictionary<string, List<TweetResult>> TrendResults { get; set; }
    }
}