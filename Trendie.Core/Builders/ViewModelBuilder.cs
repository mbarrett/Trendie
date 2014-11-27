using System.Collections.Generic;
using System.Linq;
using Trendie.Core.Repositories;
using TweetSharp;
using Trendie.Core.Extensions;
using Trendie.Core.Models;

namespace Trendie.Core.Builders
{
    public class ViewModelBuilder : IViewModelBuilder
    {
        private readonly ITwitterRepository _twitterRepository;
        
        public ViewModelBuilder(ITwitterRepository twitterRepository)
        {
            _twitterRepository = twitterRepository;
        }

        public ViewModel Build(string country)
        {
            var trendResults = new Dictionary<Trend, List<TweetResult>>();
            var top5Trends = _twitterRepository.GetTopTrendsFor(country).Take(5);

            foreach (var trend in top5Trends)
            {
                var twitterTrend = new Trend {Name = trend.Name, LinkedName = trend.Name.ToSafeString()};
                var top10Tweets = _twitterRepository.GetTweetsFor(trend);

                trendResults.Add(twitterTrend, MapTweetFields(top10Tweets));
            }

            return new ViewModel
                {
                    Country = country.ToFullname(),
                    TrendResults = trendResults
                };
        }

        private static List<TweetResult> MapTweetFields(TwitterSearchResult top10Tweets)
        {
            return top10Tweets.Statuses.Select(tweet => new TweetResult
                {
                    Status = tweet.TextAsHtml,
                    Author = tweet.Author.ScreenName,
                    Client = tweet.Source,
                    ProfileImageUrl = tweet.Author.ProfileImageUrl,
                    CreatedDate = tweet.CreatedDate
                }).ToList();
        }
    }

    public class Trend
    {
        public string Name { get; set; }
        public string LinkedName { get; set; }
    }
}