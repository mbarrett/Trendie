using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Trendie.Core.Builders;
using Trendie.Core.Extensions;
using Trendie.Core.Mappers;
using Trendie.Core.Models;
using Trendie.Core.Repositories;
using TweetSharp;

namespace Trendie.UnitTests.Builders
{
    public class ViewModelBuilderTests
    {
        [TestFixture]
        public class when_building_a_viewmodel : given_a_viewmodel_builder
        {
            [SetUp]
            public new void Setup()
            {
                given_a_country();
                given_top_five_trends_for(_country);
                given_top_ten_tweets_for_trend();
                given_mapped_trend();
                given_mapped_tweets();

                _outcome = _subject.Build(_country);
            }

            [Test]
            public void should_return_the_country()
            {
                Assert.That(_outcome.Country, Is.EqualTo(_country));
            }
            
            [Test]
            public void should_return_the_country_name()
            {
                Assert.That(_outcome.CountryName, Is.EqualTo(_country.ToFullname()));
            }
            
            [Test]
            public void should_return_the_trend_results()
            {
                foreach (var trendResult in _outcome.TrendResults)
                {
                    Assert.That(trendResult.Key, Is.EqualTo(_mappedTrend));
                    Assert.That(trendResult.Value, Is.EqualTo(_mappedTweets));
                }
            }
        }
    }

    public class given_a_viewmodel_builder
    {
        protected ViewModelBuilder _subject;
        private ITwitterRepository _twitterRepository;
        protected string _country;
        protected ViewModel _outcome;
        private ITweetMapper _tweetMapper;
        protected IEnumerable<Tweet> _mappedTweets;
        protected Trend _mappedTrend;
        private ITrendMapper _trendMapper;
        private TwitterTrends _topFiveTrends;
        private TwitterSearchResult _topTenTweets;

        [SetUp]
        public void Setup()
        {
            _twitterRepository = Substitute.For<ITwitterRepository>();
            _tweetMapper = Substitute.For<ITweetMapper>();
            _trendMapper = Substitute.For<ITrendMapper>();

            _subject = new ViewModelBuilder(_twitterRepository, _tweetMapper, _trendMapper);
        }

        protected void given_a_country()
        {
            _country = "uk";
        }

        protected void given_top_five_trends_for(string country)
        {
            _topFiveTrends = new TwitterTrends();
            _twitterRepository.GetTopTrendsFor(_country).Returns(_topFiveTrends);
        }

        protected void given_top_ten_tweets_for_trend()
        {
            _topTenTweets = new TwitterSearchResult();
            _twitterRepository.GetTweetsFor(Arg.Any<TwitterTrend>()).Returns(_topTenTweets);
        }

        protected void given_mapped_trend()
        {
            _trendMapper.Map(Arg.Any<TwitterTrend>()).Returns(_mappedTrend);
        }

        protected void given_mapped_tweets()
        {
            _tweetMapper.Map(_topTenTweets).Returns(_mappedTweets);
        }
    }
}