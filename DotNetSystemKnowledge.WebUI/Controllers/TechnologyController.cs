using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetSystemKnowledge.Domain.Interfaces;
using DotNetSystemKnowledge.Domain.Entities;
using DotNetSystemKnowledge.WebUI.Models;

namespace DotNetSystemKnowledge.WebUI.Controllers
{
    public class TechnologyController : Controller
    {
        private ITechnologyRepository repository;
        public int PageSize = 4;
        public TechnologyController(ITechnologyRepository technologyRepository)
        {
            this.repository = technologyRepository;
        }

       // [HttpGet]
        public ViewResult List(int page = 1)
        {
            TechnologyViewModel model = new TechnologyViewModel
            {
                Technologys = repository.Technologys
                          .OrderBy(p => p.TechnologyID)
                          .Skip((page - 1) * PageSize)
                          .Take(PageSize)
                          .ToList<Technology>(),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Technologys.Count()
                }
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult NotFound()
        {
            return View();
        }
    }
}
