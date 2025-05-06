import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { MatIcon } from '@angular/material/icon';
import { ActivatedRoute } from '@angular/router';
import { TeamCardComponent } from 'src/app/components/team-card/team-card.component';
import { Match } from 'src/app/models/match';
import { Tournament } from 'src/app/models/tournament';
import { TournamentService } from 'src/app/services/tournament.service';

@Component({
  selector: 'app-tournament-page',
  standalone: true,
  imports: [CommonModule, TeamCardComponent, MatIcon],
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
  points1: number[] | [];
  points2: number[] | [];
  schedule: { time: string; matches: (Match | null)[] }[] = [];


  constructor(tournamentService: TournamentService) {
    const eventId = this.route.snapshot.params['eventId'];

    tournamentService.getTournamentById(eventId).subscribe((t) => {
      this.event = t;
      console.log("event loaded", this.event);
      this.day = new Date(this.event.date).getDate().toString().padStart(2, '0');
      this.month = new Date(this.event.date).toLocaleString('default', {
        month: 'short',
      }).toUpperCase();
      this.year = new Date(this.event.date).getFullYear().toString();
      this.matches = this.event.matches;

      console.log(this.matches);
      this.sortSchedule();
      console.log('schedule', this.schedule);

    });
  }


  sortSchedule(): void {
    this.matches.sort(
      (a, b) => new Date(a.startTime).getTime() - new Date(b.startTime).getTime()
    );
  
    this.schedule = [];
  
    for (let i = 0; i < this.matches.length; i += 2) {
      const matchGroup: (Match | null)[] = this.matches.slice(i, i + 2);
  
      const time = new Date(matchGroup[0]!.startTime).toLocaleTimeString([], {
        hour: '2-digit',
        minute: '2-digit',
      });
  
      while (matchGroup.length < 2) {
        matchGroup.push(null);
      }
  
      this.schedule.push({ time, matches: matchGroup });
    }
  }

}
