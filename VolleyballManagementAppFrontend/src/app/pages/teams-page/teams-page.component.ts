import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { TeamCardComponent } from 'src/app/components/team-card/team-card.component';
import { Team } from 'src/app/models/team';
import { TeamService } from 'src/app/services/team.service';
import { TeamSearchBarComponent } from 'src/app/shared/team-search-bar/team-search-bar.component';

@Component({
  selector: 'app-teams-page',
  templateUrl: './teams-page.component.html',
  styleUrls: ['./teams-page.component.scss'],
  // imports: [TeamCardComponent, TeamSearchBarComponent, CommonModule]
})
export class TeamsPageComponent {

  teams: Team[] = [];

  constructor(teamService: TeamService, teamCard: TeamCardComponent){
    teamService.getAllTeams().subscribe( t => {
      console.log('Loaded teams:', t);
      this.teams = t;
    });
  }
}

