using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetAssessmentSocialMedia.Data.Entities
{
    public class TweetHashtag
    {
        [ForeignKey("tweet_id")]
        public int TweetId { get; set; }
        public Tweet ContainingTweet { get; set; }

        [ForeignKey("hashtag_id")]
        public int HashtagId { get; set; }
        public Hashtag Hashtag { get; set; }
    }
}
