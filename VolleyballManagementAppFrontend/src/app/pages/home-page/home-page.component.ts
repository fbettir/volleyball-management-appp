import { Component, OnInit } from '@angular/core';
import { Tournament } from 'src/app/models/tournament';
import { TeamService } from 'src/app/services/team.service';
import { TournamentService } from 'src/app/services/tournament.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss'],
})
export class HomePageComponent {

  tournaments: Tournament[] = [];
  constructor(tournamentService: TournamentService) {
    tournamentService.getAllTournaments().subscribe(t => {
      this.tournaments = t;
    });
  }

}
