import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';

import { Training } from 'src/app/models/training';
import { TrainingService } from 'src/app/services/training.service';
import { TabChipComponent } from 'src/app/components/shared/tab-chip/tab-chip.component';
import { UserCardComponent } from 'src/app/components/cards/user-card/user-card.component';

@Component({
  selector: 'app-training-page',
  standalone: true,
  imports: [CommonModule, MatIconModule, TabChipComponent, UserCardComponent],
  templateUrl: './training-page.component.html',
})
export class TrainingPageComponent {
  private route = inject(ActivatedRoute);
  training: Training | null = null;
  selectedTab: string | null = null;

  constructor(private trainingService: TrainingService) {
    const trainingId = this.route.snapshot.params['trainingId'];
    this.trainingService.getTrainingById(trainingId).subscribe((t) => {
      console.log('Training loaded:', t);
      this.training = t;
    });
  }
}
