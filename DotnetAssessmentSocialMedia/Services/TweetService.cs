using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetAssessmentSocialMedia.Data;
using DotnetAssessmentSocialMedia.Data.Entities;
using DotnetAssessmentSocialMedia.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DotnetAssessmentSocialMedia.Services
{
    public class TweetService : ITweetService
    {
        private readonly SocialMediaContext _context;

        private readonly IUserService _userService;

        private readonly ILogger _logger;

        public TweetService(SocialMediaContext context, IUserService service, ILogger<TweetService> logger)
        {
            _context = context;
            _logger = logger;
            _userService = service;
        }

        public IEnumerable<Tweet> GetTweets()
        {
            var tweets = _context.Tweets.Include(t => t.Author)
                .Where(t => !t.Deleted)
                .ToArray();

            if (tweets == null)
            {
                throw new NotImplementedException();
            }

            return tweets;
        }

        public Tweet PostTweet(CreateTweetDto info)
        {
            var user = _userService.GetByUsername(info.Credentials.Username);
            var tweetContent = info.TweetContent;

            if (user == null || user.Credentials.Password != info.Credentials.Password)
                throw new NotImplementedException();

            var tweet = new Tweet();
            tweet.Author = user;
            tweet.TweetContent = tweetContent;
            
            _context.Tweets.Add(tweet);
            _context.SaveChanges();

            return tweet;
        }
    }
}
