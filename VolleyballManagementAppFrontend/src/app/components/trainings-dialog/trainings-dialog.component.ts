import { Component, Inject } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { Gender } from 'src/app/models/gender';
import { Role } from 'src/app/models/role';
import { Training } from 'src/app/models/training';
import { User } from 'src/app/models/user';
import { v4 as uuidv4 } from 'uuid';

@Component({
  selector: 'app-trainings-dialog',
  templateUrl: './trainings-dialog.component.html',
  styleUrls: ['./trainings-dialog.component.scss']
})
export class TrainingsDialogComponent {
  constructor(
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<TrainingsDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Training,
  ){}
  
  dataSource = new MatTableDataSource<Training>([this.data]);

  participants: User[] = this.dataSource.data[0].participants;

  addTrainingForm = this.formBuilder.group({
    participants: this.participants,
    location: this.dataSource.data[0].location,
    date: this.dataSource.data[0].date,
    description: this.dataSource.data[0].description,
  });

  onNoClick(): void {
    console.log(this.dialogRef);
    this.dialogRef.close();
  }

  onSubmit(): void {
    const { participants, location, date, description } =
      this.addTrainingForm.value;
    const training: Training = {
      id: uuidv4(),
      participants: [participants!],
      location: location!,
      date: date!,
      description: description!,
    };
    this.data = training;
  }
}
