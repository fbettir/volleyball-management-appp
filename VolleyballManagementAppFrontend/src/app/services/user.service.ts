import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { AuthService } from '@auth0/auth0-angular';
import { concatMap, tap, map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseURL: string = 'https://localhost:44359/users';

  constructor(public auth: AuthService, private httpClient: HttpClient) { }

  getUserCreds(): string {
    var metadata = {};

    this.auth.user$
    .pipe(
      concatMap((user) =>
        // Use HttpClient to make the call
        this.httpClient.get(
          encodeURI(`https://muerapp.eu.auth0.com/api/v2/users`)
        )
      ),
      map((user: any) => user.user_metadata),
      tap((meta) => (metadata = meta))
    )
    .subscribe();
    
      console.log(this.httpClient.get(
        encodeURI(`https://muerapp.eu.auth0.com/api/v2/users`)
      ));

      return metadata as string
  }

  getUserById(teamId: string): Observable<User> {
    return this.httpClient.get<User>(`${this.baseURL}/${teamId}`);
  }

  getAllUsers(): Observable<User[]> {
    return this.httpClient.get<User[]>(this.baseURL);
  }

  insertUser(user: User): void {
    this.httpClient.post(this.baseURL, user).subscribe(t => {
      console.log(t);
    });
  }

  deleteUserById(userId: string): void {
    this.httpClient.delete(`${this.baseURL}/${userId}`);
  }

  modifyUserById(user: User): void{
    this.httpClient.put(`${this.baseURL}/${user.id}`, user);
  }
}
