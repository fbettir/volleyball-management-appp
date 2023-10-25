import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { AllTournamentsPageComponent } from './pages/all-tournaments-page/all-tournaments-page.component';
import { MemberPageComponent } from './pages/profile-page/member-page.component';
import { TeamPageComponent } from './pages/team-page/team-page.component';
import { TournamentPageComponent } from './pages/tournament-page/tournament-page.component';
import { ContactUsPageComponent } from './pages/contact-us-page/contact-us-page.component';
import { AllTeamsPageComponent } from './pages/all-teams-page/all-teams-page.component';

const routes: Routes = [
  { path: 'home', component: HomePageComponent },
  { path: 'tournaments', component: AllTournamentsPageComponent },
  { path: 'profile', component: MemberPageComponent },
  { path: 'team/:teamId', component: TeamPageComponent },
  { path: 'teams', component: AllTeamsPageComponent },
  { path: 'tournament/:tournamentId', component: TournamentPageComponent },
  { path: 'contact-us', component: ContactUsPageComponent },
  { path: '**', redirectTo: 'home' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
