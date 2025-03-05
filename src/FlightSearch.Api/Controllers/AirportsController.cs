using FlightSearch.Api.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlightSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AirportsController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAirports([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
            => Ok(await _mediator.Send(new GetAirportsQuery(page, pageSize)));

        [HttpGet("external")]
        public async Task<IActionResult> GetExternalAirports([FromQuery] string? searchTerm = null)
        => Ok(await _mediator.Send(new GetAndStoreExternalAirportsQuery(searchTerm)));
    }
}
