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

        //Yogi methods--------------------------------------------------------------------------------
        public Yogi FindYogi(string yogi)
        {
            Yogi found_yogi = Context.Yogis.FirstOrDefault(u => u.Name == yogi);
            return found_yogi;
        }

        public void AddNewPractice(Yogi yogi, PracticePost post)
        {
            yogi.Practices.Add( new Practice
                {
                    Name = post.practiceName,
                    Poses = new List<UserPose>()
                });
            Context.SaveChanges();
        }

        public Practice SearchYogiForPractice(Yogi yogi, string practice)
        {
            Practice found_practice = yogi.Practices.FirstOrDefault(u => u.Name == practice);
            return found_practice;

        }

        public void RemovePracticeFromYogi(Yogi yogi, PracticePost post)
        {
            Practice PracticeToRemove = SearchYogiForPractice(yogi, post.practiceName);

            yogi.Practices.Remove(PracticeToRemove);
            Context.Practices.Remove(PracticeToRemove);
            Context.SaveChanges();
        }
        internal void GenereateUser(string UserId)
        {
            ApplicationUser newUser = Context.Users.FirstOrDefault(u => u.Id == UserId);
            Yogi newYogi = new Yogi
            {
                BaseUser = newUser,
                Name = newUser.UserName,
                Practices = new List<Practice>() 
            };
            Context.Yogis.Add(newYogi);
            Context.SaveChanges();
        }

        //Practice methods----------------------------------------------------------------------
        public void NewUserPose(Yogi yogi, PosePost pose_post)
        {
            BasePose found_base_pose = FindBasePose(pose_post.poseName);
            Practice found_practice = SearchYogiForPractice(yogi, pose_post.practiceName);

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
        }
        public UserPose FindUserPose(Practice practice, string pose)
        {
            UserPose found_pose = practice.Poses.FirstOrDefault(u => u.Name == pose);
            return found_pose;

        }
        public void DeletePose(Yogi yogi, PosePost pose_post)
        {
            Practice found_practice = SearchYogiForPractice(yogi, pose_post.practiceName);
            UserPose pose_to_remove = FindUserPose(found_practice, pose_post.poseName);
            found_practice.Poses.Remove(pose_to_remove);
            Context.UserPoses.Remove(pose_to_remove);
            Context.SaveChanges();
        }

        //Base Pose methods--------------------------------------------------------
        public BasePose FindBasePose(string base_pose)
        {
            BasePose found_base_pose = Context.BasePoses.FirstOrDefault(u => u.Name == base_pose);
            return found_base_pose;
        }
        public List<BasePose> GetBasePoses()
        {

            return Context.BasePoses.ToList();
        }

        //User Pose methods ------------------------------------------------------------------------
        public void EditPoseName(UserPose pose, string new_name)
        {
            pose.Name = new_name;
            Context.SaveChanges();
        }

        public void EditPoseDuration(Yogi yogi, PosePut put)
        {
            Practice found_practice = SearchYogiForPractice(yogi, put.practiceName);
            UserPose found_pose = FindUserPose(found_practice, put.poseName);

            if (found_pose.Duration != put.poseDuration)
            {
                found_pose.Duration = put.poseDuration;
                Context.SaveChanges();
            }
        }

        public void EditPoseSide(Yogi yogi, PosePut put)
        {
            Practice found_practice = SearchYogiForPractice(yogi, put.practiceName);
            UserPose found_pose = FindUserPose(found_practice, put.poseName);

            if (found_pose.Side != put.poseSide)
            {
                found_pose.Side = put.poseSide;
                Context.SaveChanges();
            }
        }

        public List<Practice> GetAllPractices(Yogi yogi)
        {
            List<Practice> allPractices = yogi.Practices.ToList();
            return allPractices;
        }

        //Context.Users.FirstOrDefault(u => u.UserName == name);

        /*public void MovePose(Practice practice, UserPose pose_to_move, int new_positon)
        {
            List<UserPose> AllPoses = practice.GetAllPoses();

        }*/
    }
}