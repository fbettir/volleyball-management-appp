import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { MatIcon } from '@angular/material/icon';
import { Match } from 'src/app/models/match';
import { MatchState } from 'src/app/models/matchState';

@Component({
  selector: 'app-match-card',
  standalone: true,
  imports: [CommonModule, MatIcon],
  templateUrl: './match-card.component.html',
})
export class MatchCardComponent {
  @Input() match: Match | null = null;

  MatchState = MatchState;


  get refereeName(): string | null {
  return this.match?.referee?.name ?? null;
}

  startMatch() {
    if (this.match) {
      this.match.matchState = MatchState.Ongoing;
    }
  }

  updatePoints(teamIndex: number, delta: number) {
    if (!this.match) return;
    const points = this.match.points[teamIndex] ?? 0;
    const newPoints = points + delta;
    if (newPoints >= 0) {
      this.match.points[teamIndex] = newPoints;
    }
  }

endMatch() {
  if (
    this.match &&
    (this.match.points[0] !== 0 || this.match.points[1] !== 0)
  ) {
    this.match.matchState = MatchState.Finished;
  }

}
}