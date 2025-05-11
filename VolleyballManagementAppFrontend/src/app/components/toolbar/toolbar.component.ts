import { Component, Inject } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { AuthService } from '@auth0/auth0-angular';
import { DOCUMENT } from '@angular/common';

import { map, shareReplay } from 'rxjs/operators';
import { JwtDecoderService } from 'src/app/services/jwt-decoder.service';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss'],

})
export class ToolbarComponent {


  isAdmin = false;

ngOnInit(): void {
  this.jwtDecoder.isAdmin().then(isAdmin => {
    this.isAdmin = isAdmin;
  });
}

  constructor(@Inject(DOCUMENT) public document: Document, public auth: AuthService, private jwtDecoder: JwtDecoderService) {

  }

  logout(): void {
    this.auth.logout({
      logoutParams: {
        returnTo: 'https://localhost:44359/app/home'
      }
    });
  }
}
