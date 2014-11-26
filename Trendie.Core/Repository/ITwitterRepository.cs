using TweetSharp;

namespace Trendie.Core.Repository
{
    public interface ITwitterRepository
    {
        TwitterTrends GetTopTrendsFor(string country);
        TwitterSearchResult GetTweetsFor(TwitterTrend trends);
    }
}