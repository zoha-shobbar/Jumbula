using FluentValidation.Results;

namespace Jumbula.Infrastructure.Extensions;
public static class ValidationExtentions
{
    public static string GetAllErrorsString(this ValidationResult result)
    {
        string errormessage = string.Empty;

        if (!result.IsValid)
            errormessage = string.Join(" | ", result.Errors.Select(x => x.ErrorMessage));

        return errormessage;
    }
}
