using System;
using NSubstitute;
using NUnit.Framework;
using Trendie.Core.Cache;
using Trendie.Core.Extensions;
using Trendie.Core.Repositories;
using Trendie.Core.ServiceAgents;
using TweetSharp;

namespace Trendie.UnitTests.Repositories
{
    public class TwitterRepositoryTests
    {
        [TestFixture]
        public class when_getting_top_trends_for_a_country : given_a_twitter_repository 
        {
            protected TwitterTrends _outcome;
         
            [SetUp]
            public new void Setup()
            {
                given_a_country();
                given_cached_twitter_trends();

                _outcome = _subject.GetTopTrendsFor(_country);
            }

            [Test]
            public void should_return_cached_twitter_trends()
            {
                Assert.That(_outcome.RawSource, Is.EqualTo(_cachedTwitterTrends.RawSource));
            }
        }

        [TestFixture]
        public class when_getting_tweets_for_a_trend : given_a_twitter_repository
        {
            private TwitterSearchResult _outcome;

            [SetUp]
            public new void Setup()
            {
                given_a_trend();
                given_cached_tweet_search_results();

                _outcome = _subject.GetTweetsFor(_trend, _country);
            }

            [Test]
            public void should_return_cached_tweet_search_results()
            {
                Assert.That(_outcome, Is.EqualTo(_cachedTweetSearchResults));
            }
        } 
    }

    public class given_a_twitter_repository
    {
        protected TwitterRepository _subject;
        private IWebCache _webCache;
        private ITweetSharpServiceAgent _tweetSharpServiceAgent;
        protected string _country;
        protected TwitterTrends _cachedTwitterTrends;
        protected TwitterTrend _trend;
        protected TwitterSearchResult _cachedTweetSearchResults;

        [SetUp]
        public void Setup()
        {
            _webCache = Substitute.For<IWebCache>();
            _tweetSharpServiceAgent = Substitute.For<ITweetSharpServiceAgent>();

            _subject = new TwitterRepository(_webCache, _tweetSharpServiceAgent);
        }

        protected void given_a_country()
        {
            _country = "uk";
        }

        protected void given_cached_twitter_trends()
        {
            var cacheKey = string.Format("trends_{0}", _country.ToId());
            _cachedTwitterTrends = new TwitterTrends {RawSource = "trendshere"};

            _webCache.Get(cacheKey,
                          Arg.Any<Func<TwitterTrends>>(), 5)
                     .Returns(_cachedTwitterTrends);
        }

        protected void given_cached_tweet_search_results()
        {
            var cacheKey = string.Format("tweets_{0}_{1}", _trend.Query, _country);
            _cachedTweetSearchResults = new TwitterSearchResult {RawSource = "tweetshere"};

            _webCache.Get(cacheKey,
                          Arg.Any<Func<TwitterSearchResult>>(), 5)
                     .Returns(_cachedTweetSearchResults);
        }

        protected void given_a_trend()
        {
            _trend = new TwitterTrend { Query = "#trend" };
        }
    }
}