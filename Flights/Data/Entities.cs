using Flights.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flights.Data
{
	public class Entities : DbContext
	{
		public DbSet<Passenger> Passengers =>Set<Passenger>();
		public DbSet<Flight> Flights => Set<Flight>();
	}
}
