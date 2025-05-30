import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { TeamService } from 'src/app/services/team.service';
import { TournamentService } from 'src/app/services/tournament.service';
import { OnInit } from '@angular/core';
import { Team } from 'src/app/models/entities/team';
import { Tournament } from 'src/app/models/entities/tournament';

@Component({
  selector: 'app-apply-dialog',
  standalone: true,
  templateUrl: './apply-dialog.component.html',
  styleUrls: ['./apply-dialog.component.css'],
  imports: [
    CommonModule,
    FormsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatSelectModule,
    MatButtonModule,
    MatInputModule,
  ],
})
export class ApplyDialogComponent implements OnInit {
  availableTeams: Team[] = [];
  selectedTeamId: string | null = null;
  tournamentTeams: Team[] = [];

  constructor(
    private teamService: TeamService,
    private tournamentService: TournamentService,
    private dialogRef: MatDialogRef<ApplyDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { tournamentId: string },
  ) {}

  ngOnInit(): void {
    this.teamService.getAllTeams().subscribe({
      next: (teams) => (this.availableTeams = teams),
      error: (err) => console.error('Error loading teams', err),
    });
  }

onApply(): void {
  const selectedTeam = this.availableTeams.find(
    (t) => t.id === this.selectedTeamId
  );
  if (!selectedTeam) return;

  this.tournamentService.getTournamentById(this.data.tournamentId).subscribe({
    next: (tournament) => {
      const isAlreadyRegistered = tournament.teams.some(
        (team) => team.id === selectedTeam.id
      );

      if (isAlreadyRegistered) {
        alert('This team is already registered for the tournament.');
        return;
      }

      this.tournamentService
        .registerTournamentCompetitor(this.data.tournamentId, selectedTeam.id)
        .subscribe({
          next: () => {
            this.dialogRef.close(true);
          },
          error: (err) => {
            console.error('Error registering team:', err);
          },
        });
    },
    error: (err) => {
      console.error('Failed to fetch tournament teams:', err);
    },
  });
}

  onCancel(): void {
    this.dialogRef.close();
  }
}
