using SmartHint.Domain.Context;
using SmartHint.Domain.Interfaces;
using SmartHint.Domain.Models;

namespace SmartHint.Domain.Validations.Handles
{
    public class ChainOfResponsibility : IChainOfResponsibility
    {

        public IEmailInUseHandler _emailHandler;
        public ChainOfResponsibility(IEmailInUseHandler emailHandler)
        {
            _emailHandler = emailHandler;
        }
        public ValidationModel Validation(Cliente cliente)
        {
            return _emailHandler.Handle(cliente);
        }
    }
}
