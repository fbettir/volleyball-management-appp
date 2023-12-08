import { Injectable } from '@angular/core';
import { PlayerDetails } from '../models/player-details';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PlayerDetailService {
  private baseURL: string = 'https://localhost:44359/players';

  constructor(private httpClient: HttpClient) { }

  getPlayerById(playerId: string): Observable<PlayerDetails> {
    return this.httpClient.get<PlayerDetails>(`${this.baseURL}/${playerId}`);
  }

  getAllPlayers(): Observable<PlayerDetails[]> {
    return this.httpClient.get<PlayerDetails[]>(this.baseURL);
  }

  insertPlayer(player: PlayerDetails): void {
    this.httpClient.post(this.baseURL, player);
  }

  deletePlayerById(playerId: string): void {
    this.httpClient.delete(`${this.baseURL}/${playerId}`)
  }

  modifyPlayerById(player: PlayerDetails): void{
    this.httpClient.put(`${this.baseURL}/${player.id}`, player);
  }
}
