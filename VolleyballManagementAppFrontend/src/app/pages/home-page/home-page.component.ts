import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { EventCardComponent } from 'src/app/components/event-card/event-card.component';
import { TeamCardComponent } from 'src/app/components/team-card/team-card.component';
import { Team } from 'src/app/models/team';
import { Tournament } from 'src/app/models/tournament';
import { TeamService } from 'src/app/services/team.service';
import { TournamentService } from 'src/app/services/tournament.service';
import { TeamSearchBarComponent } from 'src/app/components/team-search-bar/team-search-bar.component';
import { HomeSearchBarComponent } from 'src/app/components/home-search-bar/home-search-bar.component';
import { TrainingService } from 'src/app/services/training.service';
import { Training } from 'src/app/models/training';
import { TrainingCardComponent } from 'src/app/components/training-card/training-card.component';

@Component({
  selector: 'app-home-page',
  standalone: true,
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss'],
  imports: [TeamCardComponent, CommonModule, HomeSearchBarComponent, TrainingCardComponent, EventCardComponent]
})
export class HomePageComponent {
  teams: Team[] = [];
  filteredTeams: Team[] = [];
  events: Tournament[] = [];
  filteredEvents: Tournament[] = [];
  trainings: Training[] = [];
  filteredTrainings: Training[] = [];

  constructor(tournamentService: TournamentService, teamService: TeamService, trainingService: TrainingService) {
    tournamentService.getAllTournaments().subscribe(t => {
      this.events = t;
      this.filteredEvents = t;
    });
    teamService.getAllTeams().subscribe( t => {
      this.teams = t;
      this.filteredTeams = t;
    });
    trainingService.getAllTrainings().subscribe(t => {
      this.trainings = t;
      this.filteredTrainings = t;
    })
  }

  onSearchChanged(search: { text: string; filter: string }) {
    const { text, filter } = search;

    // Clear all filtered lists first
    this.filteredTeams = [];
    this.filteredEvents = [];
    this.filteredTrainings = [];

    if (!text) {
      // Show all if search is empty
      this.filteredTeams = this.teams;
      this.filteredEvents = this.events;
      this.filteredTrainings = this.trainings;
      return;
    }

    switch (filter) {
      case 'name': // Team
        this.filteredTeams = this.teams.filter(team =>
          team.name.toLowerCase().includes(text)
        );
        break;

      case 'event':
        this.filteredEvents = this.events.filter(event =>
          event.name.toLowerCase().includes(text)
        );
        break;

      case 'training':
        this.filteredTrainings = this.trainings.filter(training =>
          training.team.name.toLowerCase().includes(text)
        );
        break;
    }
  }

}
