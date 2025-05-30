import { Component, Inject, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { CommonModule } from '@angular/common';
import {
  MatDialogRef,
  MAT_DIALOG_DATA,
  MatDialogModule,
} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';

import { LocationService } from 'src/app/services/location.service';
import { TrainingService } from 'src/app/services/training.service';
import { Location } from 'src/app/models/entities/location';
import { PriceType } from 'src/app/models/enums/priceType';
import { v4 as uuidv4 } from 'uuid';
import { MatIcon } from '@angular/material/icon';
import { User } from 'src/app/models/entities/user';
import { Team } from 'src/app/models/entities/team';
import { TeamService } from 'src/app/services/team.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-training-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatDialogModule,
    MatIcon,
  ],
  templateUrl: './training-form.component.html',
  styleUrls: ['./training-form.component.scss'],
})
export class TrainingFormComponent implements OnInit {
  form!: FormGroup;
  locations: Location[] = [];
  priceTypeOptions = Object.values(PriceType);
  teams: Team[] = [];
  coaches: User[] = [];

  constructor(
    private fb: FormBuilder,
    private locationService: LocationService,
    private trainingService: TrainingService,
    private teamService: TeamService,
    private userService: UserService,
    private dialogRef: MatDialogRef<TrainingFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
  ) {}

  ngOnInit(): void {
    this.locationService.getAllLocations().subscribe({
      next: (locations) => (this.locations = locations),
      error: (err) => console.error('Failed to load locations', err),
    });

    this.teamService.getAllTeams().subscribe({
      next: (teams) => (this.teams = teams),
      error: (err) => console.error('Failed to load teams', err),
    });

    this.userService.getAllCoaches().subscribe({
      next: (coaches) => (this.coaches = coaches),
      error: (err) => console.error('Failed to load coaches', err),
    });

    this.form = this.fb.group({
      date: [null, Validators.required],
      locationId: [null, Validators.required],
      description: [''],
      pictureLink: [''],
      teamId: [null, Validators.required],
      coachId: [null, Validators.required],
      priceType: [null, Validators.required],
    });

    if (this.data) {
      this.form.patchValue({
        ...this.data,
        locationId: this.data.location?.id,
        teamId: this.data.team?.id,
        coachId: this.data.coach?.id,
      });
    }
  }

  onSubmit(): void {
    if (this.form.invalid) return;

    const raw = this.form.value;

    const payload = {
      ...raw,
      id: this.data?.id ?? uuidv4(),
      players: this.data?.players ?? [],
      userHasAsFavourite: this.data?.userHasAsFavourite ?? [],
    };

    console.log('location:', payload.location);
    console.log('team:', payload.team);
    console.log('coach:', payload.coach);

    if (this.data) {
      this.trainingService.modifyTrainingById(payload).subscribe({
        next: () => this.dialogRef.close(),
        error: (err) => console.error('Error updating training:', err),
      });
    } else {
      this.trainingService.insertTraining(payload).subscribe({
        next: () => this.dialogRef.close(),
        error: (err) => console.error('Error creating training:', err),
      });
    }
  }
}
