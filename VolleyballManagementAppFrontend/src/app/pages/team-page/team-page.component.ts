import { Component, Input, OnInit } from '@angular/core';
import { Gender } from 'src/app/models/gender';
import { Post } from 'src/app/models/post';
import { MatTableDataSource } from '@angular/material/table';
import { Team } from 'src/app/models/team';
import { ActivatedRoute } from '@angular/router';
import { TeamService } from 'src/app/services/team.service';
import { MatDialog } from '@angular/material/dialog';
import { UpdateDialogComponent } from 'src/app/components/update-dialog/update-dialog.component';
import { Training } from 'src/app/models/training';
import { TrainingsDialogComponent } from 'src/app/components/trainings-dialog/trainings-dialog.component';
import { PlayerDetails } from 'src/app/models/player-details';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';
import { PlayerDetailsWithName } from 'src/app/models/player-details-with-name';
import { TicketPass } from 'src/app/models/ticket-pass';

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

  displayedColumns: string[] = ['position', 'name', 'number', 'ticket', 'post',  'tools'];
  displayedColumnsTrainings: string[] = ['position', 'date', 'location', 'description', 'tools'];

  TicketPass = TicketPass;
  Gender = Gender;
  Post = Post;

  constructor(
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
        this.teamService.getTeamPlayersByTeamId(this.teamId).subscribe(teamPlayers => {
          this.members = teamPlayers;          
          this.teamService.getTeamTrainingsByTeamId(this.teamId).subscribe(trainings =>{
            trainings.forEach( t => {
              const training: Training = {
                id: t.id,
                participants: this.membersWithName,
                location: t.location,
                date: t.date,
                description: t.description
              }
              this.trainings.push(training);
            })
            this.dataSourceTrainings.data = this.trainings;
          })
          if(this.members !== undefined){
          this.members.forEach( m => {
            this.userService.getUserById(m.userId).subscribe( user => {
              this.users.push(user);
              const player: PlayerDetailsWithName = {
                id: m.id,
                name: user.name,
                birthday: m.birthday,
                phone: m.phone,
                playerNumber: m.playerNumber,
                ticketPass: m.ticketPass,
                gender: m.gender as Gender,
                posts: m.posts as Post[],                  
              }
              this.membersWithName.push(player);
              this.dataSourcePlayers.data = this.membersWithName;
            })
          });
          }
        })
      }

    //this.dataSourceTrainings.data = trainings; //TODO: new endpoint from teamService
    });
    

  }

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
