using System;
using System.Collections.Generic;
using System.Linq;
using DotnetAssessmentSocialMedia.Data;
using DotnetAssessmentSocialMedia.Data.Entities;
using DotnetAssessmentSocialMedia.Dtos;
using DotnetAssessmentSocialMedia.Exception.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace DotnetAssessmentSocialMedia.Services
{
    public class UserService : IUserService
    {
        private readonly SocialMediaContext _context;

        private readonly ILogger _logger;

        public UserService(SocialMediaContext context, ILogger<UserService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public User GetByUsername(string username)
        {
            var user = _context.Users.SingleOrDefault(u => u.Credentials.Username == username);

            // If user doesn't exists or is deleted, throw UserNotFoundException
            if (user == null || user.Deleted)
            {
                throw new UserNotFoundException();
            }

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            // Find all non-delete users
            var users = _context.Users.Where(u => !u.Deleted).ToList();
            if (users.Count <= 0)
            {
                throw new NotFoundCustomException("No users found", "No users found");
            }

            return users;
        }

        public User CreateUser(User user)
        {
            user.Joined = DateTime.Now;
            try
            {
                _context.Add(user);
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException.Message.Contains("unique constraint")) // hmm
                {
                    var existingUser = _context.Users
                        .FirstOrDefault(u => u.Credentials.Username == user.Credentials.Username);
                    if (existingUser != null)
                    {
                        existingUser.Deleted = false;
                        _context.Update(existingUser);
                        return existingUser;
                    }
                }
            }

            return user;
        }

        public User DeleteUser(string username, CredentialsDto credentials)
        {
            // Get user if username matches and user is not deleted
            var user = _context.Users
                .SingleOrDefault(u => u.Credentials.Username == username
                                      && !u.Deleted);

            if (user == null)
            {
                throw new UserNotFoundException();
            }

            if (user.Credentials.Username != credentials.Username
                || user.Credentials.Password != credentials.Password)
            {
                throw new InvalidCredentialsException();
            }

            user.Deleted = true;
            _context.Update(user);
            _context.SaveChanges();

            return user;
        }

        public User EditUser(string username, ProfileDto profile, CredentialsDto credentials)
        {
            var user = _context.Users
                .SingleOrDefault(u => u.Credentials.Username == username && !u.Deleted);

            if (user == null)
                throw new UserNotFoundException();

            if (user.Credentials.Username != credentials.Username || user.Credentials.Password != credentials.Password)
                throw new InvalidCredentialsException();

            user.Profile.FirstName = profile.FirstName;
            user.Profile.LastName  = profile.LastName;
            user.Profile.Phone     = profile.Phone;
            user.Profile.Email     = profile.Email;

            _context.Update(user);
            _context.SaveChanges();

            return user;
        }

        public void Follow(string username, CredentialsDto credentials)
        {
            var follower = _context.Users
                .SingleOrDefault(u => u.Credentials.Username == username && !u.Deleted);

            var followee = _context.Users
                .SingleOrDefault(u => u.Credentials.Username == credentials.Username && !u.Deleted);

            if (followee == null || follower == null)
                throw new UserNotFoundException();

            if (followee.Credentials.Username != credentials.Username || followee.Credentials.Password != credentials.Password)
                throw new InvalidCredentialsException();

            if (!_context.UserFollowJoin.Select(u => u.FolloweeId == followee.Id && u.FollowerId == follower.Id).Any())
            {
                var userUser = new UserUser(followee.Id, follower.Id);
                _context.UserFollowJoin.Add(userUser);

                _context.Update(userUser);
                _context.SaveChanges();
            }
        }

        public void Unfollow(string username, CredentialsDto credentials)
        {
            var follower = _context.Users
                .SingleOrDefault(u => u.Credentials.Username == username && !u.Deleted);

            var followee = _context.Users
                 .SingleOrDefault(u => u.Credentials.Username == credentials.Username && !u.Deleted);

            if (followee == null || follower == null)
                throw new UserNotFoundException();

            if (followee.Credentials.Username != credentials.Username || followee.Credentials.Password != credentials.Password)
                throw new InvalidCredentialsException();

            if (_context.UserFollowJoin.Select(u => u.FolloweeId == followee.Id && u.FollowerId == follower.Id).Any())
            {
                _context.UserFollowJoin.Remove(_context.UserFollowJoin.SingleOrDefault(u => u.FolloweeId == followee.Id && u.FollowerId == follower.Id));
                _context.SaveChanges();
            }
        }

        public IEnumerable<Tweet> Feed(string username)
        {
            var userId = _context.Users
                .SingleOrDefault(u => u.Credentials.Username == username && !u.Deleted).Id;

            var userFeed = _context.UserTweetsJoin
                .Where(u => u.UserId == userId)
                .Select(t => t.Tweet)
                .ToList();

            var following = _context.UserFollowJoin
                .Where(u => u.FollowerId == userId)
                .Select(f => f.Followee)
                .ToList();

            foreach (var i in following)
            {
                userFeed.AddRange
                    (
                      _context.UserTweetsJoin
                      .Where(u => u.UserId == i.Id)
                      .Select(t => t.Tweet)
                      .ToList()
                    );
            }

            return userFeed;
        }

        public IEnumerable<Tweet> Tweets(string username)
        {
            var userId = _context.Users
                 .SingleOrDefault(u => u.Credentials.Username == username && !u.Deleted).Id;

            var userTweets = _context.UserTweetsJoin
                .Where(u => u.UserId == userId)
                .Select(t => t.Tweet)
                .Where(t => !t.Deleted)
                .Select(t => t)
                .ToList();

            return userTweets.OrderBy(i => i.Created).ToList();
        }

        public IEnumerable<Tweet> Mentions(string username)
        {
            var userId = _context.Users
                .SingleOrDefault(u => u.Credentials.Username == username && !u.Deleted).Id;

            var mentions = _context.TweetUserMentionsJoin
                .Where(u => u.Tweet.UserId == userId)
                .Select(t => t.Tweet)
                .Where(t => !t.Deleted)
                .Select(t => t)
                .ToList();

            return mentions;
        }

        public IEnumerable<User> Followers(string username)
        {
            var userId = _context.Users
                 .SingleOrDefault(u => u.Credentials.Username == username && !u.Deleted).Id;

            var followers = _context.UserFollowJoin
                .Where(u => u.FolloweeId == userId)
                .Select(f => f.Follower)
                .ToList();

            return followers;
        }

        public IEnumerable<User> Following(string username)
        {
            var userId = _context.Users
                .SingleOrDefault(u => u.Credentials.Username == username && !u.Deleted).Id;

            var following = _context.UserFollowJoin
                .Where(u => u.FollowerId == userId)
                .Select(f => f.Followee)
                .ToList();

            return following;
        }
    }
}