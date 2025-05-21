import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';

import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';
import { TabChipComponent } from 'src/app/components/shared/tab-chip/tab-chip.component';
import { TeamCardComponent } from 'src/app/components/cards/team-card/team-card.component';
import { EventCardComponent } from 'src/app/components/cards/event-card/event-card.component';
import { TrainingCardComponent } from 'src/app/components/cards/training-card/training-card.component';
import { Team } from 'src/app/models/team';

@Component({
  selector: 'app-profile-page',
  standalone: true,
  imports: [
    CommonModule,
    MatIconModule,
    TabChipComponent,
    TeamCardComponent,
    EventCardComponent,
    TrainingCardComponent,
  ],
  templateUrl: './profile-page.component.html',
  styleUrls: ['./profile-page.component.scss'],
})
export class ProfilePageComponent {
  private route = inject(ActivatedRoute);
  user: User | null = null;
  selectedTab: string | null = null;
  joinedTeams: Team[] = [];
  coachedTeams: Team[] = [];

  constructor(private userService: UserService) {
    const userId = this.route.snapshot.params['userId'];
    this.userService.getUserById(userId).subscribe((u) => {
      this.user = u;
      this.joinedTeams = u.joinedTeams || [];
      this.coachedTeams = u.coachedTeams || [];
    });
  }
}
