using System.Collections.Generic;
using System.Linq;
using Trendie.Core.Mappers;
using Trendie.Core.Repositories;
using Trendie.Core.Extensions;
using Trendie.Core.Models;

namespace Trendie.Core.Builders
{
    public class ViewModelBuilder : IViewModelBuilder
    {
        private readonly ITwitterRepository _twitterRepository;
        private readonly ITweetMapper _tweetMapper;
        private readonly ITrendMapper _trendMapper;

        public ViewModelBuilder(ITwitterRepository twitterRepository,
                                ITweetMapper tweetMapper,
                                ITrendMapper trendMapper)
        {
            _twitterRepository = twitterRepository;
            _tweetMapper = tweetMapper;
            _trendMapper = trendMapper;
        }

        public ViewModel Build(string country)
        {
            var trendResults = new Dictionary<Trend, List<Tweet>>();
            var top5Trends = _twitterRepository.GetTopTrendsFor(country).Take(5);

            foreach (var trend in top5Trends)
            {
                var top10Tweets = _twitterRepository.GetTweetsFor(trend, country);

                trendResults.Add(_trendMapper.Map(trend),
                                 _tweetMapper.Map(top10Tweets).ToList());
            }

            return new ViewModel
                {
                    Country = country,
                    CountryName = country.ToFullname(),
                    TrendResults = trendResults
                };
        }
    }
}