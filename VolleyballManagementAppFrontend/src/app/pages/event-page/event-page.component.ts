import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { MatIcon } from '@angular/material/icon';
import { ActivatedRoute } from '@angular/router';
import { MatchCardComponent } from 'src/app/components/cards/match-card/match-card.component';
import { TabChipComponent } from 'src/app/components/shared/tab-chip/tab-chip.component';
import { TeamCardComponent } from 'src/app/components/cards/team-card/team-card.component';
import { Match } from 'src/app/models/entities/match';
import { Tournament } from 'src/app/models/entities/tournament';
import { TournamentService } from 'src/app/services/tournament.service';
import { MatDialog } from '@angular/material/dialog';
import { ApplyDialogComponent } from 'src/app/components/forms/apply-dialog/apply-dialog.component';

@Component({
  selector: 'app-tournament-page',
  standalone: true,
  imports: [
    CommonModule,
    TeamCardComponent,
    MatchCardComponent,
    TabChipComponent,
    MatIcon,
  ],
  templateUrl: './event-page.component.html',
  styleUrls: ['./event-page.component.scss'],
})
export class EventPageComponent {
  private route = inject(ActivatedRoute);

  event: Tournament | null = null;
  day: string | null;
  month: string | null;
  year: string | null;
  matches: Match[] | [];
  points1: number;
  points2: number;
  schedule: { time: string; matches: (Match | null)[] }[] = [];
  courts: number | 2;
  selectedTab: string | null = null;
  isOwner = true;
  maxTeamsPerLevel: number[] | [];

  constructor(
    private tournamentService: TournamentService,
    private dialog: MatDialog,
  ) {
    this.loadTournament();
  }

  loadTournament() {
    const eventId = this.route.snapshot.params['eventId'];

    this.tournamentService.getTournamentById(eventId).subscribe((t) => {
      this.event = t;
      console.log('event loaded', this.event);
      this.day = new Date(this.event.date)
        .getDate()
        .toString()
        .padStart(2, '0');
      this.month = new Date(this.event.date)
        .toLocaleString('default', {
          month: 'short',
        })
        .toUpperCase();
      this.year = new Date(this.event.date).getFullYear().toString();
      this.matches = this.event.matches;
      this.courts = this.event.courts;
      console.log(this.matches);
      this.sortSchedule();
      console.log('schedule', this.schedule);
      this.maxTeamsPerLevel = this.event.maxTeamsPerLevel;
    });
  }

  sortSchedule(): void {
    if (
      !this.matches ||
      !Array.isArray(this.matches) ||
      !this.courts ||
      this.courts < 1 ||
      !this.event?.id
    ) {
      return;
    }

    const matchesForTournament = this.matches
      .filter((m) => m.tournament?.id === this.event?.id)
      .sort(
        (a, b) =>
          new Date(a.startTime).getTime() - new Date(b.startTime).getTime(),
      );

    const groupedByTime: { [key: string]: (Match | null)[] } = {};

    for (const match of matchesForTournament) {
      const timeKey = new Date(match.startTime).toISOString();
      if (!groupedByTime[timeKey]) {
        groupedByTime[timeKey] = [];
      }
      groupedByTime[timeKey].push(match);
    }

    this.schedule = [];

    Object.keys(groupedByTime)
      .sort((a, b) => new Date(a).getTime() - new Date(b).getTime())
      .forEach((timeKey) => {
        const matchGroup = groupedByTime[timeKey];

        while (matchGroup.length < this.courts) {
          matchGroup.push(null);
        }

        const displayTime = new Date(timeKey).toLocaleTimeString([], {
          hour: '2-digit',
          minute: '2-digit',
        });

        this.schedule.push({ time: displayTime, matches: matchGroup });
      });
  }

  checkAndAssignTeamsIfFull(): void {
  if (!this.event || !this.event.teams || !this.event.maxTeamsPerLevel) return;

  const maxTeamCount = this.event.maxTeamsPerLevel.reduce(
    (sum, val) => sum + val,
    0,
  );

  if (this.event.teams.length === maxTeamCount) {
    const teamDtos = this.event.teams.map((team) => ({
      teamId: team.id,
    }));

    this.tournamentService
      .updateTournamentTeams(this.event.id, teamDtos)
      .subscribe({
        next: () =>
          console.log('Match teams assigned automatically.'),
        error: (err) =>
          console.error('Failed to assign match teams:', err),
      });
  } else {
    console.log(
      `Current: ${this.event.teams.length}, required: ${maxTeamCount}. Waiting for more teams...`,
    );
  }
}

  onApplyClick(): void {
    const dialogRef = this.dialog.open(ApplyDialogComponent, {
      width: '400px',
      data: { tournamentId: this.event?.id },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.loadTournament();
        console.log('Applied successfully!');
      }
    });
  }
}
