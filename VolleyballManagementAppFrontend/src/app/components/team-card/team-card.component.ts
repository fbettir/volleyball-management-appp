import { Component, Input } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';
import { Team } from 'src/app/models/team';


@Component({
  selector: 'app-team-card',
  standalone: true,
  imports: [MatIconModule, RouterModule],
  templateUrl: './team-card.component.html',
  styleUrl: './team-card.component.scss'
})
export class TeamCardComponent {
  @Input() team!: Team;

}
