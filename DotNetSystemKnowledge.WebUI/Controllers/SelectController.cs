using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetSystemKnowledge.Domain.Interfaces;

namespace DotNetSystemKnowledge.WebUI.Controllers
{
    public class SelectController : Controller
    {
        IUserRepository userRepo;
        ITechnologyRepository technologyRepo;

        public SelectController(ITechnologyRepository technologyRepo, IUserRepository userRepo)
        {
            this.userRepo = userRepo;
            this.technologyRepo = technologyRepo;
        }

        public ViewResult Select()
        {
            return View();
        }


    }
}
