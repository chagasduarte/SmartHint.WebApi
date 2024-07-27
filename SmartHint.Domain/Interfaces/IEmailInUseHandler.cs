using SmartHint.Domain.Models;

namespace SmartHint.Domain.Interfaces
{
    public interface IEmailInUseHandler
    {
        public ValidationModel Handle(Cliente request);

    }
}
