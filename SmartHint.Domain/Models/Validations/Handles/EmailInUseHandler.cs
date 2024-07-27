using Google.Protobuf.WellKnownTypes;
using SmartHint.Domain.Models;
using SmartHint.Domain.Context;
using SmartHint.Domain.Interfaces;

namespace SmartHint.Domain.Validations.Handles
{
    public class EmailInUseHandler : AbstractHandler
    {
        private readonly AppDbContext _context;
        public EmailInUseHandler(AppDbContext contexto) 
        { 
            _context = contexto;
        }

        public override ValidationModel Handle(Cliente request)
        {
            ValidationModel model = new ValidationModel();

            if (_context.Clientes.Where(x => x.Email == request.Email).Count() > 0)
            {
                model.MessageError = "O Email já está em uso.";
                model.IsError = true;
                return model;
            }
            else
            {
                model.IsError = false;
                return model;
            }
        }

    }
}
