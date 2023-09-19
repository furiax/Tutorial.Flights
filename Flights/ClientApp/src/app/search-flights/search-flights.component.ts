import { Component } from '@angular/core';
import { FlightService } from './../api/services/flight.service';
import { FlightRm } from '../api/models';

@Component({
  selector: 'app-search-flights',
  templateUrl: './search-flights.component.html',
  styleUrls: ['./search-flights.component.css']
})
export class SearchFlightsComponent {

  searchResult: FlightRm[] = []

  constructor(private flightService: FlightService) { }

  search() {
    this.flightService.flightGet({})
    .subscribe(response => this.searchResult = response)
  }
}
