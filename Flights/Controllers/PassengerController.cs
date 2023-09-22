﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Flights.Dtos;
using Flights.ReadModels;
using Flights.Domain.Entities;
using Flights.Data;

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
			Entities.Passengers.Add(new Passenger(
				dto.Email,
				dto.FirstName,
				dto.LastName,
				dto.Gender));

			System.Diagnostics.Debug.WriteLine(Entities.Passengers.Count);
			return CreatedAtAction(nameof(Find), new { email = dto.Email });
		}

		[HttpGet("{email}")]
		public ActionResult<PassengerRm> Find(string email)
		{
			var passenger  = Entities.Passengers.FirstOrDefault(p => p.Email == email);

			if (passenger == null)
			{
				return NotFound();
			}

			var rm = new PassengerRm(
				passenger.Email,
				passenger.FirstName,
				passenger.LastName,
				passenger.Gender);

			return Ok(rm);
		}
	}
}
