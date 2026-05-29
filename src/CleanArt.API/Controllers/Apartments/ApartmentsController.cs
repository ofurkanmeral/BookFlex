using CleanArt.Application.Apartments.SearchApartments;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArt.API.Controllers.Apartments
{
    [Route("api/apartments")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly ISender _sender;

        public ApartmentsController(ISender sender)
        {
            _sender = sender;
        }
        [HttpGet]
        public async Task<IActionResult> SearchApartments(
            DateOnly startDate,
            DateOnly EndDate,
            CancellationToken cancellationToken)
        {
            var query = new SearchApartmentsQuery(startDate, EndDate);
            var result = await _sender.Send(query, cancellationToken);
            return Ok(result.Value);
        }
    }
}
