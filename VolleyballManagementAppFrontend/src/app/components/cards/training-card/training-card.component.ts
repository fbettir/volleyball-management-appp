import { Component, Input } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';
import { Training } from 'src/app/models/entities/training';

@Component({
  selector: 'app-training-card',
  standalone: true,
  imports: [MatIconModule, RouterModule],
  templateUrl: './training-card.component.html',
  styleUrl: './training-card.component.scss'
})
export class TrainingCardComponent {
  @Input() training!: Training;

  get day(): string {
    return new Date(this.training.date).getDate().toString().padStart(2, '0');
  }

  get month(): string {
    return new Date(this.training.date).toLocaleString('default', { month: 'short' }).toUpperCase();
  }
  
  imageFallback(event: Event) {
    (event.target as HTMLImageElement).src = 'assets/default-team.jpg';
  }
}
