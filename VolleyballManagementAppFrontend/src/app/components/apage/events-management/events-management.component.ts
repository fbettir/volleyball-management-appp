import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatIconModule } from '@angular/material/icon';
import { MatExpansionModule } from '@angular/material/expansion';
import { RouterModule } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

import { EventSearchBarComponent } from 'src/app/components/search/event-search-bar/event-search-bar.component';
import { TournamentFormComponent } from 'src/app/components/forms/tournament-form/tournament-form.component';
import { ConfirmDialogComponent } from 'src/app/components/forms/confirm-dialog/confirm-dialog.component';

import { TournamentService } from 'src/app/services/tournament.service';
import { TeamService } from 'src/app/services/team.service';
import { Tournament } from 'src/app/models/tournament';
import { Team } from 'src/app/models/team';

@Component({
  selector: 'app-events-management',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    MatButtonModule,
    MatFormFieldModule,
    MatSelectModule,
    MatIconModule,
    MatExpansionModule,
    EventSearchBarComponent
  ],
  templateUrl: './events-management.component.html',
  styleUrls: ['./events-management.component.scss'],
})
export class EventsManagementComponent implements OnInit {
  tournaments: Tournament[] = [];
  filteredTournaments: Tournament[] = [];
  teams: Team[] = [];
  selectedTeam: { [tournamentId: string]: string } = {};

  searchText = '';
  selectedFilter = 'name';

  constructor(
    private tournamentService: TournamentService,
    private teamService: TeamService,
    private dialog: MatDialog,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.loadTournaments();
    this.loadTeams();
  }

  loadTournaments(): void {
    this.tournamentService.getAllTournaments().subscribe((tournaments) => {
      this.tournaments = tournaments;
      this.filterTournaments();
    });
  }

  loadTournamentTeams(tournament: Tournament): void {
    this.tournamentService.getTournamentById(tournament.id).subscribe((t) => {
      tournament.teams = t.teams;
    });
  }

  loadTeams(): void {
    this.teamService.getAllTeams().subscribe((teams) => {
      this.teams = teams;
    });
  }

  onTournamentSearchChanged(event: { text: string; filter: string }): void {
    this.searchText = event.text.toLowerCase();
    this.selectedFilter = event.filter;
    this.filterTournaments();
  }

  filterTournaments(): void {
    this.filteredTournaments = this.tournaments.filter((tournament) => {
      if (this.selectedFilter === 'name') {
        return tournament.name.toLowerCase().includes(this.searchText);
      } else if (this.selectedFilter === 'location') {
        return tournament.location?.name
          ?.toLowerCase()
          .includes(this.searchText);
      }
      return true;
    });
  }

  onCreateTournament(): void {
    const dialogRef = this.dialog.open(TournamentFormComponent, {
      width: '800px',
      maxWidth: '95vw',
      panelClass: 'tournament-dialog',
    });

    dialogRef.afterClosed().subscribe(() => this.loadTournaments());
  }

  editTournament(tournament: Tournament): void {
    const dialogRef = this.dialog.open(TournamentFormComponent, {
      width: '800px',
      maxWidth: '95vw',
      panelClass: 'tournament-dialog',
      data: tournament,
    });

    dialogRef.afterClosed().subscribe(() => this.loadTournaments());
  }

  onDeleteTournament(tournament: Tournament): void {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '400px',
      maxWidth: '95vw',
      panelClass: 'tournament-dialog',
      data: {
        title: 'Delete Tournament',
        message: `Are you sure you want to delete "${tournament.name}"?`,
      },
    });

    dialogRef.afterClosed().subscribe((confirmed) => {
      if (confirmed) {
        this.tournamentService.deleteTournamentById(tournament.id).subscribe({
          next: () => this.loadTournaments(),
          error: (err) => console.error('Delete error', err),
        });
      }
    });
  }

  onAddTeamToTournament(tournamentId: string): void {
    const teamId = this.selectedTeam[tournamentId];
    if (!teamId) return;

    const tournament = this.filteredTournaments.find((t) => t.id === tournamentId);
    if (tournament?.teams?.some((t) => t.id === teamId)) {
      this.snackBar.open('This team is already added.', 'Close', {
        duration: 4000,
        panelClass: ['bg-red-500', 'text-white', 'px-4', 'py-2', 'rounded'],
      });
      return;
    }

    this.tournamentService
      .registerTournamentCompetitor(tournamentId, teamId)
      .subscribe(() => {
        this.selectedTeam[tournamentId] = '';
        if (tournament) this.loadTournamentTeams(tournament);
      });
  }

  onRemoveTeamFromTournament(tournamentId: string, team: Team): void {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '400px',
      maxWidth: '95vw',
      panelClass: 'tournament-dialog',
      data: {
        title: 'Remove Team',
        message: `Remove "${team.name}" from this tournament?`,
      },
    });

    dialogRef.afterClosed().subscribe((confirmed) => {
      if (confirmed) {
        this.tournamentService
          .removeTeamFromTournament(tournamentId, team.id)
          .subscribe(() => {
            const tournament = this.filteredTournaments.find(
              (t) => t.id === tournamentId
            );
            if (tournament) this.loadTournamentTeams(tournament);
          });
      }
    });
  }
}
