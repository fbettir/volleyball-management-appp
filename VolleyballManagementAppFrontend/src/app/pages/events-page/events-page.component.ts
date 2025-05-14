import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { EventCardComponent } from 'src/app/components/cards/event-card/event-card.component';
import { EventSearchBarComponent } from 'src/app/components/search/event-search-bar/event-search-bar.component';
import { Tournament } from 'src/app/models/tournament';
import { TournamentService } from 'src/app/services/tournament.service';

@Component({
  selector: 'app-events-page',
  standalone: true,
  imports: [EventCardComponent, EventSearchBarComponent, CommonModule],
  templateUrl: './events-page.component.html',
  styleUrls: ['./events-page.component.scss'],
})
export class EventsPageComponent {
  tournaments: Tournament[] = [];
  filteredTounaments: Tournament[] = [];
  

  constructor(tournamentService: TournamentService) {
    tournamentService.getAllTournaments().subscribe((t) => {
      this.tournaments = t;
      this.filteredTounaments = t; 
    });
  }

  onSearchChanged(search: { text: string; filter: string }) {
    const { text, filter } = search;
  
    this.filteredTounaments = this.tournaments.filter(event => {
      if (!text) return true;
  
      if (filter === 'name') {
        return event.name.toLowerCase().includes(text);
      }
  
      if (filter === 'location') {
        return event.location.name.toLowerCase().includes(text);
      }
  
      return false;
    });
  }
}
