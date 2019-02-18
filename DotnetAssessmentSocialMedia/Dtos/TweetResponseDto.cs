using DotnetAssessmentSocialMedia.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetAssessmentSocialMedia.Dtos
{
    public class TweetResponseDto
    {
        [Required]
        public string TweetContent { get; set; }

        [Required]
        public  string Username { get; set; }
    }
}
