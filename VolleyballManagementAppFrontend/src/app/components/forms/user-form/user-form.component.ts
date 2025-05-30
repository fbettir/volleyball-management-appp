import { Component, Inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  FormGroup,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatIcon } from '@angular/material/icon';

import { UserService } from 'src/app/services/user.service';
import { User } from 'src/app/models/entities/user';
import { v4 as uuidv4 } from 'uuid';
import { Gender } from 'src/app/models/enums/gender';
import { Role } from 'src/app/models/enums/role';
import { PriceType } from 'src/app/models/enums/priceType';
import { Post } from 'src/app/models/enums/post';

@Component({
  selector: 'app-user-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatDialogModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatIcon,
  ],
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss'],
})
export class UserFormComponent implements OnInit {
  form!: FormGroup;

  genderOptions = Object.values(Gender);
  roleOptions = Object.values(Role);
  priceTypeOptions = Object.values(PriceType);
  postOptions = Object.values(Post).filter((p) => typeof p === 'string'); // Filter out numeric values from Post enum

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private dialogRef: MatDialogRef<UserFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: User | null,
  ) {}

  ngOnInit(): void {
  this.form = this.fb.group({
    name: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    birthday: [null, Validators.required],
    phone: [''],
    playerNumber: [null],
    pictureLink: [''],
    gender: ['', Validators.required],
    roles: [[], Validators.required],
    priceType: [[], Validators.required],
    posts: [[], Validators.required],
  });

  if (this.data) {
    this.form.patchValue({
      ...this.data,
      priceType: this.data.priceType?.split(',') || [],
      posts: this.data.posts?.split(',') || [],
    });
  }
}

onSubmit(): void {
  if (this.form.invalid) return;

  const rawValue = this.form.value;

  const payload: User = {
    ...rawValue,
    id: this.data?.id ?? uuidv4(),
    roles: rawValue.roles.join(','),
    priceType: rawValue.priceType.join(','),
    posts: rawValue.posts.join(','),
  };

  const action = this.data
    ? this.userService.modifyUserById(payload)
    : this.userService.insertUser(payload);

  action.subscribe({
    next: () => this.dialogRef.close(),
    error: (err) => console.error('Failed to save user:', err),
  });
}

}
