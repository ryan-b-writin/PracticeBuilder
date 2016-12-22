using Microsoft.AspNet.Identity;
using PracticeBuilder.DAL;
using PracticeBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

//GET- Get All Base Poses
//POST- Generate New User Pose From Base Pose 
//PUT- Edit User Pose

namespace PracticeBuilder.Controllers
{
    public class PoseController : ApiController
    {
        BuilderRepo repo = new BuilderRepo();
        // GET: Practice

        //Get all Base Poses
        public IEnumerable<BasePose> Get()
        {
            return repo.GetBasePoses();
        }

        //Generate New User Pose From Base Pose
        [System.Web.Mvc.HttpPost]
        public IHttpActionResult Post([FromBody]PosePost post)
        {
            if (User.Identity.IsAuthenticated)
            {
                string user_id = User.Identity.GetUserId();
                ApplicationUser found_app_user = repo.Context.Users.FirstOrDefault(u => u.Id == user_id);
                Yogi found_user = repo.Context.Yogis.FirstOrDefault(u => u.BaseUser.UserName == found_app_user.UserName);
                repo.NewUserPose(found_user, post);
            }
            return Ok();
        }

        //Edit User Pose
        [System.Web.Mvc.HttpPut]
        public IHttpActionResult Put([FromBody]PosePut put)
        {
            if (User.Identity.IsAuthenticated)
            {
                string user_id = User.Identity.GetUserId();
                ApplicationUser found_app_user = repo.Context.Users.FirstOrDefault(u => u.Id == user_id);
                Yogi found_user = repo.Context.Yogis.FirstOrDefault(u => u.BaseUser.UserName == found_app_user.UserName);
                repo.EditPose(found_user, put);
                //repo.EditPoseSide(found_user, put);
            }
            return Ok();
        }
    }
}