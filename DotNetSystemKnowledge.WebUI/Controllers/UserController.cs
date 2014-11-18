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
        public ActionResult Register(UserRegisterViewModel model)
        {
            if (ModelState.IsValid && !repo.CheckExistenceOfUser(model.Name))
            {
                User user = new User()
                {
                    Name = model.Name,
                    Password = model.Password.GetHashCode().ToString(),
                    Email = model.Email
                };

                repo.CreateOfChangeUser(user);
            }
            else
            {
                ModelState.AddModelError("", "User with " + model.Name + " name already exists");
                return View(model);
            }

            return RedirectToAction("Login");
        }

        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginViewModel model)
        {
            if (ModelState.IsValid && repo.AuthenticationOfUser(model.Name, model.Password))
            {
                FormsAuthentication.RedirectFromLoginPage(model.Name, false);
            }
            else
            {
                ModelState.AddModelError("", "Authentication problems! Incorrect username or password.");
            }
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Technology", "List");
        }

        [Authorize]
        [HttpGet]
        public ViewResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(UserChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                string oldPass = model.OldPassword.GetHashCode().ToString();
                User user = repo.Users.FirstOrDefault(u => u.Name == User.Identity.Name && u.Password == oldPass);

                if (user == null)
                    ModelState.AddModelError("", "Your old password incorrect. Try another time.");
                else
                    repo.CreateOfChangeUser(user);
            }
            return View("Technology", "List");
        }
    }    
}
