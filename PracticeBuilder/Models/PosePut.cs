using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeBuilder.Models
{
    public class PosePut
    {
        public int poseID { get; set; }
        public string practiceName { get; set; }
        public int poseDuration { get; set; }
        public string poseSide { get; set; }
        public int practiceID { get; set; }
    }
}