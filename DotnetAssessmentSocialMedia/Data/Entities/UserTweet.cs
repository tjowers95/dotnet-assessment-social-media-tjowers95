using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetAssessmentSocialMedia.Data.Entities
{
    public class UserTweet
    {
        [ForeignKey("user_id")]
        public int UserId { get; set; }
        public User Author { get; set; }

        [ForeignKey("tweet_id")]
        public int TweetId { get; set; }
        public Tweet Tweet { get; set; }
    }
}
