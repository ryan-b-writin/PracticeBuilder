﻿using System;
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

        public void RemovePracticeFromYogi(Yogi yogi, string practice)
        {
            Practice PracticeToRemove = SearchYogiForPractice(yogi, practice);

            yogi.Practices.Remove(PracticeToRemove);
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
        public void DeletePose(Practice practice, string pose)
        {
            UserPose pose_to_remove = FindUserPose(practice, pose);
            practice.Poses.Remove(pose_to_remove);
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

        public void EditPoseDuration(UserPose pose, int new_duration)
        {
            pose.Duration = new_duration;
            Context.SaveChanges();
        }

        public void EditPoseSide(UserPose pose, string new_side)
        {
            pose.Side = new_side;
            Context.SaveChanges();
        }

        //Context.Users.FirstOrDefault(u => u.UserName == name);

        /*public void MovePose(Practice practice, UserPose pose_to_move, int new_positon)
        {
            List<UserPose> AllPoses = practice.GetAllPoses();

        }*/
    }
}