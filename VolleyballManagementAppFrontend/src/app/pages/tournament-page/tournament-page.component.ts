import { TreeDataNodeFlattener } from '@angular/cdk/collections';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Tournament } from 'src/app/models/tournament';
import { TeamService } from 'src/app/services/team.service';
import { TournamentService } from 'src/app/services/tournament.service';
import { AuthHttpInterceptor, AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-tournament-page',
  templateUrl: './tournament-page.component.html',
  styleUrls: ['./tournament-page.component.scss'],
})
export class TournamentPageComponent {
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
 