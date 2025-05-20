import { Injectable } from '@angular/core';
import { Team } from '../models/team';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PlayerDetails } from '../models/player-details';
import { Training } from '../models/training';

@Injectable({
  providedIn: 'root'
})
export class TeamService {
  private baseURL: string = 'https://localhost:44359/api/Team'; 

  constructor(private httpClient: HttpClient) { }

  getTeamById(teamId: string): Observable<Team> {
    return this.httpClient.get<Team>(`${this.baseURL}/${teamId}`);
  }

  getAllTeams(): Observable<Team[]> { 
    return this.httpClient.get<Team[]>(this.baseURL);
  }

  getTeamPlayersByTeamId(teamId: string) {
    return this.httpClient.get<PlayerDetails[]>(`${this.baseURL}/${teamId}/players`);
  }

  insertTeam(team: Team): Observable<void> {
    return this.httpClient.post<void>(this.baseURL, team);
  }

  getTeamTrainingsByTeamId(trainingId: string) {
    return this.httpClient.get<Training[]>(`${this.baseURL}/${trainingId}/trainings`);
  }

  deleteTeamById(teamId: string): Observable<void> {
    return this.httpClient.delete<void>(`${this.baseURL}/${teamId}`);
  }

  modifyTeamById(team: Team): Observable<void> {
    return this.httpClient.put<void>(`${this.baseURL}/${team.id}`, team);
  }
}
