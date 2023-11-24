import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Tournament } from '../models/tournament';

@Injectable({
  providedIn: 'root'
})
export class TournamentService {

  constructor(private httpClient: HttpClient) { }

  getTournamentById(tournamentId: number): Observable<Tournament> {
    // return this.Tournaments.find(Tournament => Tournament.id === TournamentId)!;
    return this.httpClient.get<Tournament>(`https://localhost:44359/tournament/${tournamentId}`);
  }

  getAllTournaments(): Observable<Tournament[]> {
    // return this.Tournaments.find(Tournament => Tournament.id === TournamentId)!;
    return this.httpClient.get<Tournament[]>(`https://localhost:44359/tournament/all`);
  }
}
