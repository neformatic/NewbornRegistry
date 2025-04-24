using FluentValidation;
using NewbornRegistry.Common.Enums;

namespace NewbornRegistry.API.ViewModels.Create;

public class CreatePatientViewModel
{
    public CreateNameViewModel Name { get; set; }
    public Gender? Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public bool? Active { get; set; }
}

public class CreatePatientViewModelValidator : AbstractValidator<CreatePatientViewModel>
{
    public CreatePatientViewModelValidator()
    {
        RuleFor(x => x.Name.Family)
            .NotEmpty()
            .WithMessage("Family name is required.");

        RuleFor(x => x.BirthDate)
            .NotEmpty()
            .WithMessage("BirthDate is required.")
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("BirthDate can not be in the future.");

        RuleFor(x => x.Gender)
            .IsInEnum()
            .When(x => x.Gender.HasValue)
            .WithMessage("Gender must be one of: Male, Female, Other, Unknown.");
    }
}