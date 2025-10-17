using Week3.Commands;

namespace Week3.Validators;

using FluentValidation;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MinimumLength(2).WithMessage("Title must be at least 2 characters long.");

        RuleFor(x => x.Author)
            .NotEmpty().WithMessage("Author is required.");

        RuleFor(x => x.Year)
            .InclusiveBetween(1000, DateTime.UtcNow.Year)
            .WithMessage($"Year must be between 1000 and {DateTime.UtcNow.Year}.");
    }
}
