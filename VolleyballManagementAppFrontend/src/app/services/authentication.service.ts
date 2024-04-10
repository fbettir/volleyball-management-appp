import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  constructor(public jwtHelper: JwtHelperService, private http: HttpClient) {}

  getTokenFromCookie(): Observable<any> {
    return this.http.get<any>('muerapp.eu.auth0.com/token', { withCredentials: true });
  }
  
  public getToken(): string {
    // console.log(sessionStorage);
    // console.log(localStorage);
    // console.log();
    return sessionStorage.getItem('access_token')!;
 
  }

  public isAuthenticated(): boolean {
    const token = this.getToken();
    // Ellenőrizd, hogy a token érvényes és nem lejárt
    return !this.jwtHelper.isTokenExpired(token);
  }

  public getDecodedToken() {
    const token = this.getToken();
    // Dekódold a tokent és add vissza az adatokat
    return this.jwtHelper.decodeToken(token);
  }
}