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
        IEnumerable<Tweet> GetTweets();
        Tweet PostTweet(CreateTweetDto info);
    }
}
