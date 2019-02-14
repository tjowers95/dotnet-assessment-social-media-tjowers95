using System.ComponentModel.DataAnnotations;

namespace DotnetAssessmentSocialMedia.Dtos
{
    public class ProfileDto
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string Phone { get; set; }
    }
}