using PracticeBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticeBuilder.DAL;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace PracticeBuilder.Controllers
{
    public class PracticeController : ApiController
    {
        BuilderRepo repo = new BuilderRepo();
        // GET: Practice
        public IEnumerable<BasePose> Get()
        {
            return repo.GetBasePoses();
        }
        public void Post([FromBody]string practiceName)
        {

            if (ModelState.IsValid && User.Identity.IsAuthenticated)
            {
                string user_id = User.Identity.GetUserId();
                ApplicationUser found_app_user = repo.Context.Users.FirstOrDefault(u => u.Id == user_id);
                Yogi found_user = repo.Context.Yogis.FirstOrDefault(u => u.BaseUser.UserName == found_app_user.UserName);
                repo.AddNewPractice(found_user, practiceName);
            }

        }

    }
}
