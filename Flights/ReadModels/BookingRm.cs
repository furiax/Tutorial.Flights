using Flights.Domain.Entities;

namespace Flights.ReadModels
{
	public record BookingRm
	(
		Guid FlightId,
		string Airline,
		string Price,
		TimePlace Arrival,
		TimePlace Departure,
		int NumberOfBookedSeats,
		string PassengerEmail
		);
}
