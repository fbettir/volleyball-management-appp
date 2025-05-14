import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-event-search-bar',
  standalone: true,
  imports: [FormsModule], 
  templateUrl: './event-search-bar.component.html',
  styleUrl: './event-search-bar.component.scss'
})
export class EventSearchBarComponent {
  searchText: string = '';
  selectedFilter: string = 'name';

  @Output() searchChanged = new EventEmitter<{ text: string; filter: string }>();
  
  onSearchChange() {
    this.searchChanged.emit({
      text: this.searchText.trim().toLowerCase(),
      filter: this.selectedFilter
    });
  }
}
