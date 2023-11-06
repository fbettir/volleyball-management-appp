import { Component, OnInit } from '@angular/core';
import { Tournament } from 'src/app/models/tournament';
import { TeamService } from 'src/app/services/team.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss'],
})
export class HomePageComponent {

  tournaments: Tournament[] = [];
  constructor(teamService: TeamService) {
    this.tournaments = teamService.tournaments;
  }

}
