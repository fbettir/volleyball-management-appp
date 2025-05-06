import { Component, Input } from '@angular/core';
import { Match } from 'src/app/models/match';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-match-card',
  standalone: true,
  imports: [CommonModule, MatIconModule, RouterModule],
  templateUrl: './match-card.component.html',
  styleUrl: './match-card.component.scss'
})
export class MatchCardComponent {
  @Input() match!: Match;

  ngOnInit(): void {
    console.log("match");
    console.log(this.match);

  }

  get day(): string {
    //console.log("match: " + this.match);

    return new Date(this.match.date).getDate().toString().padStart(2, '0');
  }

  get month(): string {
    return new Date(this.match.date).toLocaleString('default', {
      month: 'short',
    }).toUpperCase();
  }

  get matchTitle(): string {
    const [teamA, teamB] = this.match.teams;
    return teamA && teamB
      ? `${teamA.name} vs ${teamB.name}`
      : 'Match';
  }

  get picture(): string {
    return this.match.teams[0]?.pictureLink || "";
  }
  imageFallback(event: Event) {
    (event.target as HTMLImageElement).src = 'assets/default-team.jpg';
  }
}
