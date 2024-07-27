using Microsoft.EntityFrameworkCore;
using SmartHint.Domain.DTos;
using SmartHint.Domain.Interfaces;
using SmartHint.Domain.Models;
using SmartHint.Infrastruct.Context;
using SmartHint.Infrastruct.Helpers;
using System.Dynamic;
using System.Net;
using System.Numerics;

namespace SmartHint.Infrastruct.Services
{
    public class ClienteService : IClienteService
    {
        private readonly AppDbContext _context;
        public ClienteService(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<ResponseGeneric<PagedList<Cliente>>> GetClientes(int pageNumer, int pageSize)
        {
            ResponseGeneric<PagedList<Cliente>> response = new ResponseGeneric<PagedList<Cliente>>();

            try
            {
                var query = _context.Clientes.AsQueryable();
                response.ReturnData = await PaginationHelper.CreateAsync(query, pageNumer, pageSize);
                response.StatusCode = HttpStatusCode.OK;
            }
            catch
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.ReturnError = new ExpandoObject();
            }
             
            return response;
        }

        public async Task<ResponseGeneric<Cliente>> GetCliente(int id)
        {
            ResponseGeneric<Cliente> response = new ResponseGeneric<Cliente>();

            try
            {
                response.ReturnData = await _context.Clientes.FindAsync(id);
                response.StatusCode = HttpStatusCode.OK;
            }
            catch
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.ReturnError = new ExpandoObject();
            }

            return response;
        }
        []
        public async Task<ResponseGeneric<Cliente>> PostCliente(Cliente cliente)
        {
            ResponseGeneric<Cliente> response = new ResponseGeneric<Cliente>();
            try
            {
                if(_context.Clientes.Where(x => x.CpfCnpj == cliente.CpfCnpj).Count() >= 1)
                {
                    response.StatusCode=HttpStatusCode.BadRequest;
                    response.MessageError = "O valor registrado para CPF/CNPJ já está em uso";
                }
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

        public async Task<ResponseGeneric<Cliente>> PutCliente(int id, Cliente cliente)
        {
            ResponseGeneric<Cliente> response = new ResponseGeneric<Cliente>();

            if(id != cliente.Id)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.ReturnError = new ExpandoObject();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                response.StatusCode = HttpStatusCode.OK;
                response.ReturnData = cliente;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExist(id))
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.ReturnError = new ExpandoObject();
                }
            }

            return response;
        }

        public async Task<ResponseGeneric<Cliente>> DeleteCliente(int id)
        {
            ResponseGeneric<Cliente> response = new ResponseGeneric<Cliente>();

            var player = await _context.Clientes.FindAsync(id);
            if (player == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.ReturnError = new ExpandoObject();
            }
            else
            {
                response.StatusCode = HttpStatusCode.OK;
                response.ReturnData = player;
            }

            _context.Clientes.Remove(player);
            await _context.SaveChangesAsync();

            return response;
        }

        private bool ClienteExist(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }


    }
}
