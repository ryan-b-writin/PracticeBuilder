using PracticeBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticeBuilder.DAL;
using System.Web.Http;

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

    }
}
