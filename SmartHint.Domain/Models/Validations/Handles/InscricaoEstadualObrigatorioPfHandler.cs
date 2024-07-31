using SmartHint.Domain.Context;
using SmartHint.Domain.Validations.Handles;

namespace SmartHint.Domain.Models.Validations.Handles
{
    public class InscricaoEstadualObrigatorioPfHandler: AbstractHandler
    {
        private readonly AppDbContext _appDbContext = new AppDbContext();

        public override ValidationModel Handle(Cliente request)
        {
            ValidationModel model = new ValidationModel();

            if (!request.Isento && request.InscricaoEstadual is null)
            {
                model.MessageError = "O campo Inscrição Estadual é Obrigatório para essa Pessoa Fisica";
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
