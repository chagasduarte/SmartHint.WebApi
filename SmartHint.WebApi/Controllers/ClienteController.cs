using Microsoft.AspNetCore.Mvc;
using SmartHint.Domain.DTos;
using SmartHint.Domain.Interfaces;
using SmartHint.Domain.Models;
using System.Net;

namespace SmartHint.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult> GetClientes([FromQuery] PaginationParams pagination)
        {
         
            var clientPageLis = await _clienteService.GetClientes(pagination.PageNumber, pagination.PageSize);

            var response = new ClienteResponse(clientPageLis.ReturnData, 
                                               clientPageLis.ReturnData.CurrentPage, 
                                               clientPageLis.ReturnData.TotalPage, 
                                               clientPageLis.ReturnData.PageSize,
                                               clientPageLis.ReturnData.TotalCount);
            if (clientPageLis.StatusCode == HttpStatusCode.OK)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode((int)clientPageLis.StatusCode, clientPageLis.ReturnError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCliente(int id)
        {
            var response = await _clienteService.GetCliente(id);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Ok(response.ReturnData);
            }
            else
            {
                return StatusCode((int)response.StatusCode, response.ReturnError);
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostClientes(Cliente cliente)
        {
            var response = await _clienteService.PostCliente(cliente);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Ok(response.ReturnData);
            }
            else
            {
                return StatusCode((int)response.StatusCode, response.ReturnError);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> PutClientes(int id, Cliente cliente)
        {
            var response = await _clienteService.PutCliente(id, cliente);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Ok(response.ReturnData);
            }
            else
            {
                return StatusCode((int)response.StatusCode, response.ReturnError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClientes(int id)
        {
            var response = await _clienteService.DeleteCliente(id);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Ok(response.ReturnData);
            }
            else
            {
                return StatusCode((int)response.StatusCode, response.ReturnError);
            }
        }
    }
}
