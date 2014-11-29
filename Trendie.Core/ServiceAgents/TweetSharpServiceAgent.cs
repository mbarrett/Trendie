using System.Configuration;
using TweetSharp;

namespace Trendie.Core.ServiceAgents
{
    public class TweetSharpServiceAgent : ITweetSharpServiceAgent
    {
        private readonly ITwitterService _twitterService;

        public TweetSharpServiceAgent()
        {
            var consumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
            var consumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];

            _twitterService = new TwitterService(consumerKey, consumerSecret);
        }

        public TwitterTrends ListLocalTrendsFor(int id)
        {
            Authenticate();

            return _twitterService.ListLocalTrendsFor(new ListLocalTrendsForOptions
                {
                    Id = id
                });
        }

        public TwitterSearchResult Search(string query)
        {
            Authenticate();

            return _twitterService.Search(new SearchOptions
                {
                    Resulttype = TwitterSearchResultType.Recent,
                    Q = query,
                    Count = 10,
                    IncludeEntities = false
                });
        }

        private void Authenticate()
        {
            var tokenKey = ConfigurationManager.AppSettings["TokenKey"];
            var tokenSecret = ConfigurationManager.AppSettings["TokenSecret"];

            _twitterService.AuthenticateWith(tokenKey, tokenSecret);
        }
    }
}