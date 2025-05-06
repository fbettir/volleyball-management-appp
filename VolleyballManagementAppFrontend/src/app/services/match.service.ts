import { Injectable } from '@angular/core';
import { Match } from '../models/match';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MatchService {
  private baseURL: string = 'https://localhost:44359/api/Match';

  constructor(private httpClient: HttpClient) { }

    getMatchById(matchId: string): Observable<Match> {
      return this.httpClient.get<Match>(`${this.baseURL}/${matchId}`);
    }
  
    getAllTeams(): Observable<Match[]> { 
      return this.httpClient.get<Match[]>(this.baseURL);
    }
}
 