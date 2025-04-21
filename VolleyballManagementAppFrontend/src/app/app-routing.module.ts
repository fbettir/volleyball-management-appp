import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { ProfilePageComponent } from './pages/profile-page/profile-page.component';
import { TeamPageComponent } from './pages/team-page/team-page.component';
import { AdminPageComponent } from './pages/admin-page/admin-page.component';
import { RoleGuard } from './role.guard';
import { TeamsPageComponent } from './pages/teams-page/teams-page.component';

const routes: Routes = [
  { 
    path: 'home', 
    component: HomePageComponent,
    canActivate: [RoleGuard],
    data: { expectedRoles: ['basic_user']}
  },

  { 
    path: 'profile', 
    component: ProfilePageComponent,
    canActivate: [RoleGuard],
    data: { expectedRoles: ['basic_user']}
  },
  { 
    path: 'team/:teamId', 
    component: TeamsPageComponent ,
    canActivate: [RoleGuard],
    data: { expectedRoles: ['basic_user']}
  },
  { 
    path: 'teams', 
    component: TeamPageComponent,
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