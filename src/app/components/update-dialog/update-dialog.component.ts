import { Component, Inject } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { Gender } from 'src/app/models/gender';
import { Role } from 'src/app/models/role';
import { User } from 'src/app/models/user';
import { v4 as uuidv4 } from 'uuid';

@Component({
  selector: 'app-update-dialog',
  templateUrl: './update-dialog.component.html',
  styleUrls: ['./update-dialog.component.scss'],
})
export class UpdateDialogComponent {
  constructor(
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<UpdateDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: User,
  ) {}

  dataSource = new MatTableDataSource<User>([this.data]);

  addPlayerForm = this.formBuilder.group({
    name: this.dataSource.data[0].name,
    role: this.dataSource.data[0].role,
    email: this.dataSource.data[0].email,
    post: this.dataSource.data[0].post,
    phone: this.dataSource.data[0].phone,
    birthday: this.dataSource.data[0].birthday,
    gender: this.dataSource.data[0].gender,
  });

  onNoClick(): void {
    console.log(this.dialogRef);
    this.dialogRef.close();
  }

  onSubmit(): void {
    console.log(this.dataSource);
    console.log(this.data);
    const { name, role, email, post, phone, birthday, gender } =
      this.addPlayerForm.value;
    const user: User = {
      id: uuidv4(),
      name: name!,
      role: role! as Role,
      email: email!,
      post: post!,
      phone: phone!,
      birthday: birthday!,
      gender: gender! as Gender,
    };
    this.data = user;
    console.log(this.data);
  }
}
