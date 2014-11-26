using System.Collections.Generic;
using System.Linq;
using TweetSharp;
using Trendie.Core.Extensions;
using Trendie.Core.Models;
using Trendie.Core.Repository;

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
            var trendResults = new Dictionary<string, List<TweetResult>>();
            var top5Trends = _twitterRepository.GetTopTrendsFor(country).Take(5);

            foreach (var trend in top5Trends)
            {
                var top10Tweets = _twitterRepository.GetTweetsFor(trend);
                trendResults.Add(trend.Name, MapTweetFields(top10Tweets));
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
                    TweetStatus = tweet.TextAsHtml,
                    TweetAuthor = tweet.Author.ScreenName,
                    TweetClient = tweet.Source,
                    TweetPicture = tweet.Author.ProfileImageUrl
                }).ToList();
        }
    }
}