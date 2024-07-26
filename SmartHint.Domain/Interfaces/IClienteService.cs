using SmartHint.Domain.DTos;
using SmartHint.Domain.Models;

namespace SmartHint.Domain.Interfaces
{
    public interface IClienteService
    {
        public Task<ResponseGeneric<List<Cliente>>> GetClientes();
        public Task<ResponseGeneric<Cliente>> PostClientes(Cliente cliente);
    }
}
