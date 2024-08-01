using SmartHint.Domain.Validations.Handles;
using System.Text.RegularExpressions;

namespace SmartHint.Domain.Models.Validations.Handles
{
    public class ValidaCpfCnpjNumericoHandler: AbstractHandler
    {
        public override ValidationModel Handle(Cliente request)
        {
            ValidationModel model = new ValidationModel();


            if (!Regex.IsMatch(request.CpfCnpj, "^[0-9]{11}") &&
                !Regex.IsMatch(request.CpfCnpj, "^[0-9]{14}"))
            {
                model.MessageError = "O CPF/CNPJ não é válido";
                model.IsError = true;
                return model;
            }
            else
            {
                model.IsError = false;
                return base.Handle(request);
            }
        }
    }
}
