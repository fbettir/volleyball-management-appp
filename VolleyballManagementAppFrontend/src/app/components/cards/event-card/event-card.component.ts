import { Component, Input } from '@angular/core';
import { Tournament } from 'src/app/models/entities/tournament';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-event-card',
  standalone: true,
  imports: [MatIconModule, RouterModule],
  templateUrl: './event-card.component.html',
  styleUrl: './event-card.component.scss'
})
export class EventCardComponent {
  @Input() tournament!: Tournament;

  imageFallback(event: Event) {
    (event.target as HTMLImageElement).src = 'assets/default-team.jpg';
  }
}
 