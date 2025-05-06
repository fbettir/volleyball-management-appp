import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Tournament } from 'src/app/models/tournament';
import { TournamentService } from 'src/app/services/tournament.service';

@Component({
  selector: 'app-tournament-page',
  templateUrl: './event-page.component.html',
  styleUrls: ['./event-page.component.scss'],
})
export class EventPageComponent {
  private route = inject(ActivatedRoute);

  event: Tournament | null = null;

  constructor(tournamentService: TournamentService) {
    const eventId = this.route.snapshot.params['eventId'];

    tournamentService.getTournamentById(eventId).subscribe((t) => {
      this.event = t;
      console.log("event loaded", this.event);
    });
  }

}
