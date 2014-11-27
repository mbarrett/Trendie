using TweetSharp;

namespace Trendie.Core.ServiceAgents
{
    public class TweetSharpServiceAgent : ITweetSharpServiceAgent
    {
        private const string ConsumerKey = "StNb9l4CwGevdEEOfBa8Qwcjc";
        private const string ConsumerSecret = "A9GjWy3paA48AQo2UBwBppsv6uX3iCWdSuu5RDgHX7TNaZu4fx";
        private const string TokenKey = "1591448186-jImYcBViaQGNZt8PnFujNAOu0DPTTjfXnHjNXiY";
        private const string TokenSecret = "v33sJs5lxWcsxzW1PlWLh7yMrjEXGo3IUhdMjTlDFg6Nn";

        private readonly TwitterService _service = new TwitterService(ConsumerKey, ConsumerSecret);

        public TwitterTrends ListLocalTrendsFor(int id)
        {
            Authenticate();

            return _service.ListLocalTrendsFor(new ListLocalTrendsForOptions
                {
                    Id = id
                });
        }

        public TwitterSearchResult Search(string query)
        {
            Authenticate();

            return _service.Search(new SearchOptions
                {
                    Resulttype = TwitterSearchResultType.Recent,
                    Q = query,
                    Count = 10,
                    IncludeEntities = false
                });
        }

        private void Authenticate()
        {
            _service.AuthenticateWith(TokenKey, TokenSecret);
        }
    }
}