import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Training } from '../models/training';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TrainingService {
  private baseURL: string = 'https://localhost:44359/api/Team';

  constructor(private httpClient: HttpClient) {}

  getTrainingById(trainingId: string): Observable<Training> {
    return this.httpClient.get<Training>(`${this.baseURL}/${trainingId}`);
  }

  getAllTrainings(): Observable<Training[]> {
    return this.httpClient.get<Training[]>(this.baseURL);
  }
}
