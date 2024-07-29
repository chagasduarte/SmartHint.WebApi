using SmartHint.Domain.Context;
using SmartHint.Domain.Validations.Handles;

namespace SmartHint.Domain.Models.Validations.Handles
{
    public class InscricaoEstadualObrigatorioPjHandler : AbstractHandler
    {
        private readonly AppDbContext _appDbContext = new AppDbContext();

        public override ValidationModel Handle(Cliente request)
        {
            ValidationModel model = new ValidationModel();

            if (request.TipoPessoa == TipoPessoa.Juridica && request.InscricaoEstadual is null)
            {
                model.MessageError = "O campo Inscrição Estadual é Obrigatório para Pessoa Juridica";
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
