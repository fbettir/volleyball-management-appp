import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { EventSearchBarComponent } from 'src/app/components/event-search-bar/event-search-bar.component';
import { TabChipComponent } from 'src/app/components/tab-chip/tab-chip.component';
import { TournamentFormComponent } from 'src/app/components/tournament-form/tournament-form.component';
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
  ],
})
export class AdminPageComponent {
  tournaments: Tournament[] = [];
  filteredTournaments: Tournament[] = [];

  columns = ['name', 'date', 'actions'];

  selectedTab: string = 'tournaments';
  showTournamentForm = false;

  constructor(
    private tournamentService: TournamentService,
    private dialog: MatDialog,
  ) {}

  searchText = '';
  selectedFilter = 'name';

onCreateTournament(): void {
  console.log('Opening dialog...');
  const dialogRef = this.dialog.open(TournamentFormComponent, {
    width: '800px',
    maxWidth: '95vw',
    panelClass: 'tournament-dialog'
  });

  dialogRef.afterClosed().subscribe(() => {
    console.log('Dialog closed');
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

  viewTournament(tournament: Tournament) {
    // Navigate or open dialog
  }

  editTournament(tournament: Tournament) {
    // Navigate to form
  }

  deleteTournament(tournament: Tournament) {
    // Confirm & call service
  }
}
