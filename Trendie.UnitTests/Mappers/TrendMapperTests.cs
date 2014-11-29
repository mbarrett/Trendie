using NUnit.Framework;
using Trendie.Core.Extensions;
using Trendie.Core.Mappers;
using Trendie.Core.Models;
using TweetSharp;

namespace Trendie.UnitTests.Mappers
{
    public class TrendMapperTests
    {
        [TestFixture]
        public class when_mapping_a_trend : given_a_trend_mapper
        {
            [SetUp]
            public new void Setup()
            {
                given_a_twitter_trend();
                _outcome = _subject.Map(_twitterTrend);
            }

            [Test]
            public void should_map_trend_name()
            {
                Assert.That(_outcome.Name, Is.EqualTo(_twitterTrend.Name));
            }

            [Test]
            public void should_map_trend_href()
            {
                Assert.That(_outcome.Href, Is.EqualTo(_twitterTrend.Name.ToHref()));
            }
        } 
    }

    public class given_a_trend_mapper
    {
        protected TrendMapper _subject;
        protected TwitterTrend _twitterTrend;
        protected Trend _outcome;

        [SetUp]
        public void Setup()
        {
            _subject = new TrendMapper();
        }

        protected void given_a_twitter_trend()
        {
            _twitterTrend = new TwitterTrend { Name = "#trendin'"};
        }
    }
}