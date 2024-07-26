using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult> GetClientes()
        {
            var response = await _clienteService.GetClientes();
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
            var response = await _clienteService.PostClientes(cliente);

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
