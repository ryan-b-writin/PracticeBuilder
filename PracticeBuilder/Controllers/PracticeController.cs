using PracticeBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticeBuilder.DAL;
using System.Web.Http;
using Microsoft.AspNet.Identity;

// GET: All Practices attached to user
//POST: Add New Practice to user
namespace PracticeBuilder.Controllers
{
    public class PracticeController : ApiController
    {
        BuilderRepo repo = new BuilderRepo();

        // GET: All Practices attached to user
        public IEnumerable<Practice> Get()
        {
            if (User.Identity.IsAuthenticated)
            {
                string user_id = User.Identity.GetUserId();
                ApplicationUser found_app_user = repo.Context.Users.FirstOrDefault(u => u.Id == user_id);
                Yogi found_user = repo.Context.Yogis.FirstOrDefault(u => u.BaseUser.UserName == found_app_user.UserName);
                return repo.GetAllPractices(found_user);
            }
            //If No User Is logged in, return sample practice data to fill out table
            else
            {
                return new List<Practice>
                {
                    new Practice
                    {
                        Name = "Sample Practice 1",
                        Poses = new List<UserPose>
                        {
                            new UserPose
                            {
                                Name = "Sample Pose",
                                Duration = 4,
                                Reference = new BasePose
                                {
                                    Name = "Sample Pose",
                                    TwoSided = false,
                                    DurationSuggestion = 4,
                                    Info = "lorem ipsum"
                                }
                            }
                        }
                    },
                    new Practice
                    {
                        Name = "Sample Practice 2",
                        Poses = new List<UserPose>
                        {
                            new UserPose
                            {
                                Name = "Sample Pose",
                                Duration = 4,
                                Reference = new BasePose
                                {
                                    Name = "Sample Pose",
                                    TwoSided = false,
                                    DurationSuggestion = 4,
                                    Info = "lorem ipsum"
                                }
                            }
                        }
                    },
                    new Practice
                    {
                        Name = "Sample Practice 3",
                        Poses = new List<UserPose>
                        {
                            new UserPose
                            {
                                Name = "Sample Pose",
                                Duration = 4,
                                Reference = new BasePose
                                {
                                    Name = "Sample Pose",
                                    TwoSided = false,
                                    DurationSuggestion = 4,
                                    Info = "lorem ipsum"
                                }
                            }
                        }
                    }
                };
            };
        }

        //POST: Add New Practice to user
        [System.Web.Mvc.HttpPost]
        public IHttpActionResult Post([FromBody]PracticePost post)
        {
            if (User.Identity.IsAuthenticated)
            {
                string user_id = User.Identity.GetUserId();
                ApplicationUser found_app_user = repo.Context.Users.FirstOrDefault(u => u.Id == user_id);
                Yogi found_user = repo.Context.Yogis.FirstOrDefault(u => u.BaseUser.UserName == found_app_user.UserName);
                repo.AddNewPractice(found_user, post);
            }
            return Ok();
        }
    }
}
