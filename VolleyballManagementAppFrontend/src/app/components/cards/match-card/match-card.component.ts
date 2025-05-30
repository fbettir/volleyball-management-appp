import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { MatIcon } from '@angular/material/icon';
import { Match } from 'src/app/models/entities/match';
import { MatchState } from 'src/app/models/enums/matchState';

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
      this.match && this.isSetOver(this.match.points[0], this.match.points[1])
    ) {
      this.match.matchState = MatchState.Finished;
    }
  }

  isSetOver(
    homePoints: number,
    awayPoints: number,
    isFinalSet: boolean = false,
  ): boolean {
    const target = isFinalSet ? 15 : 25;
    const maxPoints = Math.max(homePoints, awayPoints);
    const pointDifference = Math.abs(homePoints - awayPoints);

    return maxPoints >= target && pointDifference >= 2;
  }
}
