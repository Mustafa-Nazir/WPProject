using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;

namespace WPWebApp.Areas.Identity.Pages.Account.Manage
{
    public class AddImageModel : PageModel
    {
        IImageService _imageService;
        IApplicationUserService _applicationUserService;

        public AddImageModel(IImageService imageService , IApplicationUserService applicationUserService)
        {
            _imageService = imageService;
            _applicationUserService = applicationUserService;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            public string? Description { get; set; }
            [Required]
            public IFormFile ImageFile { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (ModelState.IsValid)
            {
                string id = _applicationUserService.GetUserIdByName(User.Identity.Name).Data;
                _imageService.AddImage(new Image { UserId=id , Description=Input.Description} , Input.ImageFile);
                return RedirectToAction("", "User");
            }
            return Page();
        }
    }
}
