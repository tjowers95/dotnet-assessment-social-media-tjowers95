using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DotnetAssessmentSocialMedia.Data.Entities
{
    
    [Owned]
    public class Profile
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string Phone { get; set; }
        
    }
}