using SmartHint.Domain.Context;
using SmartHint.Domain.Models.Validations.Handles;
using SmartHint.Domain.Validations.Handles;
using System.ComponentModel.DataAnnotations;

namespace SmartHint.Domain.Models.Validations.Handles
{
    public class CamposPessoaFisicaHandler: AbstractHandler
    {
        public override ValidationModel Handle(Cliente request)
        {
            ValidationModel model = new ValidationModel();

            if (request.TipoPessoa == TipoPessoa.Fisica)
            {
                if(request.DataNascimento is null)
                {
                    model.MessageError = "A data de nascimento é obrigatória para pessoa fisica";
                    model.IsError = true;
                    return model;
                }
                if(request.Genero is null)
                {
                    model.MessageError = "O campo Genero é obrigatório";
                    model.IsError = true;
                    return model;
                }
                return base.Handle(request);
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}
