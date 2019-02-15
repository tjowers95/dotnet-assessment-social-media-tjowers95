using DotnetAssessmentSocialMedia.Data.Entities;
using DotnetAssessmentSocialMedia.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetAssessmentSocialMedia.Services
{
    public interface ITweetService
    {
        IEnumerable<Tweet> GetAllTweets();
        Tweet CreateTweet(CreateTweetDto createDto, CredentialsDto credentials);
        Tweet GetTweet(int id);
        Tweet DeleteTweet(int id, CredentialsDto credentials);
        void Like(int id, CredentialsDto credentials);
        Tweet Reply(int id, CredentialsDto credentials);
        Tweet Repost(int id, CredentialsDto credentials);
        IEnumerable<Hashtag> TagsFromTweet(int id, CredentialsDto credentials);
        IEnumerable<User> UsersThatLiked(int id);
        IEnumerable<Tweet> TweetContext(int id);
        IEnumerable<Tweet> Replies(int id);
        IEnumerable<Tweet> Reposts(int id);
        IEnumerable<User> MentionedUsers(int id);
    }
}
