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

        public Yogi FindYogi(string yogi)
        {
            Yogi found_yogi = Context.Yogis.FirstOrDefault(u => u.Name == yogi);
            return found_yogi;
        }

        public void AddNewPractice(string yogi, string practice)
        {
            Yogi found_yogi = FindYogi(yogi);
            if (found_yogi.Practices == null)
            {
                found_yogi.Practices = new List<Practice>();
            }
            found_yogi.Practices.Add(
                new Practice
                {
                    Name = practice
                });
        }

        public Practice SearchYogiForPractice(string yogi, string practice)
        {
            Yogi found_yogi = FindYogi(yogi);
            if (found_yogi.Practices == null)
            {
                return null;
            }
            Practice found_practice = found_yogi.Practices.FirstOrDefault(u => u.Name == practice);
            return found_practice;

        }

        public void RemovePracticeFromYogi(string yogi, string practice)
        {
            Yogi found_yogi = FindYogi(yogi);
            Practice PracticeToRemove = SearchYogiForPractice(yogi, practice);

            found_yogi.Practices.Remove(PracticeToRemove);
            Context.SaveChanges();
        }

        public UserPose NewUserPose(Practice practice, string base_pose)
        {
            BasePose found_base_pose = FindBasePose(base_pose);

            int duration = found_base_pose.DurationSuggestion;

            UserPose new_pose = new UserPose
            {
                Name = found_base_pose.Name,
                Reference = found_base_pose,
                Duration = duration,
                PracticeOrder = practice.Poses.ToList().Count
            };

            practice.Poses.Add(new_pose);
            Context.SaveChanges();
            return new_pose;
        }

        public BasePose FindBasePose(string base_pose)
        {
            BasePose found_base_pose = Context.BasePoses.FirstOrDefault(u => u.Name == base_pose);
            return found_base_pose;
        }

        public UserPose FindUserPose(Practice practice, string pose)
        {
            UserPose found_pose = practice.Poses.FirstOrDefault(u => u.Name == pose);
            return found_pose;

        }

        public void DeletePose(Practice practice, string pose)
        {
            UserPose pose_to_remove = FindUserPose(practice, pose);
            practice.Poses.Remove(pose_to_remove);
        }
    }
}