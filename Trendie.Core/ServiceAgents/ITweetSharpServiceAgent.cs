using TweetSharp;

namespace Trendie.Core.ServiceAgents
{
    public interface ITweetSharpServiceAgent
    {
        TwitterTrends ListLocalTrendsFor(int Id);
        TwitterSearchResult Search(string query, string country);
    }
}