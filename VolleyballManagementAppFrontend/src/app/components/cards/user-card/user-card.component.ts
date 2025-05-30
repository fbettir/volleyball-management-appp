import { Component, Input } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';
import { User } from 'src/app/models/entities/user';

@Component({
  selector: 'app-user-card',
  standalone: true,
  imports: [RouterModule, MatIconModule],
  templateUrl: './user-card.component.html',
  styleUrls: ['./user-card.component.scss'],
})
export class UserCardComponent {
  @Input() user!: User;

  imageFallback(event: Event) {
    (event.target as HTMLImageElement).src = 'assets/default-user.jpg';
  }
}