import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Tournament } from 'src/app/models/tournament';
import { TeamService } from 'src/app/services/team.service';

@Component({
  selector: 'app-tournament-page',
  templateUrl: './tournament-page.component.html',
  styleUrls: ['./tournament-page.component.scss'],
})
export class TournamentPageComponent {
  tournamentId = 1;
  tournament?: Tournament = undefined;

  constructor(
    private route: ActivatedRoute,
    private teamService: TeamService,
  ) {}

  ngOnInit() {
    this.tournamentId = parseInt(this.route.snapshot.params['tournamentId'], 10);
    this.tournament = this.teamService.getTournamentById(this.tournamentId);
  }
}
 