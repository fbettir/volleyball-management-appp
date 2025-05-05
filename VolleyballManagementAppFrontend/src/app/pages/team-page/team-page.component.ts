import { Component, inject, OnInit } from '@angular/core';
import { Team } from 'src/app/models/team';
import { ActivatedRoute } from '@angular/router';
import { TeamService } from 'src/app/services/team.service';
import { User } from 'src/app/models/user';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { UserCardComponent } from 'src/app/components/user-card/user-card.component';
import { TrainingCardComponent } from 'src/app/components/training-card/training-card.component';
import { Training } from 'src/app/models/training';
import { Tournament } from 'src/app/models/tournament';
import { EventCardComponent } from 'src/app/components/event-card/event-card.component';
import { Match } from 'src/app/models/match';
import { MatchCardComponent } from 'src/app/components/match-card/match-card.component';

@Component({
  selector: 'app-team-page',
  standalone: true,
  imports: [CommonModule, MatIconModule, UserCardComponent, MatchCardComponent, EventCardComponent, TrainingCardComponent],
  templateUrl: './team-page.component.html',
})
export class TeamPageComponent implements OnInit {
  private route = inject(ActivatedRoute);
  private teamService = inject(TeamService);

  team: Team | null = null;

  get players(): User[] {
    return this.team?.players || [];
  }

  get trainings(): Training[] {
    return this.team?.trainings || [];
  }

  get coaches(): User[] {
    return this.team?.coaches || [];
  }

  get tournaments(): Tournament[] {
    return this.team?.tournaments || [];
  }

  get matches(): Match[] {
    return this.team?.matches || [];
  }

  ngOnInit(): void {
    const teamId = this.route.snapshot.params['teamId'];
    if (teamId) {
      this.teamService.getTeamById(teamId).subscribe({
        next: (team) => (this.team = team),
        error: (err) => console.error('Failed to load team', err),
      });
    }
  }

}
