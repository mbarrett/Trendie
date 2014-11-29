using System.Collections.Generic;
using Trendie.Core.Models;
using TweetSharp;

namespace Trendie.Core.Mappers
{
    public interface ITweetMapper
    {
        List<Tweet> Map(TwitterSearchResult tweets);
    }
}