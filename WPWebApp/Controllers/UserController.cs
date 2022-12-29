using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WPWebApp.Controllers
{


    public class UserController : Controller
    {

        SignInManager<IdentityUser> _signInManager;

        public UserController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return View();
            }
            return Redirect("Identity/Account/Login");
        }
    }
}
