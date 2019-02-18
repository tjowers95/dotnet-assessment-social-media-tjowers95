using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetAssessmentSocialMedia.Dtos
{
    public class CreateTweetDto
    {
        public CredentialsDto Credentials { get; set; }

        public string TweetContent { get; set; }
    }
}
