using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetSystemKnowledge.Domain.Entities;
using DotNetSystemKnowledge.Domain.Interfaces;
using DotNetSystemKnowledge.WebUI.Models;

namespace DotNetSystemKnowledge.WebUI.Controllers
{
    public class UserController : Controller
    {
        IUserRepository repo;

        public UserController(IUserRepository reposit)
        {
            repo = reposit;
        }

   
        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }


        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }

    }
}
