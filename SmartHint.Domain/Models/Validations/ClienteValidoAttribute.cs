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
        InscricaoEstadualObrigatorioPjHandler inscricaoEstadualPjHandler = new InscricaoEstadualObrigatorioPjHandler();
        InscricaoEstadualObrigatorioPfHandler inscricaoEstadualPfHandler = new InscricaoEstadualObrigatorioPfHandler();
        InscricaoEstadualInUseHandler inscricaoEstadualInUse = new InscricaoEstadualInUseHandler();
        ValidaTelefoneHandler telefone = new ValidaTelefoneHandler();
        ValidaCpfCnpjNumericoHandler cpfCnjValido = new ValidaCpfCnpjNumericoHandler();
        InscricaoEstadualNumericaHandler inscricaoEstadualNumerica = new InscricaoEstadualNumericaHandler();

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Cliente cliente = value as Cliente;
            
            emailInUseHandler.SetNext(cpfCnjInUseHandler)
                    .SetNext(cpfCnjValido)
                    .SetNext(camposPessoaFisicaHandler)
                    .SetNext(inscricaoEstadualPjHandler)
                    .SetNext(inscricaoEstadualPfHandler)
                    .SetNext(inscricaoEstadualInUse)
                    .SetNext(inscricaoEstadualNumerica)
                    .SetNext(telefone);

            var validacao = new ChainOfResponsibility(emailInUseHandler).Validation((Cliente)value);
            return validacao.IsError && cliente.Id == 0
                ? new ValidationResult(errorMessage: validacao.MessageError)
                : ValidationResult.Success;
        }
    }
}
