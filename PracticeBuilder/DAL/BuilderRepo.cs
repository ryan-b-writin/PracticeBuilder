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
        // -------------------------------------------------------------------------------------------


        public Yogi FindYogi(string yogi)
        {
            Yogi found_yogi = Context.Yogis.FirstOrDefault(u => u.Name == yogi);
            return found_yogi;
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
        //--------------------------------------------------------------------------------------


        public Practice SearchYogiForPractice(Yogi yogi, int practiceID)
        {
            Practice found_practice = yogi.Practices.FirstOrDefault(u => u.PracticeID == practiceID);
            return found_practice;

        }

        public void RemovePracticeFromYogi(Yogi yogi, PracticePost post)
        {
            Practice PracticeToRemove = SearchYogiForPractice(yogi, post.practiceID);
            Context.UserPoses.RemoveRange(PracticeToRemove.Poses);
            yogi.Practices.Remove(PracticeToRemove);
            Context.Practices.Remove(PracticeToRemove);
            Context.SaveChanges();
        }

        public void Delete(UserPose u)
        {
            Context.UserPoses.Remove(u);
        }

        public void AddNewPractice(Yogi yogi, PracticePost post)
        {
            yogi.Practices.Add(new Practice
            {
                Name = post.practiceName,
                Poses = new List<UserPose>()
            });
            Context.SaveChanges();
        }

        //Base Pose methods-------------------------------------------------------------
        //------------------------------------------------------------------------------


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
        //------------------------------------------------------------------------------------------


        public void NewUserPose(Yogi yogi, PosePost pose_post)
        {
            BasePose found_base_pose = FindBasePose(pose_post.poseName);
            Practice found_practice = SearchYogiForPractice(yogi, pose_post.practiceID);

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

        public UserPose FindUserPose(int poseID)
        {
            UserPose found_pose = Context.UserPoses.FirstOrDefault(u => u.UserPoseID == poseID);
            return found_pose;

        }

        public void DeletePose(PosePost pose_post)
        {
            UserPose pose_to_remove = FindUserPose(pose_post.poseID);
            Context.UserPoses.Remove(pose_to_remove);
            Context.SaveChanges();
        }

        public void EditPose(PosePut put)
        {
            var found_pose = Context.UserPoses.FirstOrDefault(x => x.UserPoseID == put.poseID);

            found_pose.Duration = put.poseDuration;
            found_pose.Side = put.poseSide;
       
            Context.SaveChanges();
            
        }

        public List<Practice> GetAllPractices(Yogi yogi)
        {
            List<Practice> allPractices = yogi.Practices.ToList();
            return allPractices;
        }
        
        public List<UserPose> GetAllUserPoses(Yogi yogi, PracticePost post)
        {
            Practice found_practice = SearchYogiForPractice(yogi, post.practiceID);
            return found_practice.Poses.ToList();
        }

        public int CountSimilarNames (string nameToCheck)
        {
            return Context.UserPoses.Count(p => p.Name.StartsWith(nameToCheck));
        }

    }
}