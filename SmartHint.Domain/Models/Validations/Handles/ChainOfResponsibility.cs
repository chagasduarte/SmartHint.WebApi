using SmartHint.Domain.Models;

namespace SmartHint.Domain.Validations.Handles
{
    public class ChainOfResponsibility
    {
        public readonly AbstractHandler _handler;
        public ChainOfResponsibility(AbstractHandler handle) 
        { 
           _handler = handle;
        }
        public ValidationModel Validation(Cliente cliente)
        {
            return _handler.Handle(cliente);
        }
    }
}
