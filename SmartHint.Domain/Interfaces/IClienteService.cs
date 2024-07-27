using SmartHint.Domain.DTos;
using SmartHint.Domain.Models;
using SmartHint.Domain.Validations;

namespace SmartHint.Domain.Interfaces
{
    public interface IClienteService
    {
        public Task<ResponseGeneric<PagedList<Cliente>>> GetClientes(int pageNumer, int pageSize);
        public Task<ResponseGeneric<Cliente>> GetCliente(int id);

        [ClienteValido]
        public Task<ResponseGeneric<Cliente>> PostCliente(Cliente cliente);
        public Task<ResponseGeneric<Cliente>> PutCliente(int id, Cliente cliente);
        public Task<ResponseGeneric<Cliente>> DeleteCliente(int id);
    }
}
