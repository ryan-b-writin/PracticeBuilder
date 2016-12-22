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
        public virtual BasePose Reference { get; set; }
        public int Duration { get; set; }
        public int PracticeOrder { get; set; }
        public string Side { get; set; }

    }
}