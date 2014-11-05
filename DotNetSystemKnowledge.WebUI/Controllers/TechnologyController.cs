using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetSystemKnowledge.Domain.Interfaces;
using DotNetSystemKnowledge.Domain.Entities;

namespace DotNetSystemKnowledge.WebUI.Controllers
{
    public class TechnologyController : Controller
    {
        public ITechnologyRepository repository;
        public TechnologyController(ITechnologyRepository technologyRepository)
        {
            this.repository = technologyRepository;
        }

        public ViewResult List()
        {
            return View(repository.Technologys);
        }

    }
}
