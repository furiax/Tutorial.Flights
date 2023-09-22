using Flights.ReadModels;
using Microsoft.AspNetCore.Mvc;
using Flights.Dtos;
using Flights.Data;
using Flights.Domain.Errors;

namespace Flights.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class FlightController : ControllerBase
	{
		private readonly ILogger<FlightController> _logger;

		static Random random = new Random();

		public FlightController(ILogger<FlightController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		[ProducesResponseType(400)]
		[ProducesResponseType(500)]
		[ProducesResponseType(typeof(IEnumerable<FlightRm>), 200)]
		public IEnumerable<FlightRm> Search()
		{
			var flightRmList = Entities.Flights.Select(flight => new FlightRm(
				flight.Id,
				flight.Airline,
				flight.Price,
				new TimePlaceRm(flight.Departure.Place.ToString(), flight.Departure.Time),
				new TimePlaceRm(flight.Arrival.Place.ToString(), flight.Arrival.Time),
				flight.RemainingNumberOfSeats
				));
			return flightRmList;
		}

		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[HttpGet("{id}")]
		[ProducesResponseType(400)]
		[ProducesResponseType(500)]
		[ProducesResponseType(typeof(FlightRm), 200)]
		public ActionResult<FlightRm> Find(Guid id)
		{
			var flight = Entities.Flights.SingleOrDefault(f => f.Id == id);

			if (flight == null)
				return NotFound();

			var readModel = new FlightRm(
				flight.Id,
				flight.Airline,
				flight.Price,
				new TimePlaceRm(flight.Departure.Place.ToString(),flight.Departure.Time),
				new TimePlaceRm(flight.Arrival.Place.ToString(), flight.Arrival.Time),
				flight.RemainingNumberOfSeats
				);
			return Ok(readModel);
		}

		[HttpPost]
		[ProducesResponseType(400)]
		[ProducesResponseType(500)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(200)]
		public IActionResult Book(BookDto dto)
		{
			System.Diagnostics.Debug.WriteLine($"Booking a new flight {dto.FlightId}");

			var flight = Entities.Flights.SingleOrDefault(f => f.Id == dto.FlightId);

			if (flight == null)
				return NotFound();

			var error = flight.MakeBooking(dto.PassengerEmail, dto.NumberOfSeats);
			if(error is OverbookError)
				return Conflict(new { message = "The number of requested seats exceeds the number of remaining seats." });

			return CreatedAtAction(nameof(Find), new {id = dto.FlightId});
		}
	}
}