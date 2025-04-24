using FluentValidation;
using NewbornRegistry.Common.Enums;

namespace NewbornRegistry.API.ViewModels.Update;

public class UpdatePatientViewModel
{
    public UpdateNameViewModel Name { get; set; }
    public Gender? Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public bool? Active { get; set; }
}

public class UpdatePatientViewModelValidator : AbstractValidator<UpdatePatientViewModel>
{
    public UpdatePatientViewModelValidator()
    {
        RuleFor(x => x.Name.Family)
            .NotEmpty()
            .WithMessage("Family is required.");

        RuleFor(x => x.BirthDate)
            .NotEmpty()
            .WithMessage("BirthDate is required.")
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("BirthDate can not be in the future.");

        RuleFor(x => x.Gender)
            .IsInEnum()
            .When(x => x.Gender.HasValue)
            .WithMessage("Invalid gender ID. Expected one of: 1 (Male), 2 (Female), 3 (Other), 4 (Unknown).");
    }
}