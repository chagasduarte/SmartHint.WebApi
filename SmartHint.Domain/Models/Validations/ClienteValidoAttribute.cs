using SmartHint.Domain.Models;
using SmartHint.Domain.Models.Validations.Handles;
using SmartHint.Domain.Validations.Handles;
using System.ComponentModel.DataAnnotations;

namespace SmartHint.Domain.Validations
{
    public class ClienteValidoAttribute : ValidationAttribute
    {
        EmailInUseHandler emailInUseHandler = new EmailInUseHandler();
        CpfCnjInUseHandler cpfCnjInUseHandler = new CpfCnjInUseHandler();
        CamposPessoaFisicaHandler camposPessoaFisicaHandler = new CamposPessoaFisicaHandler();
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            emailInUseHandler.SetNext(cpfCnjInUseHandler)
                             .SetNext(camposPessoaFisicaHandler);

            var validacao = new ChainOfResponsibility(emailInUseHandler).Validation((Cliente)value);
            return validacao.IsError
                ? new ValidationResult(errorMessage: validacao.MessageError)
                : ValidationResult.Success;
        }
    }
}
