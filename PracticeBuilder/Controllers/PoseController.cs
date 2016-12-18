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
    public class PoseController : ApiController
    {
        BuilderRepo repo = new BuilderRepo();
        // GET: Practice
        public IEnumerable<BasePose> Get()
        {
            return repo.GetBasePoses();
        }
    }
}