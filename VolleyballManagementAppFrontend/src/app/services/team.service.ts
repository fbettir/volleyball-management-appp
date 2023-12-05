import { Injectable } from '@angular/core';
import { Team } from '../models/team';
import { Training } from '../models/training';
import { Gender } from '../models/gender';
import { Post } from '../models/post';
import { Role } from '../models/role';
import { User } from '../models/user';
import { TicketPass } from '../models/ticket-pass';
import { Tournament } from '../models/tournament';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TeamPlayer } from '../models/team-player';

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

  getTeamPlayersByTeamId(teamId: string): Observable<TeamPlayer> {
    return this.httpClient.get<TeamPlayer>(`${this.baseURL}/${teamId}/players`);
  }


  constructor(private httpClient: HttpClient) { }


  
}
