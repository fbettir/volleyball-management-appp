import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { EventCardComponent } from 'src/app/components/event-card/event-card.component';
import { TeamCardComponent } from 'src/app/components/team-card/team-card.component';
import { Team } from 'src/app/models/team';
import { Tournament } from 'src/app/models/tournament';
import { TeamService } from 'src/app/services/team.service';
import { TournamentService } from 'src/app/services/tournament.service';
import { TeamSearchBarComponent } from 'src/app/shared/team-search-bar/team-search-bar.component';

@Component({
  selector: 'app-home-page',
  standalone: true,
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss'],
  imports: [TeamCardComponent, EventCardComponent, CommonModule, TeamSearchBarComponent]
})
export class HomePageComponent {
  teams: Team[] = [];

  tournaments: Tournament[] = [];
  constructor(tournamentService: TournamentService, teamService: TeamService) {
    tournamentService.getAllTournaments().subscribe(t => {
      this.tournaments = t;
    });
    teamService.getAllTeams().subscribe( t => {
      this.teams = t;
    });
  }


}
