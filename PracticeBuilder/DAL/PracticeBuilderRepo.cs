using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeBuilder.DAL
{
    public class PracticeBuilderRepo
    {
        public PracticeBuilderContext Context { get; set; }

        public PracticeBuilderRepo(PracticeBuilderContext context)
        {
            this.Context = context;
        }
        public PracticeBuilderRepo()
        {
            this.Context = new PracticeBuilderContext();
        }
    }
}