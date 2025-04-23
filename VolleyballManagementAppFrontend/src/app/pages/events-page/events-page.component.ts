import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { EventCardComponent } from 'src/app/components/event-card/event-card.component';
import { TeamSearchBarComponent } from 'src/app/components/team-search-bar/team-search-bar.component';
import { Tournament } from 'src/app/models/tournament';
import { TournamentService } from 'src/app/services/tournament.service';

@Component({
  selector: 'app-events-page',
  standalone: true,
  imports: [EventCardComponent, TeamSearchBarComponent, CommonModule],
  templateUrl: './events-page.component.html',
  styleUrls: ['./events-page.component.scss'],
})
export class EventsPageComponent {
  tournaments: Tournament[] = [];

  constructor(tournamentService: TournamentService) {
    tournamentService.getAllTournaments().subscribe((t) => {
      this.tournaments = t;
    });
  }
}
