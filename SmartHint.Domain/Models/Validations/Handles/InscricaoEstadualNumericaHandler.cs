using SmartHint.Domain.Validations.Handles;
using System.Text.RegularExpressions;

namespace SmartHint.Domain.Models.Validations.Handles
{
    public class InscricaoEstadualNumericaHandler: AbstractHandler
    {
        public override ValidationModel Handle(Cliente request)
        {
            ValidationModel model = new ValidationModel();

            if (!request.Isento)
            {
                if (!Regex.IsMatch("[0-9]", request.InscricaoEstadual))
                {
                    model.MessageError = "Essa Inscrição Estadual não está em um formato Válido";
                    model.IsError = true;
                    return model;
                }
                if(request.InscricaoEstadual.Length != 12)
                {
                    model.MessageError = "O campo InscricaoEstadual edve conter 12 digitos";
                    model.IsError = true;
                    return model;
                }
            }
            model.IsError = false;
            return base.Handle(request);
        }
    }
}
