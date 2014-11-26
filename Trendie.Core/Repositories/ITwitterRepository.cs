using TweetSharp;

namespace Trendie.Core.Repositories
{
    public interface ITwitterRepository
    {
        TwitterTrends GetTopTrendsFor(string country);
        TwitterSearchResult GetTweetsFor(TwitterTrend trends);
    }
}