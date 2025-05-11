import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatIcon } from '@angular/material/icon';

@Component({
  selector: 'app-tab-chip',
    standalone: true,
    imports: [CommonModule, MatIcon],
  templateUrl: './tab-chip.component.html',
})
export class TabChipComponent {
  @Input() label!: string;
  @Input() icon!: string;
  @Input() active: boolean = false;

  @Output() select = new EventEmitter<void>();

  handleClick() {
    this.select.emit();
  }
}