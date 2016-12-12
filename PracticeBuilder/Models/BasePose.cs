using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticeBuilder.Models
{
    public class BasePose
    {
        [Key]
        public int BasePoseID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Info { get; set; }
        [Required]
        public bool TwoSided { get; set; }
        public string ImageURL { get; set; }
        public string DurationSuggestion { get; set; }
        
    }
}