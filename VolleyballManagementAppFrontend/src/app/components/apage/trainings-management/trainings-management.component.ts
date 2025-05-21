import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';

import { TrainingService } from 'src/app/services/training.service';
import { Training } from 'src/app/models/training';
import { TrainingSearchBarComponent } from 'src/app/components/search/training-search-bar/training-search-bar.component';
import { TrainingFormComponent } from 'src/app/components/forms/training-form/training-form.component';
import { MatExpansionModule } from '@angular/material/expansion';

@Component({
  selector: 'app-trainings-management',
  standalone: true,
  imports: [
    CommonModule,
    MatButtonModule,
    MatIconModule,
    MatExpansionModule,
    TrainingSearchBarComponent,
  ],
  templateUrl: './trainings-management.component.html',
  styleUrls: ['./trainings-management.component.scss'],
})
export class TrainingsManagementComponent implements OnInit {
  trainings: Training[] = [];
  filteredTrainings: Training[] = [];
  searchText = '';

  constructor(private trainingService: TrainingService, private dialog: MatDialog) {}

  ngOnInit(): void {
    this.loadTrainings();
  }

  loadTrainings(): void {
    this.trainingService.getAllTrainings().subscribe((trainings) => {
      this.trainings = trainings;
      this.filteredTrainings = trainings;
    });
  }

  onSearchChanged(event: { text: string }): void {
    this.searchText = event.text.toLowerCase();
    this.filteredTrainings = this.trainings.filter((t) =>
      t.description?.toLowerCase().includes(this.searchText)
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
}
