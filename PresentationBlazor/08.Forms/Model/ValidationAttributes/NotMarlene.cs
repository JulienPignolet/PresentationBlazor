using System.ComponentModel.DataAnnotations;

namespace _08.Forms.Model.ValidationAttributes
{
    public class NotMarlene : ValidationAttribute
    {
        private const string FORBIDDEN_FIRST_NAME = "Marlene";

        private const string ERROR_MESSAGE = $"Sorry first name {FORBIDDEN_FIRST_NAME} is forbidden !";

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
            return value switch
            {
                FORBIDDEN_FIRST_NAME => new ValidationResult(ERROR_MESSAGE),
                _ => ValidationResult.Success
            };
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
        }
    }
}
