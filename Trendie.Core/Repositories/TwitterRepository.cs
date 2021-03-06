﻿using TweetSharp;
using Trendie.Core.Cache;
using Trendie.Core.Extensions;
using Trendie.Core.ServiceAgents;

namespace Trendie.Core.Repositories
{
    public class TwitterRepository : ITwitterRepository
    {
        public const int CacheExpiry5Minutes = 5;

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
            var countryId = country.ToId();
            var cacheKey = string.Format("trends_{0}", countryId);

            return _webCache.Get(cacheKey,
                                 () =>
                                 _tweetSharpServiceAgent.ListLocalTrendsFor(countryId), CacheExpiry5Minutes);
        }

        public TwitterSearchResult GetTweetsFor(TwitterTrend trend, string country)
        {
            var cacheKey = string.Format("tweets_{0}_{1}", trend.Query, country);
            return _webCache.Get(cacheKey, 
                                    () =>
                                    _tweetSharpServiceAgent.Search(trend.Query, country), CacheExpiry5Minutes);
        }
    }
}

