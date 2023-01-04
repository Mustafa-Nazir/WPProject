using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Cryptography;

namespace WPWebApp.Controllers
{


    public class UserController : Controller
    {

        SignInManager<ApplicationUser> _signInManager;
        IApplicationUserService _applicationUserService;
        IFollowerService _followerService;

        public UserController
            (SignInManager<ApplicationUser> signInManager, 
            IApplicationUserService applicationUserService,
            IFollowerService followerService)
        {
            _signInManager = signInManager;
            _applicationUserService = applicationUserService;
            _followerService = followerService; 
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

        public IActionResult FollowUser(string UserId , string FollowedUserId ,string FollowedUser)
        {
            _followerService.Add(new Follower { UserId = UserId, FollowedUserId = FollowedUserId });
            return RedirectToAction("", "byUserName", new { userName = FollowedUser });
        }

        public IActionResult UnFollowUser(string UserId, string FollowedUserId, string FollowedUser)
        {
            _followerService.DeleteByUserAndFollowedUserId(UserId, FollowedUserId);
            return RedirectToAction("", "byUserName", new { userName = FollowedUser });

        }
    }
}
