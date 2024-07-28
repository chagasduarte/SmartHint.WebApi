using SmartHint.Domain.Models;
using System.ComponentModel.DataAnnotations;
using SmartHint.Domain.Validations.Handles;
using SmartHint.Domain.Interfaces;
using System.Configuration;
using SmartHint.Domain.Models.Validations.Handles;

namespace SmartHint.Domain.Validations
{
    public class ClienteValidoAttribute : ValidationAttribute
    {
        EmailInUseHandler emailInUseHandler = new EmailInUseHandler();
        CpfCnjInUseHandler cpfCnjInUseHandler = new CpfCnjInUseHandler();
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            emailInUseHandler.SetNext(cpfCnjInUseHandler);
            var validacao = new ChainOfResponsibility(emailInUseHandler).Validation((Cliente)value);
            return validacao.IsError
                ? new ValidationResult(errorMessage: validacao.MessageError)
                : ValidationResult.Success;
        }
    }
}
