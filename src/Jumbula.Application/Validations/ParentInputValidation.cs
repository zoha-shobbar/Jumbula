using Jumbula.Application.Dtos;
using FluentValidation;
using System;
using Jumbula.Domain.Enums;

namespace Jumbula.Application.Validations;
public class ParentInputValidation : AbstractValidator<SignUpParentInputDto>
{
    public ParentInputValidation()
    {
        RuleFor(x => x.Gender)
            .Must(BeValidEnumName)
            .WithMessage("Invalid gender type");

        RuleFor(x => x.DateOfBirth)
            .LessThan(DateTime.Now.AddYears(-1));
    }

    private bool BeValidEnumName(string enumName)
    {
        if (string.IsNullOrWhiteSpace(enumName))
            return false;

        return Enum.TryParse(typeof(Gender), enumName, ignoreCase: true, out _);
    }
}
