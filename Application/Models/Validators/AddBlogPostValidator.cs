using Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Validators
{
    public class AddBlogPostValidator : AbstractValidator<AddBlogPostModel>
    {
        public AddBlogPostValidator()
        {
            RuleFor(x => x.Heading)
                .NotEmpty();

            RuleFor(x => x.PageTitle)
                .NotEmpty();

            RuleFor(x => x.Content)
                .NotEmpty();

            RuleFor(x => x.ShortDescription)
                .NotEmpty();

            RuleFor(x => x.FeaturedImageUrl)
                .NotEmpty();

            RuleFor(x => x.UrlHandle)
                .NotEmpty();

            RuleFor(x => x.Author)
                .NotEmpty();
        }
    }
}
