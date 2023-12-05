import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Tournament } from '../models/tournament';
import { BasePortalOutlet } from '@angular/cdk/portal';

@Injectable({
  providedIn: 'root'
})
export class TournamentService {
  private baseURL: string = 'https://localhost:44359/tournaments';
  constructor(private httpClient: HttpClient) { }

  getTournamentById(tournamentId: string): Observable<Tournament> {
    // return this.Tournaments.find(Tournament => Tournament.id === TournamentId)!;
    return this.httpClient.get<Tournament>(`${this.baseURL}/${tournamentId}`);
  }

  getAllTournaments(): Observable<Tournament[]> {
    // return this.Tournaments.find(Tournament => Tournament.id === TournamentId)!;
    return this.httpClient.get<Tournament[]>(this.baseURL);
  }

  registerTeamToTournament(tournamentId: string, teamId: string) : Observable<void>{
    return this.httpClient.post<void>(`${this.baseURL}/${tournamentId}/teams`,{teamId});
  }
}
