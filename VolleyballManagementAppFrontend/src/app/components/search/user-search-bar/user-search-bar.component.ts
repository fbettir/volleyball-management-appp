import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-user-search-bar',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './user-search-bar.component.html',
  styleUrl: './user-search-bar.component.css'
})
export class UserSearchBarComponent {
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
