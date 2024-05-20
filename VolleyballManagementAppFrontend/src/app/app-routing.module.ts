import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { AllTournamentsPageComponent } from './pages/all-tournaments-page/all-tournaments-page.component';
import { MemberPageComponent } from './pages/profile-page/member-page.component';
import { TeamPageComponent } from './pages/team-page/team-page.component';
import { TournamentPageComponent } from './pages/tournament-page/tournament-page.component';
import { ContactUsPageComponent } from './pages/contact-us-page/contact-us-page.component';
import { AllTeamsPageComponent } from './pages/all-teams-page/all-teams-page.component';
import { AdminPageComponent } from './pages/admin-page/admin-page.component';
import { RoleGuard } from './role.guard';

const routes: Routes = [
  { 
    path: 'home', 
    component: HomePageComponent,
    canActivate: [RoleGuard],
    data: { expectedRoles: ['basic_user']}
  },
  { 
    path: 'tournaments', 
    component: AllTournamentsPageComponent,
    canActivate: [RoleGuard],
    data: { expectedRoles: ['basic_user']}
  },
  { 
    path: 'profile', 
    component: MemberPageComponent,
    canActivate: [RoleGuard],
    data: { expectedRoles: ['basic_user']}
  },
  { 
    path: 'team/:teamId', 
    component: TeamPageComponent ,
    canActivate: [RoleGuard],
    data: { expectedRoles: ['basic_user']}
  },
  { 
    path: 'teams', 
    component: AllTeamsPageComponent,
    canActivate: [RoleGuard],
    data: { expectedRoles: ['basic_user']} 
  },
  { 
    path: 'tournament/:tournamentId', 
    component: TournamentPageComponent,
    canActivate: [RoleGuard],
    data: { expectedRoles: ['basic_user']} 
  },
  { 
    path: 'contact-us', 
    component: ContactUsPageComponent,
    canActivate: [RoleGuard],
    data: { expectedRoles: ['basic_user']}
  },
  { 
    path: 'admin', 
    component: AdminPageComponent ,
    canActivate: [RoleGuard],
    data: { expectedRoles: ['admin']}
  },
  { 
    path: '**', 
    redirectTo: 'home' 
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}