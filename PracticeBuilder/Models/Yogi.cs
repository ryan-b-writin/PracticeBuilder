using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticeBuilder.Models
{
    public class Yogi
    {
        [Key]
        public int YogiID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public virtual List<Practice> Practices { get; set; }
    }
}