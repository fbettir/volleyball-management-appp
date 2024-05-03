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
  private baseURL: string = 'api/teams';

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

  insertTeam(team: Team): void {
    this.httpClient.post(this.baseURL, team).subscribe(t => {
      console.log(t);
    });
  }

  getTeamTrainingsByTeamId(trainingId: string) {
    return this.httpClient.get<Training[]>(`${this.baseURL}/${trainingId}/trainings`);
  }

  deleteTeamById(teamId: string): void {
    this.httpClient.delete(`${this.baseURL}/${teamId}`);
  }

  modifyTeamById(team: Team): void{
    this.httpClient.put(`${this.baseURL}/${team.id}`, team);
  }
}
