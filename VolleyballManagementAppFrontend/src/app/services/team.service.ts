import { Injectable } from '@angular/core';
import { Team } from '../models/team';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Training } from '../models/training';
import { map } from 'rxjs/operators';
import { User } from '../models/user';

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

  addPlayerToTeam(teamId: string, user: User): Observable<void> {
    return this.httpClient.post<void>(`${this.baseURL}/${teamId}/players`, {
      userId: user.id,
    });
  }

  removePlayerFromTeam(teamId: string, user: User): Observable<void> {
    return this.httpClient.request<void>(
      'delete',
      `${this.baseURL}/${teamId}/players`,
      {
        body: { userId: user.id },
      },
    );
  }

  addCoachToTeam(teamId: string, user: User): Observable<void> {
    return this.httpClient.post<void>(`${this.baseURL}/${teamId}/coaches`, {
      userId: user.id,
    });
  }

  removeCoachFromTeam(teamId: string, user: User): Observable<void> {
    return this.httpClient.request<void>(
      'delete',
      `${this.baseURL}/${teamId}/coaches`,
      {
        body: { userId: user.id },
      },
    );
  }
}
