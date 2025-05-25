import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { firstValueFrom } from 'rxjs';
import { User } from '../models/user';
import { PriceType } from '../models/priceType';
import { Gender } from '../models/gender';
import { Post } from '../models/post';
import { Role } from '../models/role';
import { UserService } from './user.service';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class JwtDecoderService {
  
  token: string | null = null;

    public currentUser$ = new BehaviorSubject<User | null>(null);


  constructor(public auth: AuthService, private userService: UserService, private httpClient: HttpClient) {}

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
    try {
      const tokenClaims = await firstValueFrom(this.auth.idTokenClaims$);
      this.token = tokenClaims?.__raw || null;
      console.log("user: ");
      console.log(this.auth);

  
      if (this.token) {
        const decodedToken = this.decodeToken(this.token);
        
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

async loadLoggedInUser(): Promise<void> {
  const tokenClaims = await firstValueFrom(this.auth.idTokenClaims$);

  if (!tokenClaims || !tokenClaims.__raw) {
    console.error('Token claims or raw token not available');
    return;
  }

  const rawToken = tokenClaims.__raw;
  const decoded = this.decodeToken(rawToken);
  const auth0Id = decoded.sub;

  if (!auth0Id) {
    console.error('Auth0 ID not found in token');
    return;
  }

  this.userService.getUserByAuth0Id(auth0Id).subscribe({
    next: (user) => {
      this.currentUser$.next(user);
      console.log('Logged in user:', user);
    },
    error: () => {
      // fallback ha nincs backend user még
      const dto = {
        auth0Id: decoded.sub,
        email: decoded.email,
        name: decoded.name || decoded.nickname || '',
        pictureLink: decoded.picture || '',
      };

      this.httpClient.post<User>(`/api/User/sync`, dto).subscribe({
        next: (user) => {
          this.currentUser$.next(user);
          console.log('User synced and logged in:', user);
        },
        error: (err) => {
          console.error('Failed to sync user to backend:', err);
        },
      });
    },
  });
}

  async getAuth0UserAsAppUser(): Promise<User> {
  try {
    const tokenClaims = await firstValueFrom(this.auth.idTokenClaims$);
    this.token = tokenClaims?.__raw || null;

    if (this.token) {
      const decoded = this.decodeToken(this.token);

      const user: User = {
        id: '', 
        auth0Id: decoded.sub,
        name: decoded.name || decoded.nickname || '',
        email: decoded.email || '',
        pictureLink: decoded.picture || '',
        birthday: new Date(), 
        phone: '',
        playerNumber: 0,
        roles: [Role.BasicUser],
        priceType: PriceType.Ticket,
        gender: Gender.Man, 
        posts: Post.Setter, 
        ownedTeams: [],
        joinedTeams: [],
        coachedTeams: [],
        favouriteTeams: [],
        trainings: [],
        favouriteTrainings: [],
        favouriteTournaments: [],
      };

      return user;
    }
  } catch (error) {
    console.error("Error creating app user from Auth0:", error);
  }

  return {
    id: '',
    auth0Id: '',
    name: '',
    email: '',
    pictureLink: '',
    birthday: new Date(),
    phone: '',
    playerNumber: 0,
    roles: [Role.BasicUser],
    priceType: PriceType.Ticket,
    gender: Gender.Man,
    posts: Post.Setter,
    ownedTeams: [],
    joinedTeams: [],
    coachedTeams: [],
    favouriteTeams: [],
    trainings: [],
    favouriteTrainings: [],
    favouriteTournaments: [],
  };
}
  
  async isAdmin(): Promise<boolean> {
    const roles = await this.getUserRoles();
    return roles.includes('admin');
  }
}
