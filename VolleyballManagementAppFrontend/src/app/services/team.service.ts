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

@Injectable({
  providedIn: 'root'
})
export class TeamService {
  //TODO: baseurl
  getTeamById(teamId: string): Observable<Team> {
    return this.httpClient.get<Team>(`https://localhost:44359/team/${teamId}`);
  }

  getAllTeams(): Observable<Team[]> {
    return this.httpClient.get<Team[]>(`https://localhost:44359/team/all`);
  }


  constructor(private httpClient: HttpClient) { }


  
}
