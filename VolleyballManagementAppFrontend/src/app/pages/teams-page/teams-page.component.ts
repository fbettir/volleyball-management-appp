import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { TeamCardComponent } from 'src/app/components/cards/team-card/team-card.component';
import { Team } from 'src/app/models/entities/team';
import { TeamService } from 'src/app/services/team.service';
import { TeamSearchBarComponent } from 'src/app/components/search/team-search-bar/team-search-bar.component';
import { MatDialog } from '@angular/material/dialog';
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

  constructor(teamService: TeamService, private dialog: MatDialog) {
    teamService.getAllTeams().subscribe((t) => {
      console.log('Loaded teams:', t);
      this.teams = t;
      this.filteredTeams = t; 
    });
  }

 
  onSearchChanged(search: { text: string; filter: string }) {
    const { text, filter } = search;
  
    this.filteredTeams = this.teams.filter(team => {
      if (!text) return true;
  
      if (filter === 'name') {
        return team.name.toLowerCase().includes(text);
      }
  
      if (filter === 'coach') {
        return team.coaches.some(coach =>
          (coach.name )
            .toLowerCase()
            .includes(text)
        );
      }
  
      return false;
    });
  }
}
