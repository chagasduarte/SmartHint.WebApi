using SmartHint.Domain.Context;
using SmartHint.Domain.Validations.Handles;

namespace SmartHint.Domain.Models.Validations.Handles
{
    public class CpfCnjInUseHandler : AbstractHandler
    {
        private readonly AppDbContext appDbContext = new AppDbContext();
        public override ValidationModel Handle(Cliente request)
        {
            ValidationModel model = new ValidationModel();

            if (appDbContext.Clientes.Where(x => x.CpfCnpj == request.CpfCnpj).Count() > 0)
            {
                if (request.CpfCnpj.Length > 12)
                {
                    model.MessageError = "O CNPJ já está em uso.";
                }
                if (request.CpfCnpj.Length < 12)
                {
                    model.MessageError = "O CPF já está em uso";
                }
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
