using System.Collections.Generic;
using Trendie.Core.Models;
using TweetSharp;

namespace Trendie.Core.Mappers
{
    public interface ITweetMapper
    {
        IEnumerable<Tweet> Map(TwitterSearchResult tweets);
    }
}