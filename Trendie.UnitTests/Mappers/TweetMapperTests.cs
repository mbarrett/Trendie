using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Trendie.Core.Mappers;
using Trendie.Core.Models;
using TweetSharp;

namespace Trendie.UnitTests.Mappers
{
    public class TweetMapperTests
    {
        [TestFixture]
        public class when_mapping_tweets : given_a_tweet_mapper
        {
            [SetUp]
            public new void Setup()
            {
                given_a_twitter_search_results();

                _outcome = _subject.Map(_twitterSearchResult);
                _outcomeList = _outcome.ToList();
            }

            [Test]
            public void should_map_status_using_tweet_html()
            {
                for (int i = 0; i < _outcomeList.Count; i++)
                {
                    Assert.That(_outcomeList[i].Status, Is.EqualTo(_statusList[i].TextAsHtml));
                }
            }

            [Test]
            public void should_map_client_using_source()
            {
                for (int i = 0; i < _outcomeList.Count; i++)
                {
                    Assert.That(_outcomeList[i].Client, Is.EqualTo(_statusList[i].Source));
                }
            }

            [Test]
            public void should_map_profile_image_url_using_profile_image_url()
            {
                for (int i = 0; i < _outcomeList.Count; i++)
                {
                    Assert.That(_outcomeList[i].ProfileImageUrl, Is.EqualTo(_statusList[i].User.ProfileImageUrl));
                }
            }

            [Test]
            public void should_map_created_date_using_created_date()
            {
                for (int i = 0; i < _outcomeList.Count; i++)
                {
                    Assert.That(_outcomeList[i].CreatedDate, Is.EqualTo(_statusList[i].CreatedDate));
                }
            }
        }
    }

    public class given_a_tweet_mapper
    {
        protected TweetMapper _subject;
        protected TwitterSearchResult _twitterSearchResult;
        protected IEnumerable<Tweet> _outcome;
        protected List<Tweet> _outcomeList;
        protected List<TwitterStatus> _statusList;

        [SetUp]
        public void Setup()
        {
            _subject = new TweetMapper();
        }

        protected void given_a_twitter_search_results()
        {
            var statuses = new List<TwitterStatus>
                {
                    new TwitterStatus{ 
                        CreatedDate = DateTime.Now, 
                        Source = "iPhone app",
                        User = new TwitterUser { ScreenName = "screenname", ProfileImageUrl = "http://something/com/1.jpg"}
                    }
                };

            _twitterSearchResult = new TwitterSearchResult { Statuses = statuses };
            _statusList = _twitterSearchResult.Statuses.ToList();
        }
    }
}