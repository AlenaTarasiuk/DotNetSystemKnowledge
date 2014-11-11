using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetSystemKnowledge.Domain.Entities;
using DotNetSystemKnowledge.Domain.Interfaces;
using DotNetSystemKnowledge.WebUI.Models;

namespace DotNetSystemKnowledge.WebUI.Controllers
{
    public class TechnologyController : Controller
    {
        private ITechnologyRepository repository;
        public int PageSize = 5;
        public TechnologyController(ITechnologyRepository technologyRepository)
        {
            this.repository = technologyRepository;
        }

        public ViewResult List(int page = 1)
        {
            TechnologysViewModel model = new TechnologysViewModel
            {
                Technologys = repository.Technologys
                .OrderBy(p => p.TechnologyID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Technologys.Count()
                }
            };
            return View(model);
        }
    }
}
