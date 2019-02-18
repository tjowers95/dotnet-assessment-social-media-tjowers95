using System.Collections.Generic;
using DotnetAssessmentSocialMedia.Data.Entities;
using DotnetAssessmentSocialMedia.Dtos;

namespace DotnetAssessmentSocialMedia.Services
{
    public interface IUserService
    {
        User GetByUsername(string username);
        IEnumerable<User> GetAll();
        User CreateUser(User user);
        User EditUser(string username, CreateUserDto info);
        User DeleteUser(string username, CredentialsDto credentials);
        void Follow(string username, CredentialsDto credentials);
        void Unfollow(string username, CredentialsDto credentials);
        IEnumerable<Tweet> Feed(string username);
        IEnumerable<Tweet> Tweets(string username);
        IEnumerable<Tweet> Mentions(string username);
        IEnumerable<User> Followers(string username);
        IEnumerable<User> Following(string username);
    }
}