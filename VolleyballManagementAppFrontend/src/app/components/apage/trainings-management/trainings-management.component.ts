import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';

import { TrainingService } from 'src/app/services/training.service';
import { Training } from 'src/app/models/entities/training';
import { TrainingSearchBarComponent } from 'src/app/components/search/training-search-bar/training-search-bar.component';
import { TrainingFormComponent } from 'src/app/components/forms/training-form/training-form.component';
import { MatExpansionModule } from '@angular/material/expansion';
import { ConfirmDialogComponent } from '../../forms/confirm-dialog/confirm-dialog.component';
import { User } from 'src/app/models/entities/user';
import { UserService } from 'src/app/services/user.service';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-trainings-management',
  standalone: true,
  imports: [
    CommonModule,
    MatButtonModule,
    MatIconModule,
    MatExpansionModule,
    MatFormFieldModule,
    MatSelectModule,
    TrainingSearchBarComponent,
  ],
  templateUrl: './trainings-management.component.html',
  styleUrls: ['./trainings-management.component.scss'],
})
export class TrainingsManagementComponent implements OnInit {
  trainings: Training[] = [];
  filteredTrainings: Training[] = [];
  searchText = '';
  users: User[] = [];
  selectedUser: { [trainingId: string]: string } = {};

  constructor(
    private trainingService: TrainingService,
    private dialog: MatDialog,
    private userService: UserService,
  ) {}

  ngOnInit(): void {
    this.loadTrainings();
    this.loadUsers();
  }

  loadUsers(): void {
    this.userService.getAllUsers().subscribe((users) => {
      this.users = users;
    });
  }

  loadTrainings(): void {
    this.trainingService.getAllTrainings().subscribe((trainings) => {
      this.trainings = trainings;
      this.filteredTrainings = trainings;
    });
  }

  loadTrainingDetails(training: Training): void {
    this.trainingService.getTrainingById(training.id).subscribe((loaded) => {
      Object.assign(training, loaded);
    });
  }

  onSearchChanged(event: { text: string }): void {
    this.searchText = event.text.toLowerCase();
    this.filteredTrainings = this.trainings.filter(
      (t) => t.description?.toLowerCase().includes(this.searchText),
    );
  }

  onCreateTraining(): void {
    const dialogRef = this.dialog.open(TrainingFormComponent, {
      width: '800px',
      maxWidth: '95vw',
      panelClass: 'training-dialog',
    });

    dialogRef.afterClosed().subscribe(() => this.loadTrainings());
  }

  onEditTraining(training: Training): void {
    const dialogRef = this.dialog.open(TrainingFormComponent, {
      width: '800px',
      maxWidth: '95vw',
      panelClass: 'training-dialog',
      data: training,
    });

    dialogRef.afterClosed().subscribe(() => this.loadTrainings());
  }

  onDeleteTraining(training: Training): void {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '400px',
      maxWidth: '95vw',
      panelClass: 'user-dialog',
      data: {
        title: 'Delete Training',
        message: `Are you sure you want to delete "${training.team.name}" 's training? This action cannot be undone.`,
      },
    });

    dialogRef.afterClosed().subscribe((confirmed) => {
      if (confirmed) {
        this.trainingService.deleteTraining(training.id).subscribe({
          next: () => this.loadTrainings(),
          error: (err) => console.error('Error deleting training', err),
        });
      }
    });
  }

  onAddPlayerToTraining(trainingId: string): void {
    const userId = this.selectedUser[trainingId];
    if (!userId) return;

    this.trainingService
      .registerTrainingParticipant(trainingId, userId)
      .subscribe(() => {
        this.selectedUser[trainingId] = '';
        this.loadTrainings(); // újralistázás
      });
  }

  onRemovePlayerFromTraining(trainingId: string, user: User): void {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '400px',
      panelClass: 'training-dialog',
      data: {
        title: 'Remove Participant',
        message: `Remove "${user.name}" from this training?`,
      },
    });

    dialogRef.afterClosed().subscribe((confirmed) => {
      if (confirmed) {
        this.trainingService
          .removeTrainingParticipant(trainingId, user.id)
          .subscribe(() => {
            this.loadTrainings();
          });
      }
    });
  }
}
