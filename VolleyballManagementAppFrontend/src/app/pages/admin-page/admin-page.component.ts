import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { TabChipComponent } from 'src/app/components/shared/tab-chip/tab-chip.component';
import { EventsManagementComponent } from 'src/app/components/apage/events-management/events-management.component';
import { TeamsManagementComponent } from 'src/app/components/apage/teams-management/teams-management.component';
import { UsersManagementComponent } from 'src/app/components/apage/users-management/users-management.component';
import { TrainingsManagementComponent } from 'src/app/components/apage/trainings-management/trainings-management.component';

@Component({
  standalone: true,
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.scss'],
  imports: [
    CommonModule,
    TabChipComponent,
    EventsManagementComponent,
    TeamsManagementComponent,
    UsersManagementComponent,
    TrainingsManagementComponent,
],
})
export class AdminPageComponent {
  selectedTab: string = 'tournaments';
}
