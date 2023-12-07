import { Component, Inject } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { Gender } from 'src/app/models/gender';
import { PlayerDetails } from 'src/app/models/player-details';
import { Post } from 'src/app/models/post';
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
    @Inject(MAT_DIALOG_DATA) public data: PlayerDetails,
  ) {}

  dataSource = new MatTableDataSource<PlayerDetails>([this.data]);

  posts: Post[] = this.dataSource.data[0].posts;

  addPlayerForm = this.formBuilder.group({
    ticket: this.dataSource.data[0].ticketPass,
    number: this.dataSource.data[0].playerNumber,
    posts: this.posts,
    phone: this.dataSource.data[0].phone,
    birthday: this.dataSource.data[0].birthday,
    gender: this.dataSource.data[0].gender,
  });

  onNoClick(): void {
    console.log(this.dialogRef);
    this.dialogRef.close();
  }

  onSubmit(): void {
    const {  posts, phone, ticket, number, birthday, gender } =
      this.addPlayerForm.value;
    const player: PlayerDetails = {
      id: uuidv4(),
      userId: "",
      ticketPass: ticket!,
      playerNumber: number!,
      posts: [posts!],
      phone: phone!,
      birthday: birthday!,
      gender: gender! as Gender,
    };
    this.data = player;
  }
}
