import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Tournament } from '../models/entities/tournament';
import { map } from 'rxjs/operators';

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
    return this.httpClient
      .get<Tournament[]>(this.baseURL)
      .pipe(map((tournaments) => this.sortTournamentsByName(tournaments)));
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

  registerTournamentCompetitor(
    tournamentId: string,
    teamId: string,
  ): Observable<void> {
    return this.httpClient.post<void>(
      `${this.baseURL}/${tournamentId}/tournamentCompetitors`,
      { teamId }, // the backend expects this shape
    );
  }

  removeTeamFromTournament(
    tournamentId: string,
    teamId: string,
  ): Observable<void> {
    return this.httpClient.delete<void>(
      `${this.baseURL}/${tournamentId}/tournamentCompetitors/${teamId}`,
    );
  }

  private sortTournamentsByName(tournaments: Tournament[]): Tournament[] {
    return tournaments
      .slice()
      .sort((a, b) =>
        a.name.localeCompare(b.name, 'en', { sensitivity: 'base' }),
      );
  }

  updateTournamentTeams(
    tournamentId: string,
    teamDtos: { teamId: string }[],
  ): Observable<void> {
    return this.httpClient.put<void>(
      `${this.baseURL}/${tournamentId}/schedule`,
      teamDtos,
    );
  }
}
