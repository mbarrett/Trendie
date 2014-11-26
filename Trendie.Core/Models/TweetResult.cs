using System;

namespace Trendie.Core.Models
{
    public class TweetResult
    {
        public string Status { get; set; }
        public string Author { get; set; }
        public string Client { get; set; }
        public string ProfileImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}