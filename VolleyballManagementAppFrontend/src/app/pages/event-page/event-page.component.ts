import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Tournament } from 'src/app/models/tournament';
import { TournamentService } from 'src/app/services/tournament.service';

@Component({
  selector: 'app-tournament-page',
  templateUrl: './event-page.component.html',
  styleUrls: ['./event-page.component.scss'],
})
export class EventPageComponent {
  tournamentId: string = "";
  tournament?: Tournament = undefined;

  constructor(
    private route: ActivatedRoute,
    private tournamentService: TournamentService,
  ) {}

  ngOnInit() {
    this.tournamentId = this.route.snapshot.params['tournamentId'];
    this.tournamentService.getTournamentById(this.tournamentId).subscribe(t => {
      this.tournament = t;
    });
  }
}
 