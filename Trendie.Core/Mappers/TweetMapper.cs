﻿using System.Collections.Generic;
using System.Linq;
using Trendie.Core.Models;
using TweetSharp;

namespace Trendie.Core.Mappers
{
    public class TweetMapper : ITweetMapper
    {
        public IEnumerable<Tweet> Map(TwitterSearchResult tweets)
        {
            return tweets.Statuses.Select(tweet => new Tweet
                {
                    Status = tweet.TextAsHtml,
                    Author = tweet.User.ScreenName,
                    Client = tweet.Source,
                    ProfileImageUrl = tweet.User.ProfileImageUrl,
                    CreatedDate = tweet.CreatedDate
                });
        }
    }
}