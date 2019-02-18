using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DotnetAssessmentSocialMedia.Data.Entities;
using DotnetAssessmentSocialMedia.Dtos;
using DotnetAssessmentSocialMedia.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotnetAssessmentSocialMedia.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public UserController(IUserService userService, IMapper mapper, ILogger<UserController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        // GET api/users
        [HttpGet]
        public IEnumerable<UserResponseDto> Get()
        {
            var result = _userService.GetAll();
            var users = result.ToList();

            var mappedUsers = _mapper.Map<IEnumerable<User>, IEnumerable<UserResponseDto>>(users);
            return mappedUsers.ToList();
        }

        // GET api/users/@{username}
        [HttpGet("@{username}")]
        public UserResponseDto Get(string username)
        {
            var user = _userService.GetByUsername(username);
            return _mapper.Map<UserResponseDto>(user);
        }

        // POST api/users
        [HttpPost("/users")]
        [ProducesResponseType(400)]
        public UserResponseDto Post([FromBody] CreateUserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var persistedUser = _userService.CreateUser(user);
            return _mapper.Map<UserResponseDto>(persistedUser);
        }

        // DELETE api/users/@{username}
        [HttpDelete("@{username}")]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public UserResponseDto Delete(string username, [FromBody] CredentialsDto credentialsDto)
        {
            var credentials = _mapper.Map<CredentialsDto>(credentialsDto);
            return _mapper.Map<UserResponseDto>(_userService.DeleteUser(username, credentials));
        }

        // GET validate/username/Available/@{username}
        [HttpGet("validate/username/exists/@{username}")]
        public bool GetUsernameAvailable(string username)
        {
            if (_userService.GetByUsername(username) != null) { return true; }

            return false;
        }
 
        // PATCH users/@{username}
        [HttpPatch("users/@{username}")]
        public UserResponseDto PatchUpdateUser(string username, [FromBody] CreateUserDto info)
        {
           return _mapper.Map<UserResponseDto>(_userService.EditUser(username, info));
        }

        // POST users/@{username}/follow
        [HttpPost("users/@{username}/follow")]
        public void PostFollow(string username, [FromBody] CredentialsDto credentials)
        {
            _userService.Follow(username, credentials);
        }

        // POST users/@{username}/unfollow
        [HttpPost("users/@{username}/unfollow")]
        public void PostUnfollow(string username, [FromBody] CredentialsDto credentials)
        {
            _userService.Unfollow(username, credentials);
        }

        // GET user/@{username}/feed 
        [HttpGet("users/@{username}/feed")]
        public IEnumerable<TweetResponseDto> GetFeed(string username)
        {
            return _mapper.Map<IEnumerable<Tweet>, IEnumerable<TweetResponseDto>>(_userService.Feed(username).ToList()).ToList();
        }

        // GET user/@{username}/tweets
        [HttpGet("users/@{username}/tweets")]
        public IEnumerable<TweetResponseDto> GetTweets(string username)
        {
            return _mapper.Map<IEnumerable<Tweet>, IEnumerable<TweetResponseDto>>(_userService.Tweets(username).ToList()).ToList();
        }
/*
        // GET user/@{username}/mentions
        public ActionResult<IEnumerable<Tweet>> GetMentions(string username)
        {
            return Ok(_userService.Mentions(username));
        }

        // GET user/@{username}/followers
        public ActionResult<IEnumerable<Tweet>> GetFollowers(string username)
        {
            return Ok(_userService.Followers(username));
        }

        // GET user/@{username}/following
        public ActionResult<IEnumerable<Tweet>> GetFollowing(string username)
        {
            return Ok(_userService.Following(username));
        }
*/
    }
}