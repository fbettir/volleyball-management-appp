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

@Component({
  standalone: true,
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.scss'],
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatTableModule,
    TabChipComponent,
    EventSearchBarComponent,
    RouterModule,
  ],
})
export class AdminPageComponent {
  tournaments: Tournament[] = [];
  filteredTournaments: Tournament[] = [];
  columns = ['name', 'date', 'actions'];
  searchText = '';
  selectedFilter = 'name';
  selectedTab: string = 'tournaments';
  showTournamentForm = false;
  tournamentForEdit: Tournament;

  constructor(
    private tournamentService: TournamentService,
    private dialog: MatDialog,
  ) {}



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

  onSearchChanged(event: { text: string; filter: string }) {
    this.searchText = event.text;
    this.selectedFilter = event.filter;
    this.filterTournaments();
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

  ngOnInit(): void {
    this.loadTournaments();
  }

  loadTournaments() {
    this.tournamentService.getAllTournaments().subscribe((tournaments) => {
      this.tournaments = tournaments;
      this.filterTournaments();
    });
  }

  editTournament(tournament: any): void {
    this.tournamentService.getTournamentById(tournament.id).subscribe((tournaments) => {
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
            console.log('Tournament deleted'), 
            this.loadTournaments();
          },
          error: (err) => console.error('Error deleting tournament', err),
        });
      }
    });
  }
}
