import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Location } from '../models/entities/location';

@Injectable({
  providedIn: 'root',
})
export class LocationService {
  private baseURL: string = 'https://localhost:44359/api/Location';

  constructor(private httpClient: HttpClient) {}

  getTLocationById(locationId: string): Observable<Location> {
    return this.httpClient.get<Location>(`${this.baseURL}/${locationId}`);
  }

  getAllLocations(): Observable<Location[]> {
    return this.httpClient.get<Location[]>(this.baseURL);
  }

  insertLocation(location: Location): void {
    this.httpClient.post(this.baseURL, location).subscribe((t) => {
      console.log(t);
    });
  }
  deleteLocationById(locationId: string): void {
    this.httpClient.delete(`${this.baseURL}/${locationId}`);
  }

  modifyLocationById(location: Location): void {
    this.httpClient.put(`${this.baseURL}/${location.id}`, location);
  }
}
