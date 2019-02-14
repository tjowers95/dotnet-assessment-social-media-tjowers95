using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DotnetAssessmentSocialMedia.Data.Entities
{
    [Owned]
    public class Credentials
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}