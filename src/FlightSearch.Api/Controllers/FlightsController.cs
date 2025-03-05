using FlightSearch.Api.Application.Commands;
using FlightSearch.Api.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlightSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FlightsController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetFlights([FromQuery] string? departure, [FromQuery] string? arrival, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        => Ok(await _mediator.Send(new GetFlightsQuery(departure, arrival, page, pageSize)));

        [HttpGet("external")]
        public async Task<IActionResult> GetExternalFlights([FromQuery] string departure, [FromQuery] string arrival)
            => Ok(await _mediator.Send(new GetAndStoreExternalFlightsQuery(departure, arrival)));

        [HttpPost]
        public async Task<IActionResult> AddFlight([FromBody] CreateFlightCommand command)
            => Ok(await _mediator.Send(command));
    }
}
