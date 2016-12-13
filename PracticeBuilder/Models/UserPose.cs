using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticeBuilder.Models
{
    public class UserPose
    {
        [Key]
        public int UserPoseID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public virtual BasePose Reference { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public int PracticeOrder { get; set; }
        public string Side { get; set; }

    }
}