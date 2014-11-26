using TweetSharp;

namespace Trendie.Core.ServiceAgent
{
    public interface ITweetSharpServiceAgent
    {
        TwitterTrends ListLocalTrendsFor(int Id);
        TwitterSearchResult Search(string query);
    }
}