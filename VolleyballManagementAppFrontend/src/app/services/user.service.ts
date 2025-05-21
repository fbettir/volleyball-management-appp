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

  getUserById(teamId: string): Observable<User> {
    return this.httpClient.get<User>(`${this.baseURL}/${teamId}`);
  }

  getAllUsers(): Observable<User[]> {
    return this.httpClient
      .get<User[]>(this.baseURL)
      .pipe(map((users) => this.sortUsersByName(users)));
  }

  insertUser(user: User): void {
    this.httpClient.post(this.baseURL, user).subscribe((t) => {
      console.log(t);
    });
  }

  deleteUserById(userId: string): void {
    this.httpClient.delete(`${this.baseURL}/${userId}`);
  }

  modifyUserById(user: User): void {
    this.httpClient.put(`${this.baseURL}/${user.id}`, user);
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
