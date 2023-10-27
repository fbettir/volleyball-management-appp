import { Component, Input, OnInit } from '@angular/core';
import { Gender } from 'src/app/models/gender';
import { Post } from 'src/app/models/post';
import { Role } from 'src/app/models/role';
import { User } from 'src/app/models/user';
import { FormBuilder } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { Team } from 'src/app/models/team';
import { ActivatedRoute } from '@angular/router';
import { TeamService } from 'src/app/services/team.service';
import { v4 as uuidv4 } from 'uuid';
import {MatDialog, MAT_DIALOG_DATA, MatDialogRef, MatDialogModule} from '@angular/material/dialog';
import { UpdateDialogComponent } from 'src/app/components/update-dialog/update-dialog.component';
import { Training } from 'src/app/models/training';
@Component({
  selector: 'app-team-page',
  templateUrl: './team-page.component.html',
  styleUrls: ['./team-page.component.scss'],
})
export class TeamPageComponent implements OnInit {
  team?: Team = undefined;
  teamId = 1;
  dataSource = new MatTableDataSource<User>([]);
  dataSourceTrainings = new MatTableDataSource<Training>([]);
  displayedColumns: string[] = ['position', 'name', 'ticket', 'post', 'number', 'tools'];
  displayedColumnsTrainings: string[] = ['position', 'date', 'location', 'description'];

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private teamService: TeamService,
    private dialog: MatDialog,
  ) {}

  ngOnInit() {
    this.teamId = parseInt(this.route.snapshot.params['teamId'], 10);
    this.team = this.teamService.getTeamById(this.teamId);
    this.dataSource.data = this.team?.members || [];
    this.dataSourceTrainings.data = this.team?.trainings || [];
  }

  addPlayerForm = this.formBuilder.group({
    name: 'someone',
    role: Role.User,
    email: 'example@email.com',
    post: Post.Receiver,
    phone: 0,
    birthday: new Date(),
    gender: Gender.Other,
  });

  onSubmit(): void { 
    const {name, role, email, post, phone, birthday, gender} = this.addPlayerForm.value;
    const user: User = { 
    id : uuidv4(),
    name: name!,
    role: role! as Role,
    email: email!,
    post: post!,
    phone: phone!,
    birthday: birthday!,
    gender: gender! as Gender
    };
    console.log(user);
    this.dataSource.data = [...this.dataSource.data, user];
  }

  deleteUserFromTeam(index: number){
    this.dataSource.data.splice(index, 1);
    this.dataSource.data = [...this.dataSource.data];
  };

  openDialog(index: number): void {
    console.log(this.team?.members);
    const dialogRef = this.dialog.open(UpdateDialogComponent, {
      data: this.dataSource.data[index]
    });

    dialogRef.afterClosed().subscribe(result => {
      if(!result) this.dataSource.data = [...this.dataSource.data];
      this.dataSource.data.splice(index, 1, result);
      this.dataSource.data = [...this.dataSource.data];
    });
  }
}
