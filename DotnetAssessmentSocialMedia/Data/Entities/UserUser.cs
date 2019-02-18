using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetAssessmentSocialMedia.Data.Entities
{
    public class UserUser
    {
        [ForeignKey("followee_id")]
        public int FolloweeId { get; set; }
        public User Followee { get; set; }

        [ForeignKey("follower_id")]
        public int FollowerId { get; set; }
        public User Follower { get; set; }

    }
}