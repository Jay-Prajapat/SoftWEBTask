using StudentInformationSystem.Models;
using StudentInformationSystem.Repository;
using StudentInformationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudentInformationSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController()
        {
            _userRepository = new UserRepository();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                if (await _userRepository.IsValidUser(user))
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("Index", "Student");
                }
            }
            ModelState.AddModelError("", "Invalid UserName or Password.");
            return View(user);
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SignUp(Users user)
        {
            if (ModelState.IsValid)
            {
                if (!await _userRepository.IsUserExist(user))
                {
                    await _userRepository.AddUser(user);
                    return RedirectToAction("Login");
                }
            }

            return View(user);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}