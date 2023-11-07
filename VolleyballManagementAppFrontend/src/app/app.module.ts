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
import { HttpClientModule } from '@angular/common/http';
import { EnumToDescriptionPipe } from './shared/enum-to-description.pipe';
import { UpdateDialogComponent } from './components/update-dialog/update-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { TrainingsDialogComponent } from './components/trainings-dialog/trainings-dialog.component';


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
    EnumToDescriptionPipe,
    UpdateDialogComponent,
    TrainingsDialogComponent,
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
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
