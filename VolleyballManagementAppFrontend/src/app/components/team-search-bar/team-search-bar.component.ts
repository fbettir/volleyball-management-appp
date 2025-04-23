import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-team-search-bar',
  standalone: true,
  imports: [FormsModule], 
  templateUrl: './team-search-bar.component.html',
  styleUrls: ['./team-search-bar.component.scss']
})
export class TeamSearchBarComponent {
  // Add @Output or search logic later if needed
  searchText: string = '';
  selectedFilter: string = 'name';
}
