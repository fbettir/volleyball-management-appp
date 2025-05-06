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
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatNativeDateModule } from '@angular/material/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TableComponent } from './components/table/table.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatMenuModule } from '@angular/material/menu';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { FooterComponent } from './components/footer/footer.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
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
import { AuthModule } from '@auth0/auth0-angular';
import { LogoutComponent } from './auth/logout/logout.component';
import { LoginComponent } from './auth/login/login.component';
import { UserProfileComponent } from './auth/user-profile/user-profile.component';
import { AuthHttpInterceptor } from '@auth0/auth0-angular';
import { AboutUsPageComponent } from './pages/about-us-page/about-us-page.component';
import { EventPageComponent } from './pages/event-page/event-page.component';
import { GalleryPageComponent } from './pages/gallery-page/gallery-page.component';
import { ProfilePageComponent } from './pages/profile-page/profile-page.component';
@NgModule({
  declarations: [
    AppComponent,
    ToolbarComponent,
    TableComponent,
    FooterComponent,
    AboutUsPageComponent,
    AdminPageComponent,
    GalleryPageComponent,
    ProfilePageComponent,
    EnumIntToDescriptionPipe,
    UpdateDialogComponent,
    TrainingsDialogComponent,
    AddTeamComponent,
    AddTournamentComponent,
    AddPlayerDetailsComponent,
    AddUserComponent,
    MultipleListEnumToDescriptionPipe,
    LogoutComponent,
    LoginComponent,
    UserProfileComponent
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
    AuthModule.forRoot({
      domain: 'muerapp.eu.auth0.com',
      clientId: 'JmRWqtpQAxhMB6nMwHXx6njMH4Ij8HLg',
      authorizationParams: {
        audience: 'https://muerapp.eu.auth0.com/api/v2/',
        scope: 'openid profile email read:messages', 
        redirect_uri: 'https://localhost:44359/app/home'
      },
      httpInterceptor: {
        allowedList: [
          '/api',
          'api/*'
        ],
      },
    }),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthHttpInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}