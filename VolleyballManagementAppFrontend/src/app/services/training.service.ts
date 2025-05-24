import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Training } from '../models/training';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class TrainingService {
  private baseURL: string = 'https://localhost:44359/api/Training';

  constructor(private httpClient: HttpClient) {}

  
  private sortTrainingsByTeamName(trainings: Training[]): Training[] {
    return trainings.slice().sort(
      (a, b) =>
        a.team?.name.localeCompare(b.team?.name, 'en', {
          sensitivity: 'base',
        }),
    );
  }
  
  getTrainingById(trainingId: string): Observable<Training> {
    return this.httpClient.get<Training>(`${this.baseURL}/${trainingId}`);
  }
  
  getAllTrainings(): Observable<Training[]> {
    return this.httpClient
      .get<Training[]>(this.baseURL)
      .pipe(map((trainings) => this.sortTrainingsByTeamName(trainings)));
  }

  insertTraining(training: Training): Observable<Training> {
    return this.httpClient.post<Training>(this.baseURL, training);
  }

  modifyTrainingById(training: Training): Observable<void> {
    return this.httpClient.put<void>(`${this.baseURL}/${training.id}`, training);
  }

  deleteTraining(trainingId: string): Observable<void> {
    return this.httpClient.delete<void>(`${this.baseURL}/${trainingId}`);
  }


  registerTrainingParticipant(trainingId: string, userId: string): Observable<void> {
  return this.httpClient.post<void>(
    `${this.baseURL}/${trainingId}/participants`,
    { userId } // the backend expects this shape
  );
}

removeTrainingParticipant(trainingId: string, userId: string): Observable<void> {
  return this.httpClient.delete<void>(
    `${this.baseURL}/${trainingId}/participants/${userId}`
  );
}
}
