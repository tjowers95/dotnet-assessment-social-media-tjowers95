using System.ComponentModel.DataAnnotations;

namespace DotnetAssessmentSocialMedia.Dtos
{
    public class CredentialsDto
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}