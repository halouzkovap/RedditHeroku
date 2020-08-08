using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Reddit.Entities;
using Reddit.ViewModel;
using System;
using System.Threading.Tasks;

namespace Reddit.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<UserReddit> userManager;
        private readonly SignInManager<UserReddit> signInManager;


        public UserController(UserManager<UserReddit> userManager, SignInManager<UserReddit> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

        }

        [HttpGet]
        [AllowAnonymous]

        public IActionResult Register()
        {
            var model = new RegisterViewModel();
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new UserReddit { Name = model.Name, UserName = model.UserName, Email = model.Email };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    throw new InvalidOperationException("Could not create user ");
                }
            }
            else
            {
                return View("Register");

            }
        }
    }
}