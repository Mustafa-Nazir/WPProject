using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WPWebApp.Controllers
{


    public class UserController : Controller
    {

        SignInManager<ApplicationUser> _signInManager;
        IApplicationUserService _applicationUserService;

        public UserController(SignInManager<ApplicationUser> signInManager, IApplicationUserService applicationUserService)
        {
            _signInManager = signInManager;
            _applicationUserService=applicationUserService;
        }

        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                ApplicationUser user = _applicationUserService.GetUserByName(User.Identity.Name).Data;
                return View(user);
            }
            return Redirect("Identity/Account/Login");
        }

        [HttpGet("byUserName")]
        public IActionResult Index(string userName)
        {
            if (_signInManager.IsSignedIn(User))
            {
                if (userName == null) return Redirect("Home");
                ApplicationUser user = _applicationUserService.GetUserByName(userName).Data;
                return View(user);
            }
            return Redirect("Identity/Account/Login");
        }
    }
}
