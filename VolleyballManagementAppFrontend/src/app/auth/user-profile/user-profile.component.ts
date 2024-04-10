import { Component, OnInit } from '@angular/core';
import { AuthHttpInterceptor, AuthService } from '@auth0/auth0-angular';
import { HttpClient } from '@angular/common/http';
import { AuthenticationService } from 'src/app/services/authentication.service';



@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss'],
  providers: [AuthHttpInterceptor]
})
export class UserProfileComponent implements OnInit{
  metadata = {};
  
  token: string;

  authenticated: boolean;
  user: any;
  constructor(public auth: AuthService, private http: HttpClient, private authService: AuthenticationService) {
    this.authenticated = this.authService.isAuthenticated();
    if (this.authenticated) {
      this.user = this.authService.getDecodedToken();
    }
    console.log(this.authenticated);

    this.authService.getTokenFromCookie().subscribe(
      (response) => {
        this.token = response.token; // Felteve, hogy a válasz objektum tartalmazza a token tulajdonságot
      },
      (error) => {
        console.error('Hiba történt a token lekérésekor:', error);
      }
    );
  }

  ngOnInit(): void {

    console.log("halo" + this.metadata);

  }

  getRoles(): void{

  }

}
