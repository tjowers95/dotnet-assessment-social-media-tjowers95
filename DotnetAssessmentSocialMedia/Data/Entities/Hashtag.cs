using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetAssessmentSocialMedia.Data.Entities
{
    public class Hashtag
    {
        [Key]
        public int Id { get; set; }

        [Column("hashtag_content"), Required]
        public string HashtagContent { get; set; }

        [ForeignKey("initial_tweet_id"), Required]
        public int InitialTweetId { get; set; }

        [NotMapped]
        public Tweet InitialTweet { get; set; }

        [ForeignKey("most_recent_tweet_id"), Required]
        public int MostRecentTweetId { get; set; }

        [NotMapped]
        public Tweet MostRecentTweet { get; set; }
    }
}
