using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetAssessmentSocialMedia.Data.Entities
{
    public class User
    {
        public int Id { get; set; }

        public Credentials Credentials { get; set; }

        public Profile Profile { get; set; }

        [DataType("timestamp")]
        public DateTime Joined { get; set; } = DateTime.UtcNow;

        public Boolean Deleted { get; set; }
    }
}