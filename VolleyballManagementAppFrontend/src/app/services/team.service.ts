import { Injectable } from '@angular/core';
import { Team } from '../models/team';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class TeamService {
  private baseURL: string = 'https://localhost:44359/api/Team';

  constructor(private httpClient: HttpClient) {}

  private sortTeamsByNameNaturally(teams: Team[]): Team[] {
    return teams.slice().sort((a, b) =>
      a.name.localeCompare(b.name, 'en', {
        numeric: true,
        sensitivity: 'base',
      }),
    );
  }

  getTeamById(teamId: string): Observable<Team> {
    return this.httpClient.get<Team>(`${this.baseURL}/${teamId}`);
  }

  getAllTeams(): Observable<Team[]> {
    return this.httpClient
      .get<Team[]>(this.baseURL)
      .pipe(map((teams) => this.sortTeamsByNameNaturally(teams)));
  }

  insertTeam(team: Team): Observable<void> {
    return this.httpClient.post<void>(this.baseURL, team);
  }

  deleteTeamById(teamId: string): Observable<void> {
    return this.httpClient.delete<void>(`${this.baseURL}/${teamId}`);
  }

  modifyTeamById(team: Team): Observable<void> {
    return this.httpClient.put<void>(`${this.baseURL}/${team.id}`, team);
  }

  addPlayerToTeam(teamId: string, userId: string): Observable<void> {
    return this.httpClient.post<void>(`${this.baseURL}/${teamId}/players`, {
      userId,
    });
  }

  removePlayerFromTeam(teamId: string, userId: string): Observable<void> {
    return this.httpClient.delete<void>(
      `${this.baseURL}/${teamId}/players/${userId}`,
    );
  }

    addCoachToTeam(
    teamId: string,
    userId: string,
  ): Observable<void> {
    return this.httpClient.post<void>(
      `${this.baseURL}/${teamId}/coaches`,
      { userId },
    );
  }
    removeCoachFromTeam(
    teamId: string,
    userId: string,
  ): Observable<void> {
    return this.httpClient.delete<void>(
      `${this.baseURL}/${teamId}/coaches/${userId}`,
    );
  }
}
