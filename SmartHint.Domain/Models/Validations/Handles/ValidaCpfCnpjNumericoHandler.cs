using SmartHint.Domain.Validations.Handles;
using System.Text.RegularExpressions;

namespace SmartHint.Domain.Models.Validations.Handles
{
    public class ValidaCpfCnpjNumericoHandler: AbstractHandler
    {
        public override ValidationModel Handle(Cliente request)
        {
            ValidationModel model = new ValidationModel();

            if (!Regex.IsMatch("[0-9]", request.CpfCnpj))
            {
                model.MessageError = "O CPF/CNPJ não é válido";
                model.IsError = true;
                return model;
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}
