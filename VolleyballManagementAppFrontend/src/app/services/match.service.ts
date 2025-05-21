import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Match } from '../models/match';
import { Team } from '../models/team';

@Injectable({
  providedIn: 'root'
})
export class MatchService {
  private baseURL: string = 'https://localhost:44359/api/Match';

  constructor(private httpClient: HttpClient) {}

  getMatchById(matchId: string): Observable<Match> {
    return this.httpClient.get<Match>(`${this.baseURL}/${matchId}`);
  }

  getAllMatches(): Observable<Match[]> {
    return this.httpClient.get<Match[]>(this.baseURL);
  }

  createMatch(match: Match): Observable<Match> {
    return this.httpClient.post<Match>(this.baseURL, match);
  }

  updateMatch(matchId: string, match: Match): Observable<void> {
    return this.httpClient.put<void>(`${this.baseURL}/${matchId}`, match);
  }

  deleteMatch(matchId: string): Observable<void> {
    return this.httpClient.delete<void>(`${this.baseURL}/${matchId}`);
  }

  getMatchTeams(matchId: string): Observable<Team[]> {
    return this.httpClient.get<Team[]>(`${this.baseURL}/${matchId}/teams`);
  }
}
