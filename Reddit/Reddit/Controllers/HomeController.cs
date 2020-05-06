using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Reddit.Models;
using Reddit.Servises;
using Reddit.ViewModel;
using System;
using System.Diagnostics;

namespace Reddit.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IPostService postService;

        public HomeController(ILogger<HomeController> logger, IPostService postService)
        {
            this.logger = logger;
            this.postService = postService;
        }


        public IActionResult Index()
        {
            var posts = postService.Gell10BestPost();
            return View(new PostViewModel
            {
                Posts = posts
            });
        }


        public IActionResult List(string searchString)
        {

            var posts = postService.GetAllPost();

            if (!String.IsNullOrEmpty(searchString))
            {
                posts = postService.FindPost(searchString);

            }

            return View(posts);
        }

        //[HttpPost]
        //public string List(string searchString, bool notUsed)
        //{
        //    return "From [HttpPost]Index: filter on " + searchString;
        //}

        [HttpGet]
        [Authorize]
        public IActionResult Voting(int number, int id)
        {
            postService.Voting(number, id);
            //var post = postService.GellAllPost();
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
