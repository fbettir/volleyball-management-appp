import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { TeamCardComponent } from 'src/app/components/team-card/team-card.component';
import { Team } from 'src/app/models/team';
import { TeamService } from 'src/app/services/team.service';
import { TeamSearchBarComponent } from 'src/app/components/team-search-bar/team-search-bar.component';

@Component({
  selector: 'app-teams-page',
  standalone: true,
  imports: [TeamSearchBarComponent, TeamCardComponent, CommonModule],
  templateUrl: './teams-page.component.html',
  styleUrl: './teams-page.component.scss',
})
export class TeamsPageComponent {
  teams: Team[] = [];
  filteredTeams: Team[] = [];

  constructor(teamService: TeamService) {
    teamService.getAllTeams().subscribe((t) => {
      console.log('Loaded teams:', t);
      this.teams = t;
    });
  }

  onSearchChanged(searchText: string) {
    this.filteredTeams = this.teams.filter(team =>
      team.name.toLowerCase().includes(searchText)
    );
  }
}
