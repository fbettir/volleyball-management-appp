import { Component, Inject } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { Gender } from 'src/app/models/gender';
import { PlayerDetails } from 'src/app/models/player-details';
import { PlayerDetailsWithName } from 'src/app/models/player-details-with-name';
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
    @Inject(MAT_DIALOG_DATA) public data: PlayerDetailsWithName,
  ) {}

  dataSource = new MatTableDataSource<PlayerDetailsWithName>([this.data]);

  posts: Post[] = this.dataSource.data[0].posts;

  addPlayerForm = this.formBuilder.group({
    ticketPass: this.dataSource.data[0].ticketPass,
    playerNumber: this.dataSource.data[0].playerNumber,
    posts: this.posts,
    name: this.dataSource.data[0].name,
    phone: this.dataSource.data[0].phone,
    birthday: this.dataSource.data[0].birthday,
    gender: this.dataSource.data[0].gender,
  });

  onNoClick(): void {
    console.log(this.dialogRef);
    this.dialogRef.close();
  }

  onSubmit(): void {
    const {  posts, name, phone, ticketPass, playerNumber, birthday, gender } =
      this.addPlayerForm.value;
    const player: PlayerDetailsWithName = {
      id: uuidv4(),
      name: name!,
      ticketPass: ticketPass!,
      playerNumber: playerNumber!,
      posts: [posts!],
      phone: phone!,
      birthday: birthday!,
      gender: gender! as Gender,
    };
    this.data = player;
  }
}
