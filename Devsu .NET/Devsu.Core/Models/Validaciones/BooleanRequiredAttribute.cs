using System.ComponentModel.DataAnnotations;

namespace Devsu.Core.Models.Validaciones
{
    public class BooleanRequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return bool.TryParse(value?.ToString(), out _) ?
                ValidationResult.Success :
                new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
    }
}
