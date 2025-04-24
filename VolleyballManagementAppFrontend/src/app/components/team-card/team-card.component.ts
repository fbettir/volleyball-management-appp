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

  imageUrl: string = "https://spot.sch.bme.hu/photos/2025/20250329_muegyetemi_roplabda/2048/20250329_101126_adrian.jpg";


  imageFallback(event: Event) {
    (event.target as HTMLImageElement).src = 'assets/default-team.jpg';
  }
}
