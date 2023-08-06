using Application.Models.Enums;
using Application.Models;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Auth
{
    public class SignOutModel : PageModel
    {
        private IUserService _userService;

        public SignOutModel(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> OnGet()
        {
            await _userService.SignOut();

            return RedirectToPage("/Index");
        }
    }
}
