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
import { v4 as uuidv4 } from 'uuid';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Inject } from '@angular/core';

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
    private dialogRef: MatDialogRef<TournamentFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
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
      priceType: [[], Validators.required],
      tournamentType: [null, Validators.required],
      categories: [[], Validators.required],
      maxTeamsPerLevel: [''],
      courts: [''],
    });
    if (this.data) {
      this.form.patchValue({
        ...this.data,
        categories: this.data.categories?.split(',') || [],
        priceType: this.data.priceType?.split(',') || [],
        maxTeamsPerLevel: this.data.maxTeamsPerLevel?.join(', ') || '',
      });
    }
  }

  onSubmit() {
    if (this.form.invalid) return;

    const rawValue = this.form.value;

    const payload = {
      ...rawValue,
      id: this.data?.id ?? uuidv4(),
      categories: rawValue.categories.join(','),
      priceType: rawValue.priceType.join(','),
      maxTeamsPerLevel: rawValue.maxTeamsPerLevel
        .split(',')
        .map((val: string) => parseInt(val.trim(), 10)),
    };

    if (this.data) {
      this.tournamentService.modifyTournamentById(payload).subscribe({
        next: () => this.dialogRef.close(),
        error: (err) => console.error('Error updating tournament:', err),
      });
    } else {
      this.tournamentService.insertTournament(payload).subscribe({
        next: () => this.dialogRef.close(),
        error: (err) => console.error('Error creating tournament:', err),
      });
    }
  }
}
