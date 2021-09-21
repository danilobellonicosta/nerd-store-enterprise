using Microsoft.AspNetCore.Mvc;
using NSE.Clientes.API.Application.Commands;
using NSE.Core.Mediator;
using NSE.WebAPI.Core.Controllers;
using System;
using System.Threading.Tasks;

namespace NSE.Clientes.API.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController : MainController
    {
        private readonly IMediatorHandler _mediator;

        public ClientesController(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("clientes")]
        public async Task<IActionResult> Index()
        {
            var result =  await _mediator.EnviarComando(new RegisterClienteCommand(Guid.NewGuid(), "Danilo", "costaalves.danilo@gmail.com", "24180117045"));

            return CustomResponse(result);
        }
    }
}
