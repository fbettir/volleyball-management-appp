import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { Router } from '@angular/router';
import { TournamentService } from 'src/app/services/tournament.service';
import { PriceType } from 'src/app/models/priceType';
import { Level } from 'src/app/models/level';
import { TournamentType } from 'src/app/models/tournamentType';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatIcon } from '@angular/material/icon';

@Component({
  selector: 'app-tournament-form',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatButtonModule,
    MatIcon,
    MatDialogModule,
    MatFormFieldModule
  ],
  templateUrl: './tournament-form.component.html',
  styleUrls: ['./tournament-form.component.scss'],
})
export class TournamentFormComponent implements OnInit {
  form!: FormGroup;

  priceTypeOptions = Object.entries(PriceType)
    .filter(([key, value]) => typeof value === 'number')
    .map(([key, value]) => ({ label: key, value }));

  categoryOptions = Object.entries(Level)
    .filter(([key, value]) => typeof value === 'number')
    .map(([key, value]) => ({ label: key, value }));

  tournamentTypeOptions = Object.entries(TournamentType)
    .filter(([key, value]) => typeof value === 'number')
    .map(([key, value]) => ({ label: key, value }));

  constructor(
    private fb: FormBuilder,
    private tournamentService: TournamentService,
    private router: Router,
  ) {}

  ngOnInit(): void {
      console.log('FORM LOADED FROM:', window.location.href);

    this.form = this.fb.group({
      name: [
        '',
        [
          Validators.required,
          Validators.minLength(5),
          Validators.maxLength(100),
        ],
      ],
      date: ['', Validators.required],
      entryDeadline: ['', Validators.required],
      locationId: ['', Validators.required],
      organizer: [''],
      registrationPolicy: [''],
      teamPolicy: [''],
      courts: [1, Validators.required],
      maxTeamsPerLevel: [[], Validators.required],
      description: [''],
      pictureLink: [''],
      categories: ['', Validators.required],
      priceType: ['', Validators.required],
      tournamentType: ['', Validators.required],
    });
  }

  onSubmit() {
    if (this.form.invalid) return;

    const formValue = this.form.value;
    const payload = {
      ...formValue,
      maxTeamsPerLevel: formValue.maxTeamsPerLevel
        .split(',')
        .map((v: string) => +v.trim()),
    };

    this.tournamentService.insertTournament(payload).subscribe({
      next: () => this.router.navigate(['/admin']),
      error: (err) => console.error('Error creating tournament:', err),
    });
  }
}
