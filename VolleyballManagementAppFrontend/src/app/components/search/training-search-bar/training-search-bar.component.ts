import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-training-search-bar',
  standalone: true,
  imports: [FormsModule], 
  templateUrl: './training-search-bar.component.html',
  styleUrl: './training-search-bar.component.scss'
})
export class TrainingSearchBarComponent {
  searchText: string = '';
  selectedFilter: string = 'team';

  @Output() searchChanged = new EventEmitter<{ text: string; filter: string }>();
  
  onSearchChange() {
    this.searchChanged.emit({
      text: this.searchText.trim().toLowerCase(),
      filter: this.selectedFilter
    });
  }
}
 