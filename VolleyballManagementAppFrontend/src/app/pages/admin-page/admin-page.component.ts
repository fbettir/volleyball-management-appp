import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { RouterModule } from '@angular/router';
import { ConfirmDialogComponent } from 'src/app/components/forms/confirm-dialog/confirm-dialog.component';
import { EventSearchBarComponent } from 'src/app/components/search/event-search-bar/event-search-bar.component';
import { TabChipComponent } from 'src/app/components/shared/tab-chip/tab-chip.component';
import { TournamentFormComponent } from 'src/app/components/forms/tournament-form/tournament-form.component';
import { Tournament } from 'src/app/models/tournament';
import { TournamentService } from 'src/app/services/tournament.service';
import { Team } from 'src/app/models/team';
import { TeamService } from 'src/app/services/team.service';
import { TeamFormComponent } from 'src/app/components/forms/team-form/team-form.component';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatExpansionModule } from '@angular/material/expansion';

@Component({
  standalone: true,
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.scss'],
  imports: [
    CommonModule,
    FormsModule,
    MatInputModule,
    MatTableModule,
    MatButtonModule,
    MatFormFieldModule,
    MatSelectModule,
    MatIconModule,
    TabChipComponent,
    EventSearchBarComponent,
    RouterModule,
    MatExpansionModule,
  ],
})
export class AdminPageComponent {
  columns = ['name', 'date', 'actions'];
  searchText = '';
  selectedFilter = 'name';
  selectedTab: string = 'tournaments';
  showTournamentForm = false;

  tournaments: Tournament[] = [];
  filteredTournaments: Tournament[] = [];
  tournamentForEdit: Tournament;
  selectedTeam: { [tournamentId: string]: string } = {};

  teams: Team[] = [];
  filteredTeams: Team[] = [];
  teamColumns = ['name', 'city', 'actions'];
  teamSearchText = '';
  teamFilter = 'name';

  constructor(
    private tournamentService: TournamentService,
    private teamService: TeamService,
    private dialog: MatDialog,
  ) {}

  ngOnInit(): void {
    this.loadTournaments();
    this.loadTeams();
  }

  loadTournaments() {
    this.tournamentService.getAllTournaments().subscribe((tournaments) => {
      this.tournaments = tournaments;
      this.filterTournaments();
    });
  }

  loadTournamentTeams(tournament: Tournament): void {
    this.tournamentService
      .getTournamentById(tournament.id)
      .subscribe((loaded) => {
        tournament.teams = loaded.teams;
      });
  }

  loadTeams() {
    this.teamService.getAllTeams().subscribe((teams) => {
      this.teams = teams;
      this.filterTeams();
    });
  }

  onTeamSearchChanged(event: { text: string; filter: string }) {
    this.teamSearchText = event.text.toLowerCase();
    this.teamFilter = event.filter;
    this.filterTeams();
  }

  onTournamentSearchChanged(event: { text: string; filter: string }) {
    this.searchText = event.text;
    this.selectedFilter = event.filter;
    this.filterTournaments();
  }

  filterTeams() {
    this.filteredTeams = this.teams.filter((team) => {
      return team.name.toLowerCase().includes(this.teamSearchText);
    });
  }

  filterTournaments() {
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

  onCreateTeam(): void {
    const dialogRef = this.dialog.open(TeamFormComponent, {
      width: '800px',
      maxWidth: '95vw',
      panelClass: 'team-dialog',
    });

    dialogRef.afterClosed().subscribe(() => this.loadTeams());
  }

  onCreateTournament(): void {
    const dialogRef = this.dialog.open(TournamentFormComponent, {
      width: '800px',
      maxWidth: '95vw',
      panelClass: 'tournament-dialog',
    });

    dialogRef.afterClosed().subscribe(() => {
      console.log('Dialog closed');
      this.loadTournaments();
    });
  }

  editTeam(team: Team): void {
    const dialogRef = this.dialog.open(TeamFormComponent, {
      width: '800px',
      maxWidth: '95vw',
      panelClass: 'team-dialog',
      data: team,
    });

    dialogRef.afterClosed().subscribe(() => this.loadTeams());
  }

  editTournament(tournament: any): void {
    this.tournamentService
      .getTournamentById(tournament.id)
      .subscribe((tournaments) => {
        this.tournamentForEdit = tournaments;
        this.filterTournaments();
      });
    const dialogRef = this.dialog.open(TournamentFormComponent, {
      width: '800px',
      maxWidth: '95vw',
      panelClass: 'tournament-dialog',
      data: this.tournamentForEdit,
    });

    dialogRef.afterClosed().subscribe(() => {
      console.log('Dialog closed');
      this.loadTournaments();
    });
  }

  onDeleteTournament(tournament: Tournament): void {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '400px',
      maxWidth: '95vw',
      panelClass: 'tournament-dialog',
      data: {
        title: 'Delete Tournament',
        message: `Are you sure you want to delete "${tournament.name}"? This action cannot be undone.`,
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.tournamentService.deleteTournamentById(tournament.id).subscribe({
          next: () => {
            console.log('Tournament deleted'), this.loadTournaments();
          },
          error: (err) => console.error('Error deleting tournament', err),
        });
      }
    });
  }

  onDeleteTeam(team: Team): void {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '400px',
      maxWidth: '95vw',
      panelClass: 'team-dialog',
      data: {
        title: 'Delete Team',
        message: `Are you sure you want to delete "${team.name}"? This action cannot be undone.`,
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.teamService.deleteTeamById(team.id).subscribe({
          next: () => this.loadTeams(),
          error: (err) => console.error('Error deleting team', err),
        });
      }
    });
  }

  onAddTeamToTournament(tournamentId: string): void {
    const teamId = this.selectedTeam[tournamentId];
    if (!teamId) return;

    this.tournamentService
      .registerTournamentCompetitor(tournamentId, teamId)
      .subscribe(() => {
        this.selectedTeam[tournamentId] = '';

        const tournament = this.filteredTournaments.find(
          (t) => t.id === tournamentId,
        );
        if (tournament) {
          this.loadTournamentTeams(tournament);
        }
      });
  }

  onRemoveTeamFromTournament(tournamentId: string, team: Team): void {
    this.tournamentService
      .removeTeamFromTournament(tournamentId, team.id)
      .subscribe(() => {
        const tournament = this.filteredTournaments.find(
          (t) => t.id === tournamentId,
        );
        if (tournament) this.loadTournamentTeams(tournament);
      });
  }
}
