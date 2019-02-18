using AutoMapper;
using DotnetAssessmentSocialMedia.Data.Entities;
using DotnetAssessmentSocialMedia.Dtos;
using DotnetAssessmentSocialMedia.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetAssessmentSocialMedia.Controller
{   [ApiController]
    [Route("api/tweets")]
    public class TweetController : ControllerBase
    {
        private readonly ITweetService _tweetService;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public TweetController(ITweetService service, IMapper mapper, ILogger<TweetController> logger)
        {
            _tweetService = service;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<TweetResponseDto> Get()
        {
            var tweets = _tweetService.GetTweets().ToArray();
            var tweetDtos = new TweetResponseDto[tweets.Length];

            for (int i = 0; i < tweets.Length; i++)
            {
                tweetDtos[i] = new TweetResponseDto();
                tweetDtos[i].TweetContent = tweets[i].TweetContent;
                tweetDtos[i].Username = tweets[i].Author.Credentials.Username;
            }

            return tweetDtos;
        } 

        [HttpPost]
        public TweetResponseDto Post([FromBody] CreateTweetDto dto)
        {
            var tweet = _tweetService.PostTweet(dto);

            var tweetResponse = new TweetResponseDto();

            tweetResponse.Username = tweet.Author.Credentials.Username;

            tweetResponse.TweetContent = tweet.TweetContent;

            return tweetResponse;
        }
    }
}
