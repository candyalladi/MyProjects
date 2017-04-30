using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TweetnHash.Models
{
    public class SocialMediaAccount
    {
        public int Id { get; set; }

        [Required]
        public ApplicationUser SocialUser { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public FaceBookAccount FaceBookAccount { get; set; }

        [Required]
        [StringLength(255)]
        public TwitterAccount TwitterAccount { get; set; }
    }
}