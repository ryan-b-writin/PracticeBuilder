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
            if (found_yogi.Practices == null)
            {
                return null;
            }
            Practice found_practice = found_yogi.Practices.FirstOrDefault(u => u.Name == v2);
            return found_practice;

        }

        public void RemovePracticeFromYogi(string v1, string v2)
        {
            Yogi found_yogi = FindYogi(v1);
            Practice PracticeToRemove = SearchYogiForPractice(v1, v2);

            found_yogi.Practices.Remove(PracticeToRemove);
            Context.SaveChanges();
        }

        public UserPose NewUserPose(string base_pose, string yogi, string practice)
        {
            Yogi found_yogi = FindYogi(yogi);
            Practice found_practice = SearchYogiForPractice(yogi, practice);
            BasePose found_base_pose = FindBasePose(base_pose);

            int duration = found_base_pose.DurationSuggestion;

            UserPose new_pose = new UserPose
            {
                Name = found_base_pose.Name,
                Reference = found_base_pose,
                Duration = duration,
                PracticeOrder = found_practice.Poses.ToList().Count
            };

            found_practice.Poses.Add(new_pose);
            Context.SaveChanges();
            return new_pose;
        }

        private BasePose FindBasePose(string base_pose)
        {
            BasePose found_base_pose = Context.BasePoses.FirstOrDefault(u => u.Name == base_pose);
            return found_base_pose;
        }
    }
}