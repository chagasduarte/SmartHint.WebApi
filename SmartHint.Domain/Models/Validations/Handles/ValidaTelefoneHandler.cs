using SmartHint.Domain.Validations.Handles;
using System.Text.RegularExpressions;

namespace SmartHint.Domain.Models.Validations.Handles
{
    public class ValidaTelefoneHandler: AbstractHandler
    {
        public override ValidationModel Handle(Cliente request)
        {
            ValidationModel model = new ValidationModel();

            if (!Regex.IsMatch("[0-9]", request.Telefone) && request.Telefone.Length != 11)
            {
                model.MessageError = "O Telefone não é válido";
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
