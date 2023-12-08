import { Component, Input, OnInit } from '@angular/core';
// import { Gender } from 'src/app/models/gender';
// import { Post } from 'src/app/models/post';
// import { Role } from 'src/app/models/role';
// import { FormBuilder } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { Team } from 'src/app/models/team';
import { ActivatedRoute } from '@angular/router';
import { TeamService } from 'src/app/services/team.service';
// import { v4 as uuidv4 } from 'uuid';
import {MatDialog, MAT_DIALOG_DATA, MatDialogRef, MatDialogModule} from '@angular/material/dialog';
import { UpdateDialogComponent } from 'src/app/components/update-dialog/update-dialog.component';
import { Training } from 'src/app/models/training';
import { TicketPass } from 'src/app/models/ticket-pass';
import { TrainingsDialogComponent } from 'src/app/components/trainings-dialog/trainings-dialog.component';
import { PlayerDetails } from 'src/app/models/player-details';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';
import { PlayerDetailsWithName } from 'src/app/models/player-details-with-name';
@Component({
  selector: 'app-team-page',
  templateUrl: './team-page.component.html',
  styleUrls: ['./team-page.component.scss'],
})
export class TeamPageComponent implements OnInit {
  team?: Team = undefined;
  teamId : string = "";
  members: PlayerDetails[] = [];
  membersWithName: PlayerDetailsWithName[] = [];
  users: User[] = [];
  trainings: Training[] = [];
  dataSourcePlayers = new MatTableDataSource<PlayerDetailsWithName>([]);
  dataSourceTrainings = new MatTableDataSource<Training>([]);

  displayedColumns: string[] = ['position', 'name', 'ticket', 'post', 'number', 'tools'];
  displayedColumnsTrainings: string[] = ['position', 'date', 'location', 'description', 'tools'];

  constructor(
    // private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private teamService: TeamService,
    private userService: UserService,
    private dialog: MatDialog,
  ) {}

  ngOnInit() {
    this.teamId = this.route.snapshot.params['teamId'];
    this.dataSourcePlayers.data = [];
    this.dataSourceTrainings.data = [];

    this.teamService.getTeamById(this.teamId).subscribe(team => {
      this.team = team;
      if (team !== undefined) {
        console.log(team);
        this.teamService.getTeamPlayersByTeamId(this.teamId).subscribe(teamPlayers => {
          this.members = teamPlayers;          

          console.log(this.members);
          if(this.members !== undefined){
          this.members.forEach( m => {
            this.userService.getUserById(m.userId).subscribe( user => {
              this.users.push(user);
            })
            if(this.users !== undefined){
              this.members.forEach( m => {
                const player: PlayerDetailsWithName = {
                  id: m.id,
                  name: "",
                  birthday: m.birthday,
                  phone: m.phone,
                  playerNumber: m.playerNumber,
                  ticketPass: m.ticketPass,
                  gender: m.gender,
                  posts: m.posts,                  
                }
                this.membersWithName.push(player);
              });
              console.log(this.membersWithName);
              this.dataSourcePlayers.data = this.membersWithName;
            }
          });
          }
        })
      }
    //this.dataSourceTrainings.data = trainings; //TODO: new endpoint from teamService
    });
    

  }

  // addPlayerForm = this.formBuilder.group({
  //   userId: "",
  //   birthday: new Date(),
  //   phone: "0",
  //   playerNumber: 0,
  //   posts: Post.Receiver,
  //   ticket: TicketPass.Ticket,
  //   gender: Gender.Other,
  // });

  // onSubmit(): void { 
  //   const { posts, phone, ticket, playerNumber, birthday, gender} = this.addPlayerForm.value;
  //   const playerDetails: PlayerDetails = { 
  //   id : uuidv4(),
  //   userId: "",
  //   posts: [posts!],
  //   ticketPass: ticket!,
  //   phone: phone!,
  //   playerNumber: playerNumber!,
  //   birthday: birthday!,
  //   gender: gender! as Gender
  //   };
  //   this.dataSourcePlayers.data = [...this.dataSourcePlayers.data, playerDetails];
  // }

  deleteUserFromTeam(index: number){
    this.dataSourcePlayers.data.splice(index, 1);
    this.dataSourcePlayers.data = [...this.dataSourcePlayers.data];
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
        data: this.dataSourcePlayers.data[index]
      });
    }
    
    dialogRef.afterClosed().subscribe(result => {
      if(!result) this.dataSourcePlayers.data = [...this.dataSourcePlayers.data];
      this.dataSourcePlayers.data.splice(index, 1, result);
      this.dataSourcePlayers.data = [...this.dataSourcePlayers.data];
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
