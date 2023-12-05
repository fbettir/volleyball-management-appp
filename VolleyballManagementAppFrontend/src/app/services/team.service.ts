import { Injectable } from '@angular/core';
import { Team } from '../models/team';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PlayerDetails } from '../models/player-details';

@Injectable({
  providedIn: 'root'
})
export class TeamService {
  private baseURL: string = 'https://localhost:44359/teams';

  getTeamById(teamId: string): Observable<Team> {
    return this.httpClient.get<Team>(`${this.baseURL}/${teamId}`);
  }

  getAllTeams(): Observable<Team[]> {
    return this.httpClient.get<Team[]>(this.baseURL);
  }

  getTeamPlayersByTeamId(teamId: string) {
    return this.httpClient.get<PlayerDetails[]>(`${this.baseURL}/${teamId}/players`);
  }


  constructor(private httpClient: HttpClient) { }


  
}
