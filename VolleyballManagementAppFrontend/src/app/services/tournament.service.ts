import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Tournament } from '../models/tournament';
import { BasePortalOutlet } from '@angular/cdk/portal';
import { Team } from '../models/team';

@Injectable({
  providedIn: 'root',
})
export class TournamentService {
  private baseURL: string = 'https://localhost:44359/api/Tournament';
  constructor(private httpClient: HttpClient) {}

  getTournamentById(tournamentId: string): Observable<Tournament> {
    return this.httpClient.get<Tournament>(`${this.baseURL}/${tournamentId}`);
  }

  getAllTournaments(): Observable<Tournament[]> {
    return this.httpClient.get<Tournament[]>(this.baseURL);
  }

  insertTournament(tournament: Tournament): Observable<Tournament> {
    return this.httpClient.post<Tournament>(this.baseURL, tournament);
  }

  deleteTournamentById(tournamentId: string): Observable<void> {
    return this.httpClient.delete<void>(`${this.baseURL}/${tournamentId}`);
  }

  modifyTournamentById(tournament: Tournament): Observable<void> {
    return this.httpClient.put<void>(
      `${this.baseURL}/${tournament.id}`,
      tournament,
    );
  }

registerTournamentCompetitor(tournamentId: string, teamId: string): Observable<void> {
  return this.httpClient.post<void>(
    `${this.baseURL}/${tournamentId}/tournamentCompetitors`,
    { teamId }  // the backend expects this shape
  );
}

  removeTeamFromTournament(tournamentId: string, team: Team): Observable<void> {
    return this.httpClient.request<void>(
      'delete',
      `${this.baseURL}/${tournamentId}/tournamentCompetitors`,
      {
        body: team,
      }
    );
  }

  // scheduleMatches(tournamentId: string): Observable<void> {
  //   return this.httpClient.put<void>(
  //     `${this.baseURL}/${tournamentId}/schedule`,
  //     {}
  //   );
  // }
}
