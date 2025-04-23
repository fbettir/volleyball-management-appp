import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { TeamSearchBarComponent } from 'src/app/components/team-search-bar/team-search-bar.component';
import { TrainingCardComponent } from 'src/app/components/training-card/training-card.component';
import { Training } from 'src/app/models/training';
import { TrainingService } from 'src/app/services/training.service';

@Component({
  selector: 'app-trainings-page',
  standalone: true,
  imports: [TeamSearchBarComponent, TrainingCardComponent, CommonModule],
  templateUrl: './trainings-page.component.html',
  styleUrl: './trainings-page.component.scss'
})
export class TrainingsPageComponent {
  trainings: Training[] = [];

  constructor(trainingService: TrainingService){
    trainingService.getAllTrainings().subscribe((t) => {
      console.log('Loaded trainings:', t);
      this.trainings = t;
    })
  }
}
