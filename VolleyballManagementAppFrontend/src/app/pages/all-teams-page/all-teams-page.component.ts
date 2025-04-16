import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { TeamCardComponent } from 'src/app/components/team-card/team-card.component';
import { Team } from 'src/app/models/team';
import { TeamService } from 'src/app/services/team.service';
import { TeamSearchBarComponent } from 'src/app/shared/team-search-bar/team-search-bar.component';

@Component({
  selector: 'app-all-teams-page',
  standalone: true,
  templateUrl: './all-teams-page.component.html',
  styleUrls: ['./all-teams-page.component.scss'],
  imports: [TeamCardComponent, TeamSearchBarComponent, CommonModule]
})
export class AllTeamsPageComponent {

  teams: Team[] = [];

  constructor(teamService: TeamService){
    teamService.getAllTeams().subscribe( t => {
      console.log('Loaded teams:', t);
      this.teams = t;
    });
  }
}

