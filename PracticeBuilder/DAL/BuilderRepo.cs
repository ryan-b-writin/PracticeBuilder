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

        public void AddNewPractice(string v1, string v2)
        {
            Yogi found_yogi = FindYogi(v1);
            if (found_yogi.Practices == null)
            {
                found_yogi.Practices = new List<Practice>();
            }
            found_yogi.Practices.Add(
                new Practice
                {
                    Name = v2
                });
        }

        public Practice SearchYogiForPractice(string v1, string v2)
        {
            Yogi found_yogi = FindYogi(v1);
            Practice found_practice = found_yogi.Practices.FirstOrDefault(u => u.Name == v2);
            return found_practice;

        }
    }
}