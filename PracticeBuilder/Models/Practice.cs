using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticeBuilder.Models
{
    public class Practice
    {
        [Key]
        public int PracticeID { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual List<UserPose> Poses { get; set; }
    }
}