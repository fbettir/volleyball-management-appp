import { Component } from '@angular/core';
import { Team } from 'src/app/models/team';

@Component({
  selector: 'app-all-teams-page',
  templateUrl: './all-teams-page.component.html',
  styleUrls: ['./all-teams-page.component.scss']
})
export class AllTeamsPageComponent {

  teams: Team[] = [];
}
