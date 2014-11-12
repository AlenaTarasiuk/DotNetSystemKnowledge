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

        [HttpPost]
        public ActionResult Register(UserRegisterViewModel model, HttpPostedFileBase image)
        {
            if (ModelState.IsValid && !repo.CheckExistenceOfUser(model.Name))
            {
                User user = new User()
                {
                    Name = model.Name,
                    Password = model.Password.GetHashCode().ToString(),
                    Email = model.Email
                };
            }
            else
            {
                ModelState.AddModelError("", "User with " + model.Name + " name already exists");
                return View(model);
            }

            return RedirectToAction("Login");
        }


    }
}
