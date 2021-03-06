﻿using Microsoft.AspNet.Identity;
using PracticeBuilder.DAL;
using PracticeBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

//POST: Remove Practice From Yogi

namespace PracticeBuilder.Controllers
{
    public class ManagePracticeController : ApiController
    {
        BuilderRepo repo = new BuilderRepo();
       
        //Remove Practice From Yogi
        [System.Web.Mvc.HttpPost]
        public IHttpActionResult Post([FromBody]PracticePost post)
        {
            if (User.Identity.IsAuthenticated)
            {
                string user_id = User.Identity.GetUserId();
                ApplicationUser found_app_user = repo.Context.Users.FirstOrDefault(u => u.Id == user_id);
                Yogi found_user = repo.Context.Yogis.FirstOrDefault(u => u.BaseUser.UserName == found_app_user.UserName);
                repo.RemovePracticeFromYogi(found_user, post);
            }
            return Ok();
        }
    }
}