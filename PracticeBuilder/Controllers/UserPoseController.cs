﻿using Microsoft.AspNet.Identity;
using PracticeBuilder.DAL;
using PracticeBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PracticeBuilder.Controllers
{
    public class UserPoseController : ApiController
    {
        BuilderRepo repo = new BuilderRepo();
        [System.Web.Mvc.HttpPost]
        public IHttpActionResult Post([FromBody]PosePost post)
        {
            if (User.Identity.IsAuthenticated)
            {
                string user_id = User.Identity.GetUserId();
                ApplicationUser found_app_user = repo.Context.Users.FirstOrDefault(u => u.Id == user_id);
                Yogi found_user = repo.Context.Yogis.FirstOrDefault(u => u.BaseUser.UserName == found_app_user.UserName);
                repo.DeletePose(found_user, post);
            }
            return Ok();
        }
        public IEnumerable<UserPose> Get([FromBody]PracticePost post)
        {
            if (User.Identity.IsAuthenticated)
            {
                string user_id = User.Identity.GetUserId();
                ApplicationUser found_app_user = repo.Context.Users.FirstOrDefault(u => u.Id == user_id);
                Yogi found_user = repo.Context.Yogis.FirstOrDefault(u => u.BaseUser.UserName == found_app_user.UserName);
                return repo.GetAllUserPoses(found_user, post);
            }
            else
            {
                return null;
            }
        }
    }
}