using DotnetAssessmentSocialMedia.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DotnetAssessmentSocialMedia.Data
{
    public class SocialMediaContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Tweet> Tweets { get; set;}

        public DbSet<Hashtag> Hashtag { get; set; }

        public DbSet<UserUser> UserFollowJoin { get; set; }

        public DbSet<UserTweet> UserTweetsJoin { get; set; }

        public DbSet<TweetUserLikes> TweetUserLikesJoin { get; set; }

        public DbSet<TweetHashtag> TweetHashtagsJoin { get; set; }

        public DbSet<TweetUserMentions> TweetUserMentionsJoin { get; set; }

        public SocialMediaContext(DbContextOptions<SocialMediaContext> options)
            : base(options) 
        { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();

            var tweetHashtags = modelBuilder.Entity<TweetHashtag>();

            tweetHashtags
                .HasKey(entity => new { entity.TweetId, entity.HashtagId });

            var userTweets = modelBuilder.Entity<UserTweet>();

            userTweets
                .HasKey(entity => new { entity.UserId, entity.TweetId});

            var userUsers = modelBuilder.Entity<UserUser>();

            userUsers
                .HasKey(entity => new { entity.FolloweeId, entity.FollowerId });

            var tweetUserLikes = modelBuilder.Entity<TweetUserLikes>();

            tweetUserLikes
                .HasKey(entity => new { entity.UserId, entity.TweetId });

            var tweetUserMentions = modelBuilder.Entity<TweetUserMentions>();

            tweetUserMentions
                .HasKey(e => new { e.UserId, e.TweetId });
        }
    }
}