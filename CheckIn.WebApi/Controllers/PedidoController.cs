using MediatR;
using Microsoft.AspNetCore.Mvc;
using CheckIn.Application.Dto.CheckIn;
using CheckIn.Application.Dto.Pedido;
using CheckIn.Application.UseCases.Command.Pedidos.CrearPedido;
using CheckIn.Application.UseCases.Queries.Pedidos.GetPedidoById;
using CheckIn.Application.UseCases.Queries.Pedidos.GetPedidosCancelados;
using System;
using System.Threading.Tasks;
using CheckIn.Application.UseCases.Queries.CheckIn;

namespace CheckIn.WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CheckInController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CheckInController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearPedidoCommand command)
        {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest();

            return Ok(id);
        }

        [Route("{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> GetPedidoById([FromRoute] GetPedidoByIdQuery command)
        {
            PedidoDto result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        
        [Route("search")]
        [HttpPost]
        public async Task<IActionResult> Search([FromBody] SearchPedidosQuery query)
        {
            var pedidos = await _mediator.Send(query);

            if (pedidos == null)
                return BadRequest();

            return Ok(pedidos);
        }
        /*
        [Route("buscar")]
        [HttpPost]
        public async Task<IActionResult> Search([FromBody] SearchCheckInQuery query)
        {
            var checks = await _mediator.Send(query);

            if (checks == null)
                return BadRequest();

            return Ok(checks);
        }
        */
    }
}
