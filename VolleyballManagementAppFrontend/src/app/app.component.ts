import { Component, inject } from '@angular/core';

import { AuthService } from '@auth0/auth0-angular';
import { JwtDecoderService } from './services/jwt-decoder.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'volleyball-management-app';
  
  // roles = [];
  // private jwtDecoderService = inject(JwtDecoderService);
  // access_token: string = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IjUta2RYR21ueEFSWmRxcUdYQmFDQSJ9.eyJpc3MiOiJodHRwczovL211ZXJhcHAuZXUuYXV0aDAuY29tLyIsInN1YiI6ImF1dGgwfDY1ZjE2ZmNjODk5MmI5YTgxM2Y1ZjJjNSIsImF1ZCI6WyJodHRwczovL211ZXJhcHAuZXUuYXV0aDAuY29tL2FwaS92Mi8iLCJodHRwczovL211ZXJhcHAuZXUuYXV0aDAuY29tL3VzZXJpbmZvIl0sImlhdCI6MTcxNTE2MzY5NCwiZXhwIjoxNzE1MjUwMDk0LCJzY29wZSI6Im9wZW5pZCBwcm9maWxlIGVtYWlsIiwiYXpwIjoiSm1SV3F0cFFBeGhNQjZuTXdIWHg2bmpNSDRJajhITGcifQ.D55BDLphE4Tgf8iIVNxzVqRNkn_2E6898Gy1PTa8BJh1gpRa0kxidE4LsW0jv0DcpV366fHt3twBBCmqMQSIfUFeIjACOrCkOxG22coRYCBRvJgEL63pxgmrJJXizTj9qRWmAeuDpPRVLU19O6MGrOLylJhLcig_LdQ9-mh-Y-sx4bL76zSmvmMnX-N28sIhdvzJhcvLvqxjcOVgC63Il0RRBKa2VYwbAPj8AB4cCzu5D269hoKgEyo_a2jeooapps-fWZwdwhu7H4Pq0ATsQW8bLS5ZozqabBMZ9izs7I5moZR73i4jmu6g36ZOukVWW0Kxk-msfrnAjIDuZcxx0Q"
  // id_token: string = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IjUta2RYR21ueEFSWmRxcUdYQmFDQSJ9.eyJyb2xlIjpbImFkbWluIiwiYmFzaWMgdXNlciIsImNvYWNoIl0sIm5pY2tuYW1lIjoiYmV0dGkuZmFya2FzMiIsIm5hbWUiOiJiZXR0aS5mYXJrYXMyQGdtYWlsLmNvbSIsInBpY3R1cmUiOiJodHRwczovL3MuZ3JhdmF0YXIuY29tL2F2YXRhci82YmVjNjM1ODkxYWQyZTg4ZThmZTY2MzZmOTY0NzNmNT9zPTQ4MCZyPXBnJmQ9aHR0cHMlM0ElMkYlMkZjZG4uYXV0aDAuY29tJTJGYXZhdGFycyUyRmJlLnBuZyIsInVwZGF0ZWRfYXQiOiIyMDI0LTA1LTA4VDA4OjUyOjA3LjQwOFoiLCJlbWFpbCI6ImJldHRpLmZhcmthczJAZ21haWwuY29tIiwiZW1haWxfdmVyaWZpZWQiOnRydWUsImlzcyI6Imh0dHBzOi8vbXVlcmFwcC5ldS5hdXRoMC5jb20vIiwiYXVkIjoiSm1SV3F0cFFBeGhNQjZuTXdIWHg2bmpNSDRJajhITGciLCJpYXQiOjE3MTUxNjM2OTQsImV4cCI6MTcxNTE5OTY5NCwic3ViIjoiYXV0aDB8NjVmMTZmY2M4OTkyYjlhODEzZjVmMmM1Iiwic2lkIjoiSXhvOGtiR01xblEzaUNlaFc1dmpBTXJQZWExYVhUWjIiLCJub25jZSI6IllsUndSRGxqVEZGM1VtMVVORkZMVWpGTmZsTnRTWEJmWjNGT1VWUm1SV2xLYUVoWGJVYzFNRWxHTlE9PSJ9.SeoaC8je8_GMboQVwZ0UW019pBRLupCx5N4QMV9giS5IOqtn8I3jEYCFmhKGFQjgAaChh3OuWyBBk-YOF9bgtvYLKYWal0Az-1giDVOTVBeiMEmYGc1qM2zudsj8_h20mZ7XhM2ILNBbAPOpRIuqI9mf25VZaTdlZvzEHn2JhF2oJf6fzIG8339-8Whf43nR9u3LN12B6t_S3gBzIARvGdmJ-SWbJC8KfR0lgGJ9lqqRmPcThtzgb-VpEYH4pLEbLLKBFnttKtqSLIEC31iOxFlUWdHWK0mWw2Pb9THOQeVFIuzJZeHlP3KPt6E0LkvKWb4JCiejHzSfzgptCjG6dQ"
  // decodedToken: any;

  // token: any;

  constructor(public auth: AuthService){
    // this.decodedToken = this.jwtDecoderService.decodeToken(this.id_token)
    // console.log(this.decodedToken);
    // this.roles = this.decodedToken.role;
    // console.log(this.decodedToken);
    // console.log("roles");
    // console.log(this.roles);
  }


  



}
