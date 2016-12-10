using PracticeBuilder.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PracticeBuilder.DAL
{
    public class PracticeBuilderContext : DbContext
    {
        public virtual DbSet<Yogi> Yogis { get; set; }
        public virtual DbSet<Practice> Practices { get; set; }
        public virtual DbSet<BasePose> BasePoses { get; set; }
        public virtual DbSet<UserPose> UserPoses { get; set; }
    }
}