using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using System.Text;
using WPWebApp.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace WPWebApp.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly IApplicationUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AdminController(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            IApplicationUserService userService)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserInfo()
        {
            return View();
        }

        public IActionResult UserAdd()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserAdd(RegisterModel.InputModel Input)
        {

            var user = Activator.CreateInstance<ApplicationUser>();
            await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, Input.Password);
            if (result.Succeeded)
            {

                var userId = await _userManager.GetUserIdAsync(user);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                
                
                await _signInManager.SignInAsync(user, isPersistent: false);
                
            }

            return View();
        }

        public IActionResult UserDelete()
        {

            return View();
        }
        [HttpPost]
        public IActionResult UserDelete(ApplicationUser user)
        {
            ApplicationUser _user = _userService.GetUserByName(user.Email).Data;
            _userService.Delete(_user);
            return View();
        }
        public IActionResult UserUpdate()
        {

            return View();
        }
        [HttpPost]
        public IActionResult UserUpdate(ApplicationUser user)
        {
            ApplicationUser _user = _userService.GetUserByName(user.Email).Data;
            _user.PPPath = "default.png";
            _userService.Update(_user);
            return View();
        }


        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }

    }
}
