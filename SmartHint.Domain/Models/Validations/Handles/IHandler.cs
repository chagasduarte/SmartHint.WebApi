using SmartHint.Domain.Models;

namespace SmartHint.Domain.Validations.Handles
{
    public interface IHandler
    {
        public IHandler SetNext(IHandler handler);

        ValidationModel Handle(Cliente request);
    }
}
