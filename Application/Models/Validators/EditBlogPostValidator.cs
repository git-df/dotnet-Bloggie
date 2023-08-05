using Application.Models;
using FluentValidation;

namespace Application.Models.Validators
{
    public class EditBlogPostValidator : AbstractValidator<EditBlogPostModel>
    {
        public EditBlogPostValidator()
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