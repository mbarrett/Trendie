using Trendie.Core.Extensions;
using Trendie.Core.Models;
using TweetSharp;

namespace Trendie.Core.Mappers
{
    public class TrendMapper : ITrendMapper
    {
        public Trend Map(TwitterTrend trend)
        {
            return new Trend
                {
                    Name = trend.Name,
                    Href = trend.Name.ToHref()
                };
        }
    }
}