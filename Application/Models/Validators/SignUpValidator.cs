using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Validators
{
    public class SignUpValidator : AbstractValidator<SignUpUserModel>
    {
        public SignUpValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("User name is required");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Email is incorect");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required")
                .MinimumLength(8)
                .WithMessage("Minimum 8 character");
        }
    }
}
