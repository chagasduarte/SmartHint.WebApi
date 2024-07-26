using Microsoft.EntityFrameworkCore;
using SmartHint.Domain.DTos;
using SmartHint.Domain.Interfaces;
using SmartHint.Domain.Models;
using SmartHint.Infrastruct.Context;
using System.Dynamic;
using System.Net;

namespace SmartHint.Infrastruct.Services
{
    public class ClienteService : IClienteService
    {
        private readonly AppDbContext _context;
        public ClienteService(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<ResponseGeneric<List<Cliente>>> GetClientes()
        {
            ResponseGeneric<List<Cliente>> response = new ResponseGeneric<List<Cliente>>();

            try
            {
                response.ReturnData = await _context.Clientes.ToListAsync();
                response.StatusCode = HttpStatusCode.OK;
            }
            catch
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.ReturnError = new ExpandoObject();
            }
             
            return response;
        }

        public async Task<ResponseGeneric<Cliente>> PostClientes(Cliente cliente)
        {
            ResponseGeneric<Cliente> response = new ResponseGeneric<Cliente>();
            try
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                response.StatusCode = HttpStatusCode.OK;
                response.ReturnData = cliente;
            }
            catch
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.ReturnError = new ExpandoObject();
            }

            return response;
        }
    }
}
