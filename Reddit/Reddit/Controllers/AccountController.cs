using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Reddit.Entities;
using Reddit.ViewModel;
using System.Linq;
using System.Threading.Tasks;

namespace Reddit.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<UserReddit> signInManager;
        private readonly UserManager<UserReddit> userManager;

        public object ExternalAuthenticationDefaults { get; private set; }

        public AccountController(
          SignInManager<UserReddit> signInManager,
          UserManager<UserReddit> userManager
         )
        {

            this.signInManager = signInManager;
            this.userManager = userManager;

        }

        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {


            if (ModelState.IsValid)
            {

                var result = await signInManager.PasswordSignInAsync(model.Username,
                  model.Password,
                  model.RememberMe,
                  false);

                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }
                    else
                    {
                        return RedirectToAction("UserPost", "Post");
                    }
                }
            }

            ModelState.AddModelError("", "Failed to login");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}