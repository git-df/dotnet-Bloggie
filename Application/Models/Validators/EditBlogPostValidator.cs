using Application.Models;
using FluentValidation;

namespace Application.Models.Validators
{
    public class EditBlogPostValidator : AbstractValidator<EditBlogPostModel>
    {
        public EditBlogPostValidator()
        {
            RuleFor(x => x.Heading)
                .NotEmpty()
                .WithMessage("Heading is required");

            RuleFor(x => x.PageTitle)
                .NotEmpty()
                .WithMessage("Page Title is required");

            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Content is required");

            RuleFor(x => x.ShortDescription)
                .NotEmpty()
                .WithMessage("Short Description is required");

            RuleFor(x => x.FeaturedImageUrl)
                .NotEmpty()
                .WithMessage("Featured ImageUrl is required");

            RuleFor(x => x.UrlHandle)
                .NotEmpty()
                .WithMessage("Url Handle is required");

            RuleFor(x => x.Author)
                .NotEmpty()
                .WithMessage("Author is required");

            RuleFor(x => x.PublishedDate)
                .NotEmpty()
                .WithMessage("Date is required")
                .Must(x => x >= DateTime.UtcNow.Date)
                .WithMessage("The date cannot be past");
        }
    }
}