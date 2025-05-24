import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { map } from 'rxjs/operators';
import { Team } from '../models/team';
import { Training } from '../models/training';
import { Tournament } from '../models/tournament';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private baseURL: string = 'https://localhost:44359/api/User';

  constructor(private httpClient: HttpClient) {}

  private sortUsersByName(users: User[]): User[] {
    return users
      .slice()
      .sort((a, b) =>
        a.name.localeCompare(b.name, 'en', {
          sensitivity: 'base',
          numeric: true,
        }),
      );
  }

  getUserById(userId: string): Observable<User> {
    return this.httpClient.get<User>(`${this.baseURL}/${userId}`);
  }

  getAllUsers(): Observable<User[]> {
    return this.httpClient
      .get<User[]>(this.baseURL)
      .pipe(map((users) => this.sortUsersByName(users)));
  }

  getAllCoaches(): Observable<User[]> {
  return this.httpClient
    .get<User[]>(`${this.baseURL}/coaches`)
    .pipe(map((users) => this.sortUsersByName(users)));
}

  insertUser(user: User): Observable<void> {
    return this.httpClient.post<void>(this.baseURL, user);
  }

  deleteUserById(userId: string): Observable<void> {
    return this.httpClient.delete<void>(`${this.baseURL}/${userId}`);
  }

  modifyUserById(user: User): Observable<void> {
    return this.httpClient.put<void>(`${this.baseURL}/${user.id}`, user);
  }

  registerFavouriteTeam(userId: string, team: Team): Observable<void> {
    return this.httpClient.post<void>(
      `${this.baseURL}/${userId}/favouriteTeams`,
      { teamId: team.id },
    );
  }

  removeFavouriteTeam(userId: string, team: Team): Observable<void> {
    return this.httpClient.request<void>(
      'delete',
      `${this.baseURL}/${userId}/favouriteTeams`,
      { body: { teamId: team.id } },
    );
  }

  registerFavouriteTraining(
    userId: string,
    training: Training,
  ): Observable<void> {
    return this.httpClient.post<void>(
      `${this.baseURL}/${userId}/favouriteTrainings`,
      { trainingId: training.id },
    );
  }

  removeFavouriteTraining(
    userId: string,
    training: Training,
  ): Observable<void> {
    return this.httpClient.request<void>(
      'delete',
      `${this.baseURL}/${userId}/favouriteTrainings`,
      { body: { trainingId: training.id } },
    );
  }

  registerFavouriteTournament(
    userId: string,
    tournament: Tournament,
  ): Observable<void> {
    return this.httpClient.post<void>(
      `${this.baseURL}/${userId}/favouriteTournaments`,
      { tournamentId: tournament.id },
    );
  }

  removeFavouriteTournament(
    userId: string,
    tournament: Tournament,
  ): Observable<void> {
    return this.httpClient.request<void>(
      'delete',
      `${this.baseURL}/${userId}/favouriteTournaments`,
      { body: { tournamentId: tournament.id } },
    );
  }
}
