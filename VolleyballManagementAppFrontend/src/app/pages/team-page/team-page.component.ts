import { Component, inject } from '@angular/core';
import { Team } from 'src/app/models/team';
import { ActivatedRoute } from '@angular/router';
import { TeamService } from 'src/app/services/team.service';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { UserCardComponent } from 'src/app/components/cards/user-card/user-card.component';
import { TrainingCardComponent } from 'src/app/components/cards/training-card/training-card.component';
import { EventCardComponent } from 'src/app/components/cards/event-card/event-card.component';
import { Match } from 'src/app/models/match';
import { MatchCardComponent } from 'src/app/components/cards/match-card/match-card.component';

@Component({
  selector: 'app-team-page',
  standalone: true,
  imports: [CommonModule, MatIconModule, UserCardComponent, MatchCardComponent, EventCardComponent, TrainingCardComponent],
  templateUrl: './team-page.component.html',
})
export class TeamPageComponent {
  private route = inject(ActivatedRoute);

  team: Team | null = null;


  constructor(teamService: TeamService) {
    const teamId = this.route.snapshot.params['teamId'];

    teamService.getTeamById(teamId).subscribe((t) => {
      console.log('Loaded team:', t);
      this.team = t;
    });
  }

}
