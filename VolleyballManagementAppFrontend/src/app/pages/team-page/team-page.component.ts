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
import { TicketPass } from 'src/app/models/ticket-pass';
import { TrainingsDialogComponent } from 'src/app/components/trainings-dialog/trainings-dialog.component';
import { PlayerDetails } from 'src/app/models/player-details';
@Component({
  selector: 'app-team-page',
  templateUrl: './team-page.component.html',
  styleUrls: ['./team-page.component.scss'],
})
export class TeamPageComponent implements OnInit {
  team?: Team = undefined;
  teamId : string = "";
  members: PlayerDetails[] = [];
  trainings: Training[] = [];
  dataSource = new MatTableDataSource<PlayerDetails>([]);
  dataSourceTrainings = new MatTableDataSource<Training>([]);

  displayedColumns: string[] = ['position', 'name', 'ticket', 'post', 'number', 'tools'];
  displayedColumnsTrainings: string[] = ['position', 'date', 'location', 'description', 'tools'];

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private teamService: TeamService,
    private dialog: MatDialog,
  ) {}

  ngOnInit() {
    this.teamId = this.route.snapshot.params['teamId'];
    this.dataSource.data = [];
    this.dataSourceTrainings.data = [];

    this.teamService.getTeamById(this.teamId).subscribe(team => {
      this.team = team;
      if (team !== undefined) {
        this.teamService.getTeamPlayersByTeamId(this.teamId).subscribe(teamPlayers => {
          this.members = teamPlayers;
          this.dataSource.data = teamPlayers;
        })
      }
    //this.dataSourceTrainings.data = trainings; //TODO: new endpoint
    });
    

  }

  addPlayerForm = this.formBuilder.group({
    role: Role.BasicUser,
    email: 'example@email.com',
    posts: Post.Receiver,
    ticket: TicketPass.Ticket,
    phone: "0",
    number: 0,
    birthday: new Date(),
    gender: Gender.Other,
  });



  onSubmit(): void { 
    const { posts, phone, ticket, number, birthday, gender} = this.addPlayerForm.value;
    const playerDetails: PlayerDetails = { 
    id : uuidv4(),
    userId: "",
    posts: [posts!],
    ticketPass: ticket!,
    phone: phone!,
    playerNumber: number!,
    birthday: birthday!,
    gender: gender! as Gender
    };
    this.dataSource.data = [...this.dataSource.data, playerDetails];
  }

  deleteUserFromTeam(index: number){
    this.dataSource.data.splice(index, 1);
    this.dataSource.data = [...this.dataSource.data];
  };

  deleteTrainingFromTeam(index: number){
    this.dataSourceTrainings.data.splice(index, 1);
    this.dataSourceTrainings.data = [...this.dataSourceTrainings.data];
  }

  openDialog(index: number, whatToOpen: string): void {
    var dialogRef = null;
    if(whatToOpen == 'trainings'){
      dialogRef = this.dialog.open(TrainingsDialogComponent, {
        data: this.dataSourceTrainings.data[index]
      });
    } else {
      dialogRef = this.dialog.open(UpdateDialogComponent, {
        data: this.dataSource.data[index]
      });
    }
    
    dialogRef.afterClosed().subscribe(result => {
      if(!result) this.dataSource.data = [...this.dataSource.data];
      this.dataSource.data.splice(index, 1, result);
      this.dataSource.data = [...this.dataSource.data];
    });
  }

  
  // openDialog(index: number): void {
  //   console.log(this.team?.members);
  //   const dialogRef = this.dialog.open(UpdateDialogComponent, {
  //     data: this.dataSource.data[index]
  //   });

  //   dialogRef.afterClosed().subscribe(result => {
  //     if(!result) this.dataSource.data = [...this.dataSource.data];
  //     this.dataSource.data.splice(index, 1, result);
  //     this.dataSource.data = [...this.dataSource.data];
  //   });
  // }

  openDialogTraining(index: number): void {
    const dialogRef = this.dialog.open(TrainingsDialogComponent, {
      data: this.dataSourceTrainings.data[index]
    });

    dialogRef.afterClosed().subscribe(result => {
      if(!result) this.dataSourceTrainings.data = [...this.dataSourceTrainings.data];
      this.dataSourceTrainings.data.splice(index, 1, result);
      this.dataSourceTrainings.data = [...this.dataSourceTrainings.data];
    });
  }

}
