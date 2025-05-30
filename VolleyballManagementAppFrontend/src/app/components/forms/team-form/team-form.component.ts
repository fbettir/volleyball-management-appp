import { Component, Inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import {
  MatDialogModule,
  MatDialogRef,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { v4 as uuidv4 } from 'uuid';

import { LocationService } from 'src/app/services/location.service';
import { TeamService } from 'src/app/services/team.service';
import { Location } from 'src/app/models/entities/location';
import { UserService } from 'src/app/services/user.service';
import { User } from 'src/app/models/entities/user';
import { forkJoin } from 'rxjs';
@Component({
  selector: 'app-team-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatDialogModule,
    MatIcon,
  ],
  templateUrl: './team-form.component.html',
  styleUrls: ['./team-form.component.scss'],
})
export class TeamFormComponent implements OnInit {
  form!: FormGroup;
  locations: Location[] = [];
  users: User[] = [];

  constructor(
    private fb: FormBuilder,
    private locationService: LocationService,
    private teamService: TeamService,
    private dialogRef: MatDialogRef<TeamFormComponent>,
    private userService: UserService,
    @Inject(MAT_DIALOG_DATA) public data: any,
  ) {}

  ngOnInit(): void {
    
    this.locationService.getAllLocations().subscribe({
      next: (locs) => (this.locations = locs),
      error: (err) => console.error('Failed to load locations', err),
    });
    this.userService.getAllUsers().subscribe({
      next: (users) => (this.users = users),
      error: (err) => console.error('Failed to load users', err),
    });
    this.form = this.fb.group({
      name: ['', Validators.required],
      description: [''],
      pictureLink: [''],
      locationId: [[], Validators.required],
      ownerId: [[], Validators.required],
    });

    if (this.data) {
      this.form.patchValue({
        ...this.data,
        locationId: this.data.location?.id || null,
        ownerId: this.data.owner?.id || null,
      });
    }
  }

  onSubmit() {
    if (this.form.invalid) return;

    const rawValue = this.form.value;

    const payload = {
      ...rawValue,
      id: this.data?.id ?? uuidv4(),
      players: this.data?.players ?? [],
      coaches: this.data?.coaches ?? [],
      matches: this.data?.matches ?? [],
      trainings: this.data?.training ?? [],
      tournaments: this.data?.players ?? [],
      userHasAsFavourite: this.data?.userHasAsFavourite ?? [],
    };

    if (this.data) {
      this.teamService.modifyTeamById(payload).subscribe({
        next: () => this.dialogRef.close(),
        error: (err) => console.error('Error updating team:', err),
      });
    } else {
      this.teamService.insertTeam(payload).subscribe({
        next: () => this.dialogRef.close(),
        error: (err) => console.error('Error creating team:', err),
      });
    }
  }
}
