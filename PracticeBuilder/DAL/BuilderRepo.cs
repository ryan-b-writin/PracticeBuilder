using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PracticeBuilder.Models;

namespace PracticeBuilder.DAL
{
    public class BuilderRepo
    {
        public BuilderContext Context { get; set; }

        public BuilderRepo(BuilderContext context)
        {
            this.Context = context;
        }
        public BuilderRepo()
        {
            this.Context = new BuilderContext();
        }

        public Yogi FindYogi(string v)
        {
            Yogi found_yogi = Context.Yogis.FirstOrDefault(u => u.Name == v);
            return found_yogi;
        }
    }
}