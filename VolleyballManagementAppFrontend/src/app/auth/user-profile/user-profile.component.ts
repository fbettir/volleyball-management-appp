import { Component, OnInit } from '@angular/core';
import { AuthHttpInterceptor, AuthService } from '@auth0/auth0-angular';
import { HttpClient } from '@angular/common/http';



@Component({
  selector: 'app-user-profile',
  template: `<ul *ngIf="auth.user$ | async as user">
  <li>{{ user.name }}</li>
  <li>{{ user.email }}</li>
</ul><div *ngIf="metadata"><pre>{{ metadata | json }}</pre></div>`,  
  styleUrls: ['./user-profile.component.scss'],
  providers: [AuthHttpInterceptor]
})
export class UserProfileComponent implements OnInit{
  metadata = {};

  constructor(public auth: AuthService, private http: HttpClient) {}

  ngOnInit(): void {

    console.log("halo" + this.metadata);

  }

  getRoles(): void{

  }

}
