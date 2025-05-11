import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class JwtDecoderService {
  
  token: string | null = null;

  constructor(public auth: AuthService) {}

  decodeToken(token: string){
    try{
      const parts = token.split('.');
      if (parts.length !== 3) {
        throw new Error('Invalid token format');
      }
    
      const base64URL = parts[1];
      const base64 = base64URL.replace(/-/g, '+').replace(/_/g, '/');
      const jsonPayload = decodeURIComponent(
        atob(base64)
          .split('')
          .map((c) => '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2))
          .join('')
      );
      return JSON.parse(jsonPayload);
  
    } catch (error) {
      console.error("Error decoding token:", error);
      return {};
    }
  }

  async getUserRoles(): Promise<string[]> {
    console.log("haloo");
    try {
      const tokenClaims = await firstValueFrom(this.auth.idTokenClaims$);
      this.token = tokenClaims?.__raw || null;
      // console.log(this.token);
      // console.log("Token claims:", tokenClaims);
      // console.log("Raw token:", this.token);
  
      if (this.token) {
        const decodedToken = this.decodeToken(this.token);
        // console.log("Decoded token:", decodedToken);
        
        const roles = decodedToken.role;
        console.log("Roles:", roles);

        return roles || [];
      }
    } catch (error) {
      console.error("Error getting token claims", error);
      return [];
    }
  
    return ['basic_user'];
  }
  
  async isAdmin(): Promise<boolean> {
    const roles = await this.getUserRoles();
    return roles.includes('admin');
  }
}
