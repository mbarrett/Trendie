using Trendie.Core.Models;
using TweetSharp;

namespace Trendie.Core.Mappers
{
    public interface ITrendMapper
    {
        Trend Map(TwitterTrend trend);
    }
}