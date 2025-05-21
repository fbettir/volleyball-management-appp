import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { ProfilePageComponent } from './pages/profile-page/profile-page.component';
import { TeamPageComponent } from './pages/team-page/team-page.component';
import { AdminPageComponent } from './pages/admin-page/admin-page.component';
import { RoleGuard } from './role.guard';
import { TeamsPageComponent } from './pages/teams-page/teams-page.component';
import { AboutUsPageComponent } from './pages/about-us-page/about-us-page.component';
import { EventPageComponent } from './pages/event-page/event-page.component';
import { EventsPageComponent } from './pages/events-page/events-page.component';
import { GalleryPageComponent } from './pages/gallery-page/gallery-page.component';
import { PrivacyPolicyPageComponent } from './pages/privacy-policy-page/privacy-policy-page.component';
import { TrainingsPageComponent } from './pages/trainings-page/trainings-page.component';
import { TrainingPageComponent } from './pages/training-page/training-page.component';
import { TermsOfUsePageComponent } from './pages/terms-of-use-page/terms-of-use-page.component';

const routes: Routes = [
  { 
    path: 'about-us', 
    component: AboutUsPageComponent,
    canActivate: [RoleGuard],
    data: { expectedRoles: ['basic_user']}
  },
  { 
    path: 'admin', 
    component: AdminPageComponent,
    canActivate: [RoleGuard],
    data: { expectedRoles: ['admin']}
  },
  { 
    path: 'event/:eventId', 
    component: EventPageComponent,
    canActivate: [RoleGuard],
    data: { expectedRoles: ['basic_user']}
  },
  { 
    path: 'events', 
    component: EventsPageComponent,
    canActivate: [RoleGuard],
    data: { expectedRoles: ['basic_user']}
  },
  { 
    path: 'gallery', 
    component: GalleryPageComponent,
    canActivate: [RoleGuard],
    data: { expectedRoles: ['basic_user']}
  },
  { 
    path: 'home', 
    component: HomePageComponent,
    canActivate: [RoleGuard],
    data: { expectedRoles: ['basic_user']}
  },
  { 
    path: 'privacy-policy', 
    component: PrivacyPolicyPageComponent,
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
    component: TeamPageComponent ,
    canActivate: [RoleGuard],
    data: { expectedRoles: ['basic_user']}
  },
  {
    path: 'teams', 
    component: TeamsPageComponent,
    canActivate: [RoleGuard],
    data: { expectedRoles: ['basic_user']}
  },
  { 
    path: 'training/:trainingId', 
    component: TrainingPageComponent ,
    canActivate: [RoleGuard],
    data: { expectedRoles: ['basic_user']}
  },
  {
    path: 'trainings', 
    component: TrainingsPageComponent,
    canActivate: [RoleGuard],
    data: { expectedRoles: ['basic_user']}
  },
    {
    path: 'terms-of-use', 
    component: TermsOfUsePageComponent,
    canActivate: [RoleGuard],
    data: { expectedRoles: ['basic_user']}
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