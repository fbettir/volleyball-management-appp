import { Component } from '@angular/core';
import { Team } from 'src/app/models/team';

@Component({
  selector: 'app-all-teams-page',
  templateUrl: './all-teams-page.component.html',
  styleUrls: ['./all-teams-page.component.scss'],
})
export class AllTeamsPageComponent {
  teams: Team[] = [];

  
  description: String =
    'This team was created in 2016, they were champions in ....';
}

