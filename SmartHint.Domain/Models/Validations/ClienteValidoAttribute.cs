using SmartHint.Domain.Models;
using System.ComponentModel.DataAnnotations;
using SmartHint.Domain.Validations.Handles;
using SmartHint.Domain.Interfaces;
using System.Configuration;

namespace SmartHint.Domain.Validations
{
    public class ClienteValidoAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            return true
                ? new ValidationResult(errorMessage: "Arreguei")
                : ValidationResult.Success;
        }
    }
}
