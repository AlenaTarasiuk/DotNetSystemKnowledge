using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetSystemKnowledge.Domain.Interfaces;

namespace DotNetSystemKnowledge.WebUI.Controllers
{
    public class NavController : Controller
    {
   
        private ITechnologyRepository repository;
        public NavController(ITechnologyRepository reposit)
        {
            repository = reposit;
        }
        public PartialViewResult Menu()
        {
            IEnumerable<string> categories = repository.Technologys
                .Select(x => x.Name)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
         
    }
}