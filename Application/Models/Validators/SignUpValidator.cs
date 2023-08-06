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
                .NotEmpty();

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}
