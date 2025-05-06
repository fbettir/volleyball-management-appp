import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { TrainingCardComponent } from 'src/app/components/training-card/training-card.component';
import { TrainingSearchBarComponent } from 'src/app/components/training-search-bar/training-search-bar.component';
import { Training } from 'src/app/models/training';
import { TrainingService } from 'src/app/services/training.service';

@Component({
  selector: 'app-trainings-page',
  standalone: true,
  imports: [TrainingSearchBarComponent, TrainingCardComponent, CommonModule],
  templateUrl: './trainings-page.component.html',
  styleUrl: './trainings-page.component.scss'
})
export class TrainingsPageComponent {
  trainings: Training[] = [];
  filteredTrainings: Training[] = [];

  constructor(trainingService: TrainingService){
    trainingService.getAllTrainings().subscribe((t) => {
      console.log('Loaded trainings:', t);
      this.trainings = t;
      this.filteredTrainings = t;
    })
  }
  
  onSearchChanged(search: { text: string; filter: string }) {
    const { text, filter } = search;
  
    this.filteredTrainings = this.trainings.filter(training => {
      if (!text) return true;
  
      if (filter === 'team') {
        return training.team.name.toLowerCase().includes(text);
      }
  
      if (filter === 'location') {
        return training.location.name.toLowerCase().includes(text);
      }
  
      return false;
    });
  }
}


 