import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { ToolbarComponent } from './components/toolbar/toolbar.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatRadioModule } from '@angular/material/radio';
import { MatCardModule } from '@angular/material/card';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatNativeDateModule} from '@angular/material/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TableComponent } from './components/table/table.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatMenuModule } from '@angular/material/menu';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { TeamPageComponent } from './pages/team-page/team-page.component';
import { MemberPageComponent } from './pages/profile-page/member-page.component';
import { AllTournamentsPageComponent } from './pages/all-tournaments-page/all-tournaments-page.component';
import { TournamentPageComponent } from './pages/tournament-page/tournament-page.component';
import { ContactUsPageComponent } from './pages/contact-us-page/contact-us-page.component';
import { FooterComponent } from './components/footer/footer.component';
import { AllTeamsPageComponent } from './pages/all-teams-page/all-teams-page.component';
import { HTTP_INTERCEPTORS, HttpClientModule, provideHttpClient, withInterceptors } from '@angular/common/http';
import { EnumIntToDescriptionPipe } from './shared/enum-to-description.pipe';
import { UpdateDialogComponent } from './components/update-dialog/update-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { TrainingsDialogComponent } from './components/trainings-dialog/trainings-dialog.component';
import { AdminPageComponent } from './pages/admin-page/admin-page.component';
import { AddTeamComponent } from './components/add-team/add-team.component';
import { AddTournamentComponent } from './components/add-tournament/add-tournament.component';
import { AddPlayerDetailsComponent } from './components/add-player-details/add-player-details.component';
import { AddUserComponent } from './components/add-user/add-user.component';
import { MultipleListEnumToDescriptionPipe } from './shared/multiple-list-enum-to-description.pipe';
import { AuthModule, authHttpInterceptorFn } from '@auth0/auth0-angular';
import { LogoutComponent } from './auth/logout/logout.component';
import { LoginComponent } from './auth/login/login.component';
import { UserProfileComponent } from './auth/user-profile/user-profile.component';
import { JWT_OPTIONS, JwtModule } from '@auth0/angular-jwt';
import { provideAuth0 } from '@auth0/auth0-angular';
import { AuthHttpInterceptor } from '@auth0/auth0-angular';


export function jwtOptionsFactory() {
  return {
    allowedList: [
      {
        // Match any request that starts 'https://{yourDomain}/api/v2/' (note the asterisk)
        uri: 'https://muerapp.eu.auth0.com/api/v2/*',
        tokenOptions: {
          authorizationParams: {
            // The attached token should target this audience
            audience: 'https://muerapp.eu.auth0.com/api/v2/',

            // The attached token should have these scopes
            scope: 'read:current_user'
          }
        }
      }
    ]
  };
}

@NgModule({
  declarations: [
    AppComponent,
    ToolbarComponent,
    TableComponent,
    FooterComponent,
    HomePageComponent,
    TeamPageComponent,
    MemberPageComponent,
    AllTournamentsPageComponent,
    TournamentPageComponent,
    ContactUsPageComponent,
    AllTeamsPageComponent,
    EnumIntToDescriptionPipe,
    UpdateDialogComponent,
    TrainingsDialogComponent,
    AdminPageComponent,
    AddTeamComponent,
    AddTournamentComponent,
    AddPlayerDetailsComponent,
    AddUserComponent,
    MultipleListEnumToDescriptionPipe,
    LogoutComponent,
    LoginComponent,
    UserProfileComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSlideToggleModule,
    LayoutModule,
    FormsModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatInputModule,
    MatSelectModule,
    MatDialogModule, 
    MatRadioModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatNativeDateModule,
    MatCardModule,
    ReactiveFormsModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatGridListModule,
    MatMenuModule,
    DragDropModule,
    HttpClientModule,
    // AuthModule.forRoot({
    //   domain: 'muerapp.eu.auth0.com',
    //   clientId: 'JmRWqtpQAxhMB6nMwHXx6njMH4Ij8HLg',
    
    //   authorizationParams: {
    //     redirect_uri: window.location.origin,
        
    //     // Request this audience at user authentication time
    //     audience: 'https://muerapp.eu.auth0.com/api/v2/',
    
    //     // Request this scope at user authentication time
    //     scope: 'read:current_user',
    //   },
    // }),
    JwtModule.forRoot({
      jwtOptionsProvider: {
        provide: JWT_OPTIONS,
        useFactory: jwtOptionsFactory
      }
    }),
    // AuthModule.forRoot({
    //   domain: 'muerapp.eu.auth0.com',
    //   clientId: 'JmRWqtpQAxhMB6nMwHXx6njMH4Ij8HLg',
    //   authorizationParams: {
    //     redirect_uri: window.location.origin,
    //     audience: 'https://muerapp.eu.auth0.com/api/v2/',
    //     scope: 'read:current_user'
    //   },
    //   httpInterceptor: {
    //     allowedList: [
    //       {
    //         uri: 'https://muerapp.eu.auth0.com/api/v2/*',
    //         tokenOptions: {
    //           authorizationParams: {
    //             audience: 'https://muerapp.eu.auth0.com/api/v2/',
    //             scope: 'read:current_user'
    //           }
    //         }
    //       }
    //     ]
    //   }
    // })
  ],
  providers: [    
    // provideHttpClient(withInterceptors([authHttpInterceptorFn])),
    { provide: HTTP_INTERCEPTORS, useClass: AuthHttpInterceptor, multi: true }
],
  bootstrap: [AppComponent],
})
export class AppModule {}
