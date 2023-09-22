using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Flights.Data;
using Flights.ReadModels;

namespace Flights.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BookingController : ControllerBase
	{
		private readonly Entities _entities;
        public BookingController(Entities entities)
        {
            _entities = entities;
        }

		[HttpGet("{email}")]
		[ProducesResponseType(500)]
		[ProducesResponseType(400)]
		[ProducesResponseType(typeof(IEnumerable<BookingRm>),200)]
		public ActionResult<IEnumerable<BookingRm>> List(string email)
		{

		}
    }
}
