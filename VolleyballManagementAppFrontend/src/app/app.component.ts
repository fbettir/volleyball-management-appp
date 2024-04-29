import { Component } from '@angular/core';
import { ToolbarComponent } from './components/toolbar/toolbar.component';
import { FooterComponent } from './components/footer/footer.component';
import { AppRoutingModule } from './app-routing.module';
import { AuthService } from '@auth0/auth0-angular';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'volleyball-management-app';

  constructor(public auth: AuthService) {}

  ngOnInit() {
    this.getToken();
  }
  
  getToken() {
    this.auth.getAccessTokenSilently().subscribe((token) => {
      console.log("access token:");
      console.log(token);
      console.log("TokenClaims");
     });
  }
}
