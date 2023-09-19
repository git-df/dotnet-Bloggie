using Application.Models;
using Application.Models.Enums;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Auth
{
    public class SignUpModel : PageModel
    {
        private readonly IUserService _userService;

        [BindProperty]
        public SignUpUserModel SignUpUser { get; set; }

        public SignUpModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var response = await _userService.SignUp(SignUpUser);

            ModelState.Clear();

            if (response.ValidationErrors.Any())
            {
                foreach (var error in response.ValidationErrors)
                {
                    ModelState.AddModelError("SignUpUser."+error.Property, error.Message);
                }
            }


            if (response.AlertType != MessageAlertType.None)
            {
                TempData["Alert"] = AlertModel.GetJsonString(response.Message, response.AlertType);
            }

            if (response.Success)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}
