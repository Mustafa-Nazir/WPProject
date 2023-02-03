using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WPWebApp.Models;

namespace WPWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        IApplicationUserService _applicationUserService;
        private readonly IImageDetailService _imageDetailService;

        public HomeController
            (SignInManager<ApplicationUser> signInManager, 
            ILogger<HomeController> logger,
            IApplicationUserService applicationUserService,
            IImageDetailService imageDetailService)
        {
            _signInManager = signInManager;
            _logger = logger;
            _applicationUserService = applicationUserService;
            _imageDetailService = imageDetailService;
        }

        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return View();
            }
            return Redirect("Identity/Account/Login");
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

        [HttpPost]
        public IActionResult AddEmojiToImage(ImageDetail imageDetail)
        {
            var result = _imageDetailService.Add(imageDetail);
            return JsonConverter(result);
        }

        [HttpPost]
        public IActionResult DeleteEmojiFromImage(ImageDetail imageDetail)
        {
            var _imageDetail = _imageDetailService.GetImageDetailByImageEmojiUserId(imageDetail).Data;
            var result = _imageDetailService.Delete(_imageDetail);
            return JsonConverter(result);
        }

        [HttpGet]
        public IActionResult ImageEmojiControl(ImageDetail imageDetail)
        {
            var result = _imageDetailService.ImageEmojiControl(imageDetail);
            return JsonConverter(result);
        }

        private IActionResult JsonConverter(Core.Utilities.Results.IResult result)
        {
            var json = JsonConvert.SerializeObject(result);
            return Json(json);
        }

    }
}