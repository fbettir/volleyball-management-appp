import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseURL: string = 'https://localhost:44359/users';

  constructor(private httpClient: HttpClient) { }

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
