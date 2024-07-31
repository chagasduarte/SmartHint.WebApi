using SmartHint.Domain.Context;
using SmartHint.Domain.Models;
using SmartHint.Domain.Models.Validations.Handles;

namespace SmartHint.Domain.Models.Validations.Handles
{
    public class EmailInUseHandler : AbstractHandler
    {
        private readonly AppDbContext _appDbContext = new AppDbContext();
        
        public override ValidationModel Handle(Cliente request)
        {
            ValidationModel model = new ValidationModel();

            if (_appDbContext.Clientes.Where(x => x.Email == request.Email).Count() > 0)
            {
                model.MessageError = "O Email já está vinculado a outro Comprador.";
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
