import { Component, Input } from '@angular/core';
import { Tournament } from 'src/app/models/tournament';
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

}
