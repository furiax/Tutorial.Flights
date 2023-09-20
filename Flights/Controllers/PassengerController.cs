using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Flights.Dtos;

namespace Flights.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class PassengerController : ControllerBase
	{
		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(500)]
		public IActionResult Register(NewPassengerDto dto)
		{
			throw new NotImplementedException();
		}
	}
}
