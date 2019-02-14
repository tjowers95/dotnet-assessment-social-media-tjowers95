using System;

namespace DotnetAssessmentSocialMedia.Dtos
{
    public class UserResponseDto
    {
        public string Username { get; set; }
        
        public ProfileDto Profile { get; set; }
        
        public DateTime Joined { get; set; }
    }
}