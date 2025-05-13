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
import { MatDialogModule } from '@angular/material/dialog';
import { MatIcon } from '@angular/material/icon';
import { LocationService } from 'src/app/services/location.service';
import { Location } from 'src/app/models/location';

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
    MatFormFieldModule,
  ],
  templateUrl: './tournament-form.component.html',
  styleUrls: ['./tournament-form.component.scss'],
})
export class TournamentFormComponent implements OnInit {
  form!: FormGroup;
  locations: Location[] = [];

  priceTypeOptions = Object.values(PriceType);
  tournamentTypeOptions = Object.values(TournamentType);
  levelOptions = Object.values(Level);

  constructor(
    private fb: FormBuilder,
    private tournamentService: TournamentService,
    private locationService: LocationService,
    private router: Router,
  ) {}

  ngOnInit(): void {
    this.locationService.getAllLocations().subscribe({
      next: (locations) => (this.locations = locations),
      error: (err) => console.error('Failed to load locations', err),
    });
    this.form = this.fb.group({
      name: ['', Validators.required],
      date: [null, Validators.required],
      entryDeadline: [null, Validators.required],
      locationId: [null, Validators.required],
      organizer: [''],
      registrationPolicy: [''],
      teamPolicy: [''],
      description: [''],
      pictureLink: [''],
      priceType: [null, Validators.required],
      tournamentType: [null, Validators.required],
      categories: [[], Validators.required],
      maxTeamsPerLevel: [''],
      courts: [''],
    });
  }

  onSubmit() {
    if (this.form.invalid) return;

    const rawValue = this.form.value;

    const payload = {
      ...rawValue,
      categories: Array.isArray(rawValue.categories)
        ? rawValue.categories.join(',')
        : rawValue.categories,
    };

    console.log('Submitting tournament:', payload);

    this.tournamentService.insertTournament(payload).subscribe({
      next: () => {
        this.router.navigate(['/admin']);
      },
      error: (err) => {
        console.error('Error creating tournament:', err);
      },
    });
  }
}
