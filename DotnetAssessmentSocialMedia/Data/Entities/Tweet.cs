using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetAssessmentSocialMedia.Data.Entities
{
    [Table("tweet")]
    public class Tweet
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("tweet_content"), Required]
        public string TweetContent { get; set; }

        [Column("deleted")]
        public bool Deleted { get; set; } = false;

        [ForeignKey("response_to_id")]
        public int ResponseToId { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;

        [NotMapped]
        public Tweet ParentTweet { get; set; }

        [ForeignKey("retweet_of_id")]
        public int RetweetOfId { get; set; }

        [NotMapped]
        public Tweet Retweet { get; set; } 

        [ForeignKey("user_id")]
        public int UserId { get; set; }

        [NotMapped]
        public User Author { get; set; }
    }
}
