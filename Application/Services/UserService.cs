﻿using Application.Models;
using Application.Models.Enums;
using Application.Models.Responses;
using Application.Models.Validators;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BaseResponse> SignIn(SignInUserModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

            if (result.Succeeded)
            {
                return new BaseResponse("Success sign in", MessageAlertType.Success);
            }

            return new BaseResponse(false, "Something went wrong", MessageAlertType.Error);
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<BaseResponse> SignUp(SignUpUserModel model)
        {
            var validator = new SignUpValidator();
            var validationResult = await validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                return new BaseResponse(validationResult);
            }

            var user = new IdentityUser()
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var resultAddRole = await _userManager.AddToRoleAsync(user, "User");

                if (resultAddRole.Succeeded)
                {
                    return new BaseResponse("User created", MessageAlertType.Success);
                }
            }

            return new BaseResponse(false, "Something went wrong", MessageAlertType.Error);
        }


    }
}
