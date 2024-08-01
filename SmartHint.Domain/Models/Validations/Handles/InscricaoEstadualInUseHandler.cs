using SmartHint.Domain.Context;
using SmartHint.Domain.Validations.Handles;
using Microsoft.Extensions.Configuration;
using System.Configuration;
namespace SmartHint.Domain.Models.Validations.Handles
{
    public class InscricaoEstadualInUseHandler: AbstractHandler
    {
        private readonly AppDbContext _appDbContext = new AppDbContext();

        public override ValidationModel Handle(Cliente request)
        {
            ValidationModel model = new ValidationModel();

            if (!request.Isento && _appDbContext.Clientes.Where(x => x.InscricaoEstadual == request.InscricaoEstadual).Count() > 0)
            {
                model.MessageError = "Essa Inscrição Estadual já está vinculada à outro Comprador";
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
