using Application.Models;
using Application.Models.Enums;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Auth
{
    public class SignInModel : PageModel
    {
        private readonly IUserService _userService;

        [BindProperty]
        public SignInUserModel SignInUser { get; set; }

        [BindProperty(Name = "ReturnUrl", SupportsGet = true)]
        public string ReturnUrl { get; set; }

        public SignInModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var response = await _userService.SignIn(SignInUser);

            if (response.AlertType != MessageAlertType.None)
            {
                TempData["Alert"] = AlertModel.GetJsonString(response.Message, response.AlertType);
            }

            if (string.IsNullOrWhiteSpace(ReturnUrl))
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}
