using SmartHint.Domain.Context;
using SmartHint.Domain.Models;

namespace SmartHint.Domain.Models.Validations.Handles
{
    public interface IHandler
    {
        public IHandler SetNext(IHandler handler);

        ValidationModel Handle(Cliente request);
    }
}
