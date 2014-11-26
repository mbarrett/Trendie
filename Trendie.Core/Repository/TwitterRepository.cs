using TweetSharp;
using Trendie.Core.Cache;
using Trendie.Core.Extensions;
using Trendie.Core.ServiceAgent;

namespace Trendie.Core.Repository
{
    public class TwitterRepository : ITwitterRepository
    {
        public const int CacheExpiry15Minutes = 15;

        private readonly IWebCache _webCache;
        private readonly ITweetSharpServiceAgent _tweetSharpServiceAgent;

        public TwitterRepository(IWebCache webCache,
                                 ITweetSharpServiceAgent tweetSharpServiceAgent)
        {
            _webCache = webCache;
            _tweetSharpServiceAgent = tweetSharpServiceAgent;
        }

        public TwitterTrends GetTopTrendsFor(string country)
        {
            var cacheKey = string.Format("trends_{0}", country.ToId());
            return _webCache.Get(cacheKey,
                                 () =>
                                 _tweetSharpServiceAgent.ListLocalTrendsFor(country.ToId()), CacheExpiry15Minutes);
        }

        public TwitterSearchResult GetTweetsFor(TwitterTrend trend)
        {
            var cacheKey = string.Format("tweets_{0}", trend.Query);
            return _webCache.Get(cacheKey, 
                                    () => 
                                    _tweetSharpServiceAgent.Search(trend.Query), CacheExpiry15Minutes);
        }
    }
}

